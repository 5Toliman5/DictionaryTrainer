using DictinaryTrainer.Infrastructure.Managers;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.WinApp.Infrastructure.BusinessLogic
{
	internal interface IWordsUnitOfWork
	{
		IAddNewWordsManager AddNewWordsManager { get; }
		IAuthenticationManager AuthenticationManager { get; }
		ITrainYourselfManager TrainYourselfManager { get; }
		User? CurrentUser { get; }
	}

	internal class WordsUnitOfWork : IWordsUnitOfWork
	{
		private string UserName { get; set; }
		public IAddNewWordsManager AddNewWordsManager { get; }
		public ITrainYourselfManager TrainYourselfManager { get; }
		public IAuthenticationManager AuthenticationManager { get; }
		public User? CurrentUser { get; private set; }
		public WordsUnitOfWork(IAuthenticationRepository authenticationRepository, IWordsRepository wordsRepository, string username)
		{
			this.UserName = username;
			this.AuthenticationManager = new AuthenticationManager(authenticationRepository);

			if (!string.IsNullOrEmpty(UserName))
				this.CurrentUser = authenticationRepository.GetUser(this.UserName);

			this.AddNewWordsManager = new AddNewWordsManager(wordsRepository, CurrentUser?.ID);
			this.TrainYourselfManager = new TrainYourselfManager(wordsRepository, CurrentUser?.ID);
		}
	}
}
