using VocabularyTrainer.Domain.Repositories;
using VocabularyTrainer.Domain.Services;

namespace VocabularyTrainer.BusinessLogic.Services
{
    public class UserService(IUserRepository repository) : IUserService
	{
		public int? GetUserId(string userName) => repository.GetUserId(userName);
	}
}
