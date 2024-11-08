using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.Domain.Managers
{
	public abstract class BaseWordsManager
    {
        protected IWordsRepository WordsRepository;
        protected short? UserId;
        public IList<Word>? Words { get; protected set; }

        protected BaseWordsManager(IWordsRepository wordsRepository, short? userId)
        {
            WordsRepository = wordsRepository;
            UserId = userId;
            this.Words = [];
        }
    }
}
