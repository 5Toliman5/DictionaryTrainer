using Common.Extensions;
using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Models;
using DictionaryTrainer.Domain.Services;
namespace DictinaryTrainer.BusinessLogic.Services
{
    public class WordTrainerService : IWordTrainerService
	{
		private readonly IWordRepository Repository;
		private readonly Random Random;

		private List<Word> Words;
		private Word? CurrentWord;
		private int? CurrentUserId;

		public WordTrainerService(IWordRepository repository)
		{
			Repository = repository;
			Words = [];
			Random = new();
		}

		public void SetUser(int userId) => CurrentUserId = userId;

		public int LoadAllWords()
		{
			Words = Repository.GetAllWords(CurrentUserId.Value);
			return Words.Count;
		}

		public WordDto? GetCurrentWord()
		{
			return CurrentWord is null?
				null
				: new(CurrentWord.Value, CurrentWord.Translation);
		}

		public WordDto? GetNewWord()
		{
			if (CurrentWord is not null) 
				Words.Remove(CurrentWord);

			if (Words.IsNullOrEmpty())
				return null;

			CurrentWord = Words[Random.Next(Words.Count)];
			return new(CurrentWord.Value, CurrentWord.Translation);
		}

		public void AddWord(WordDto word)
		{
			if (!CurrentUserId.HasValue)
				throw new Exception("Current user is not specified!");

			var existingWord = GetExistingWord(word);
			if (existingWord is not null)
			{
				Words.Remove(existingWord);
				Repository.DeleteWord(new(existingWord.ID, CurrentUserId.Value));
			}
			var newWord = new Word
			{
				Value = word.Value,
				Translation = word.Translation
			};

			Words.Add(newWord);
			Repository.AddWord(new(newWord, CurrentUserId.Value));
		}

		public void UpdateCurrentWord()
		{
			if (CurrentWord is null)
				return;
			Repository.UpdateWordWeight(new(CurrentWord.ID, CurrentUserId.Value));
		}

		public void DeleteCurrentWord()
		{
			if (CurrentWord is null)
				return;
			Words.Remove(CurrentWord);
			Repository.DeleteWord(new(CurrentWord.ID, CurrentUserId.Value));
			CurrentWord = null;
		}

		private Word? GetExistingWord(WordDto newWord)
		{
			return Words.SingleOrDefault(x => x.Value.Equals(newWord.Value, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
