using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.Domain.Services;

namespace DictionaryTrainer.BusinessLogic.Services
{
    public class UserService(IUserRepository repository) : IUserService
	{
		public int? GetUserId(string userName) => repository.GetUserId(userName);
	}
}
