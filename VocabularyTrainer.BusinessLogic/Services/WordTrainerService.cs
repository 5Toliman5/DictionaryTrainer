using VocabularyTrainer.Domain.Entities;
using VocabularyTrainer.Domain.Models;
using VocabularyTrainer.Domain.Repositories;
using VocabularyTrainer.Domain.Services;

namespace VocabularyTrainer.BusinessLogic.Services
{
    public class WordTrainerService : IWordTrainerService
	{
		private readonly IWordRepository _repository;
		private readonly IWordsShuffleService _wordsShuffleService;

		private readonly List<WordDto> _words;
		private WordDto? _currentWord;
		private readonly int _maxWeight;

		private int? _currentUserId;

		public WordTrainerService(int maxWeight, IWordRepository repository, IWordsShuffleService wordsShuffleService)
		{
			_repository = repository;
			_words = [];
			_maxWeight = maxWeight;
			_wordsShuffleService = wordsShuffleService;
		}

		public void SetUser(int userId) => _currentUserId = userId;

		public int GetWordsCount() => _words.Count;

		public void LoadWords()
		{
			var dbWords = _repository.GetAllWords(CurrentUserId);
			var shuffledWords = _wordsShuffleService.Shuffle(dbWords);
			_words.AddRange(shuffledWords);
		}

		public WordDto? GetCurrentWord()
		{
			return _currentWord is null 
				? null
				: new WordDto(_currentWord.Value, _currentWord.Translation);
		}

		public WordDto? GetNewWord()
		{
			if (_currentWord is not null) 
				_words.Remove(_currentWord);

			if (_words.Count == 0) 
				LoadWords();

			if (_words.Count == 0) 
				return null;

			_currentWord = _words[0];
			return new WordDto(_currentWord.Value, _currentWord.Translation);
		}

		public void AddWord(WordDto word)
		{
			if (!_currentUserId.HasValue)
				throw new Exception("Current user is not specified!");

			var existingWord = GetExistingWord(word);
			if (existingWord is not null)
			{
				_words.Remove(existingWord);
				_repository.DeleteWord(new EditWordRequest(existingWord.Id, CurrentUserId));
			}
			var newWord = new WordDto(word.Value, word.Translation);

			_words.Add(newWord);
			_repository.AddWord(new AddWordRequest(new Word(word.Value, word.Translation), CurrentUserId));
		}

		public void UpdateCurrentWord(UpdateWeightType updateWeightType)
		{
			if (!NeedToUpdateWordWeight(updateWeightType))
				return;

			_repository.UpdateWordWeight(new UpdateWordWeightRequest(_currentWord.Id, CurrentUserId, updateWeightType));
		}

		public void DeleteCurrentWord()
		{
			if (_currentWord is null)
				return;
			_words.Remove(_currentWord);
			_repository.DeleteWord(new EditWordRequest(_currentWord.Id, CurrentUserId));
			_currentWord = null;
		}

		private WordDto? GetExistingWord(WordDto newWord)
		{
			return _words.FirstOrDefault(x => x.Value.Equals(newWord.Value, StringComparison.CurrentCultureIgnoreCase));
		}

		private int CurrentUserId => _currentUserId ?? throw new InvalidOperationException("Current user is not set.");

		private bool NeedToUpdateWordWeight(UpdateWeightType updateWeightType)
		{
			if (_currentWord is null)
				return false;

			return updateWeightType switch
			{
				UpdateWeightType.Increase => _currentWord.Weight < _maxWeight,
				UpdateWeightType.Decrease => _currentWord.Weight > 0,
				_ => false
			};
		}
	}
}
