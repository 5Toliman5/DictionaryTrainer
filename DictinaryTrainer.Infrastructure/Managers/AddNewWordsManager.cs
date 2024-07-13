using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictinaryTrainer.Infrastructure.Managers
{
    public class AddNewWordsManager : BaseWordsManager, IAddNewWordsManager
    {
        public AddNewWordsManager(IWordsRepository wordsRepository, short? userId) : base(wordsRepository, userId)
        {
            this.Words = _wordsRepository.GetAllWords(_userId.Value);
        }
        public void AddWordToDictionary(Word word)
        {
            try
            {
                var existingWord = this.Words.SingleOrDefault(x => x.Value == word.Value);
                if (existingWord is not null)
                {
                    _wordsRepository.DeleteWord(existingWord);
                    this.Words.Remove(existingWord);
                }
                _wordsRepository.InsertWord(word);
                this.Words.Add(word);
            }
            catch (Exception ex)
            {
            }
        }
        public Word CreateWordObject(string value, string traslation, short userId)
        {
            return new Word()
            {
                Value = value,
                Translation = traslation,
                UserId = userId
            };
        }

        public Word CreateWordObject(string value, string traslation, string dictionary, short userId)
        {
            throw new NotImplementedException();
        }
    }
}
