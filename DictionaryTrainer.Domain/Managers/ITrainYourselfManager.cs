using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Managers
{
    public interface ITrainYourselfManager
    {
        Word CurrentWord { get; set; }

        void DeleteCurrentWord();
        Word GetNewWord();
        void LoadAllWords();
        void UpdateCurrentWord();
    }
}