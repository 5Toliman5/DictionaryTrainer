using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Repositories
{
    public interface IWordsRepository
    {
        void InsertWord(Word word);
        List<Word> GetAllWords(short userId);
        void UpdateWord(Word word);
        void DeleteWord(Word word);
    }
}
