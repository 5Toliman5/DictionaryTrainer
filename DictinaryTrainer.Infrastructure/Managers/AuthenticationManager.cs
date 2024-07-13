using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Managers;
using DictionaryTrainer.Domain.Repositories;

namespace DictinaryTrainer.Infrastructure.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationManager(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public User GetUserAsync(string username)
        {
            try
            {
                return _authenticationRepository.GetUser(username);
            }
            catch
            {
                return default;
            }
        }
    }
}
