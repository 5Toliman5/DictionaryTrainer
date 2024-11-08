using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Repositories;

namespace DictionaryTrainer.DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DictionaryTrainerContext DbContext;
        public AuthenticationRepository(DictionaryTrainerContext dbContext)
        {
            DbContext = dbContext;
        }

		public User? GetUser(string userName) => DbContext.Users.SingleOrDefault(x => x.Name == userName);
	}
}
