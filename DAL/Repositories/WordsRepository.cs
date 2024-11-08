using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.DAL.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        private readonly DictionaryTrainerContext DbContext;
        public WordsRepository(DictionaryTrainerContext dbContext)
        {
            DbContext = dbContext;
        }

        public void InsertWord(Word word)
        {
            DbContext.Words.Add(word);
            DbContext.SaveChanges();
        }
        public List<Word> GetAllWords(short userId)
        {
            return DbContext.Words.Where(x => x.UserId == userId).ToList();
        }

        public void UpdateWord(Word word)
        {
            DbContext.Update(word);
            DbContext.SaveChanges();
        }

        public void DeleteWord(Word word)
        {
            DbContext.Remove(word);
            DbContext.SaveChanges();
        }
    }
}
