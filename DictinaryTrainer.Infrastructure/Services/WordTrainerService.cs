using Common.Extensions;
using DictinaryTrainer.BusinessLogic.Models;
using DictinaryTrainer.BusinessLogic.Services.Abstract;
using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DictinaryTrainer.BusinessLogic.Services
{
    public class WordTrainerService : IWordTrainerService
	{
		private readonly IDictionaryTrainerContext Context;
		private readonly Random Random;
		private List<Word> Words;
		private Word? CurrentWord;
		private short? CurrentUserId;

		public WordTrainerService(IDictionaryTrainerContext dbContext)
		{
			Context = dbContext;
			Words = [];
			Random = new();
		}
		public void SetUser(short userId)
		{
			CurrentUserId = userId;
		}
		public int LoadAllWords()
		{
			Words = Context.Words.Where(x => x.UserId == CurrentUserId).AsNoTracking().ToList();
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

			var existingWord = Words.SingleOrDefault(x => x.Value == word.Value);
			if (existingWord is not null)
			{
				Context.Words.Remove(existingWord);
				Words.Remove(existingWord);
			}
			var newWord = new Word
			{
				Value = word.Value,
				Translation = word.Translation,
				UserId = CurrentUserId.Value
			};
			Context.Words.Add(newWord);
			Context.SaveChanges();
			Words.Add(newWord);
		}
		public void UpdateCurrentWord()
		{
			if (CurrentWord is null)
				return;
			CurrentWord.Weight++;
			Context.Words.Update(CurrentWord);
			Context.SaveChanges();
		}
		public void DeleteCurrentWord()
		{
			if (CurrentWord is null)
				return;
			Words.Remove(CurrentWord);
			Context.Words.Remove(CurrentWord);
			Context.SaveChanges();
			CurrentWord = null;
		}

	}
}
