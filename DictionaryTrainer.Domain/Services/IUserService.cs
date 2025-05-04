namespace DictionaryTrainer.Domain.Services
{
    public interface IUserService
    {
		int? GetUserId(string userName);
	}
}