using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Managers
{
    public interface IAddNewWordsManager
    {
        void AddWordToDictionary(Word word);
        Word CreateWordObject(string value, string traslation, short userId);
        Word CreateWordObject(string value, string traslation, string dictionary, short userId);
    }
}