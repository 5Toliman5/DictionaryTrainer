using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Managers
{
    public interface IAddNewWordsManager
    {
        string AddWordToDictionary(Word word);
        Word CreateWordObject(string value, string traslation, string dictionary, short userId);
    }
}