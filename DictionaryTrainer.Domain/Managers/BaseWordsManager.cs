using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTrainer.Domain.Managers
{
    public abstract class BaseWordsManager
    {
        protected IWordsRepository _wordsRepository;
        protected short? _userId;
        public IList<Word>? Words { get; protected set; }

        protected BaseWordsManager(IWordsRepository wordsRepository, short? userId)
        {
            _wordsRepository = wordsRepository;
            _userId = userId;
            this.Words = new List<Word>();
        }
    }
}
