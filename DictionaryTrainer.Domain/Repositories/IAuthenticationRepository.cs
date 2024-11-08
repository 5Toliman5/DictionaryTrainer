using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Repositories
{
    public interface IAuthenticationRepository
    {
        User? GetUser(string userName);
    }
}
