namespace DictionaryTrainer.Domain.Abstract
{
	public interface IUserRepository
	{
		int? GetUserId(string userName);
	}
}