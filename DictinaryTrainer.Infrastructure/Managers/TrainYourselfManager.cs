using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictinaryTrainer.Infrastructure.Managers
{
    public class TrainYourselfManager : BaseWordsManager, ITrainYourselfManager
    {
        private Random _random;
        public Word CurrentWord { get; set; }
        public TrainYourselfManager(IWordsRepository wordsRepository, short? userId) : base(wordsRepository, userId)
        {
            _random = new();
            LoadAllWords();
        }

        public void LoadAllWords()
        {
            try
            {
                if (_userId is not null)
                    this.Words = _wordsRepository.GetAllWords(_userId.Value);
            }
            catch (Exception ex)
            {

            }
        }

        public Word GetNewWord()
        {
            if (CurrentWord != null) this.Words.Remove(CurrentWord);
            if (this.Words == null || !Words.Any())
            {
                LoadAllWords();
                if (this.Words == null || !this.Words.Any())
                    return default;
            }
            return this.CurrentWord = this.Words[_random.Next(Words.Count)];

        }
        public void DeleteCurrentWord()
        {
            try
            {
                _wordsRepository.DeleteWord(this.CurrentWord);
                this.Words.Remove(this.CurrentWord);
                CurrentWord = null;
            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateCurrentWord()
        {
            try
            {
                this.CurrentWord.Weight++;
                _wordsRepository.UpdateWord(this.CurrentWord);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
