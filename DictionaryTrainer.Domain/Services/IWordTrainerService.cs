using DictionaryTrainer.Domain.Models;

namespace DictionaryTrainer.Domain.Services
{
    public interface IWordTrainerService
    {
        int GetWordsCount();

		void AddWord(WordDto word);

        void DeleteCurrentWord();

        WordDto? GetCurrentWord();

        WordDto? GetNewWord();

		void LoadWords();

        void SetUser(int userId);

        void UpdateCurrentWord();
    }
}