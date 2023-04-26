using DAL.Data.Abstract;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.EF_DAL
{
    public class WordsRepository : AbstractRepository, IWordsRepository
    {
        public WordsRepository(string connectionString) : base(connectionString)
        {
        }

        public void InsertWord(Word word)
        {
            dbContext.Words.Add(word);
            dbContext.SaveChanges();
        }
        public List<Word> GetAllWords(short userId)
        {
            return dbContext.Words.Where(x => x.UserId == userId).ToList();
        }
        public void SaveProgress(Word word, DatabaseAction action)
        {
            switch(action)
            {
                case DatabaseAction.Update:
                    {
                        dbContext.Update(word);
                        break;
                    };
                case DatabaseAction.Delete:
                    {
                        dbContext.Remove(word);
                        break;
                    };
                default:break;
            }
            dbContext.SaveChanges();

        }
    }
}
