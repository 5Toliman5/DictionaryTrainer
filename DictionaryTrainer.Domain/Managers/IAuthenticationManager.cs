using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Managers
{
    public interface IAuthenticationManager
    {
        User? GetUserAsync(string username);
    }
}