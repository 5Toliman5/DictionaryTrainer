namespace DictionaryTrainer.DAL.Repositories.Abstract
{
	public interface IUserRepository
	{
		int? GetUserId(string userName);
	}
}