namespace VocabularyTrainer.Domain.Repositories
{
	public interface IUserRepository
	{
		int? GetUserId(string userName);
	}
}