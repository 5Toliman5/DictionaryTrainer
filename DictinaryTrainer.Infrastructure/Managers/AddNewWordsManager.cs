using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictinaryTrainer.BusinessLogic.Managers
{
	public class AddNewWordsManager : BaseWordsManager, IAddNewWordsManager
	{
		public AddNewWordsManager(IWordsRepository wordsRepository, short? userId) : base(wordsRepository, userId)
		{
			this.Words = WordsRepository.GetAllWords(UserId.Value);
		}
		public void AddWordToDictionary(Word word)
		{
			var existingWord = this.Words.SingleOrDefault(x => x.Value == word.Value);
			if (existingWord is not null)
			{
				WordsRepository.DeleteWord(existingWord);
				this.Words.Remove(existingWord);
			}
			WordsRepository.InsertWord(word);
			this.Words.Add(word);
		}
		public Word CreateWordObject(string value, string traslation, short userId) => new Word()
		{
			Value = value,
			Translation = traslation,
			UserId = userId
		};

		public Word CreateWordObject(string value, string traslation, string dictionary, short userId)
		{
			throw new NotImplementedException();
		}
	}
}
