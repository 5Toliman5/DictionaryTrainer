using DictionaryTrainer.Domain.Models;

namespace DictionaryTrainer.Domain.Services
{
    public interface IWordTrainerService
    {
        void AddWord(WordDto word);

        void DeleteCurrentWord();

        WordDto? GetCurrentWord();

        WordDto? GetNewWord();

        int LoadAllWords();

        void SetUser(int userId);

        void UpdateCurrentWord();
    }
}