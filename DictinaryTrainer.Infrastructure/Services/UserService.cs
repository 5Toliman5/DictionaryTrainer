using DictinaryTrainer.BusinessLogic.Services.Abstract;
using DictionaryTrainer.DAL.Repositories.Abstract;

namespace DictinaryTrainer.BusinessLogic.Services
{
    public class UserService : IUserService
	{
		private readonly IUserRepository Repository;

		public UserService(IUserRepository repository)
		{
			Repository = repository;
		}

		public int? GetUserId(string userName) => Repository.GetUserId(userName);
	}
}
