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
        public string AddWordToDictionary(Word word)
        {
            try
            {
                if (this.Words.Any(x => x.Value == word.Value))
                    return "You have already had this word!";
                _wordsRepository.InsertWord(word);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public Word CreateWordObject(string value, string traslation, string dictionary, short userId)
        {
            return new Word()
            {
                Value = value,
                Translation = traslation,
                Dictionary = dictionary,
                UserId = userId
            };
        }
    }
}
