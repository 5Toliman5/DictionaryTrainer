using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictinaryTrainer.BusinessLogic.Managers
{
	public class AuthenticationManager : IAuthenticationManager
	{
		private readonly IAuthenticationRepository AuthenticationRepository;
		public AuthenticationManager(IAuthenticationRepository authenticationRepository)
		{
			AuthenticationRepository = authenticationRepository;
		}
		public User? GetUserAsync(string username) => AuthenticationRepository.GetUser(username);
	}
}
