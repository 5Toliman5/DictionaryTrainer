using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Abstract
{
    public interface IWordsRepository
    {
        void InsertWord(Word word);
        List<Word> GetAllWords(short userId);
        void SaveProgress(Word word, DatabaseAction action);
    }
}
