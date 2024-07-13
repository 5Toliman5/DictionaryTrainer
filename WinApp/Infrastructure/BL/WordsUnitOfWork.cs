using DictinaryTrainer.Infrastructure.Managers;
using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;
using System.Configuration;

namespace WinApp.Infrastructure.BL
{
    internal class WordsUnitOfWork
    {
        private string UserName { get; set; }
        public AddNewWordsManager AddNewWordsManager { get; }
        public TrainYourselfManager TrainYourselfManager { get; }
        public AuthenticationManager AuthenticationManager { get; }
        public User? CurrentUser { get; private set; }
        public WordsUnitOfWork(IAuthenticationRepository authenticationRepository, IWordsRepository wordsRepository, string username)
        {
            UserName = username;
            AuthenticationManager = new(authenticationRepository);
            if (!string.IsNullOrEmpty(UserName))
                CurrentUser = authenticationRepository.GetUser(UserName);
            AddNewWordsManager = new(wordsRepository, CurrentUser?.ID);
            TrainYourselfManager = new(wordsRepository, CurrentUser?.ID);
        }
    }
}
