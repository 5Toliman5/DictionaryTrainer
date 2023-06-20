using DAL.Data.Abstract;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.BL.Abstract
{
    internal abstract class AbstractBusinessLogic
    {
        protected IWordsRepository WordsRepository;
        public virtual short? UserId { get; set; } = null;
        public virtual IList<Word> Words { get; protected set; }

        public AbstractBusinessLogic(IWordsRepository wordsRepository, short? userId)
        {
             WordsRepository = wordsRepository;
            UserId = userId;
        }
    }
}
