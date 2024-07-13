using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DictionaryTrainerContext _dbContext;
        public AuthenticationRepository(DictionaryTrainerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(string userName)
        {
            return _dbContext.Users.Single(x => x.Name == userName);
        }
    }
}
