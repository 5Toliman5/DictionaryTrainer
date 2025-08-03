using VocabularyTrainer.Domain.Entities;
using VocabularyTrainer.Domain.Models;
using VocabularyTrainer.Domain.Repositories;
using VocabularyTrainer.Domain.Services;

namespace VocabularyTrainer.BusinessLogic.Services
{
    public class WordTrainerService : IWordTrainerService
	{
		private readonly IWordRepository _repository;
		private readonly Random _random;

		private readonly List<Word> _words;
		private Word? _currentWord;
		private int? _currentUserId;

		public WordTrainerService(IWordRepository repository)
		{
			_repository = repository;
			_words = [];
			_random = new();
		}

		public void SetUser(int userId) => _currentUserId = userId;

		public int GetWordsCount() => _words.Count;

		public void LoadWords()
		{
			_words.AddRange(_repository.GetAllWords(CurrentUserId));
		}

		public WordDto? GetCurrentWord()
		{
			return _currentWord is null 
				? null
				: new (_currentWord.Value, _currentWord.Translation);
		}

		public WordDto? GetNewWord()
		{
			if (_currentWord is not null) 
				_words.Remove(_currentWord);

			if (_words.Count == 0) 
				LoadWords();

			if (_words.Count == 0) 
				return null;

			_currentWord = _words[_random.Next(_words.Count)];
			return new(_currentWord.Value, _currentWord.Translation);
		}

		public void AddWord(WordDto word)
		{
			if (!_currentUserId.HasValue)
				throw new Exception("Current user is not specified!");

			var existingWord = GetExistingWord(word);
			if (existingWord is not null)
			{
				_words.Remove(existingWord);
				_repository.DeleteWord(new(existingWord.ID, CurrentUserId));
			}
			var newWord = new Word
			{
				Value = word.Value,
				Translation = word.Translation
			};

			_words.Add(newWord);
			_repository.AddWord(new(newWord, CurrentUserId));
		}

		public void UpdateCurrentWord()
		{
			if (_currentWord is null)
				return;
			_repository.UpdateWordWeight(new(_currentWord.ID, CurrentUserId));
		}

		public void DeleteCurrentWord()
		{
			if (_currentWord is null)
				return;
			_words.Remove(_currentWord);
			_repository.DeleteWord(new(_currentWord.ID, CurrentUserId));
			_currentWord = null;
		}

		private Word? GetExistingWord(WordDto newWord)
		{
			return _words.FirstOrDefault(x => x.Value.Equals(newWord.Value, StringComparison.CurrentCultureIgnoreCase));
		}

		private int CurrentUserId => _currentUserId ?? throw new InvalidOperationException("Current user is not set.");
	}
}
