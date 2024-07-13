using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.DAL.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        private readonly DictionaryTrainerContext _dbContext;
        public WordsRepository(DictionaryTrainerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertWord(Word word)
        {
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();
        }
        public List<Word> GetAllWords(short userId)
        {
            return _dbContext.Words.Where(x => x.UserId == userId).ToList();
        }

        public void UpdateWord(Word word)
        {
            _dbContext.Update(word);
            _dbContext.SaveChanges();
        }

        public void DeleteWord(Word word)
        {
            _dbContext.Remove(word);
            _dbContext.SaveChanges();
        }
    }
}
