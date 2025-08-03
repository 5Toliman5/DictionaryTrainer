namespace VocabularyTrainer.Domain.Services
{
    public interface IUserService
    {
		int? GetUserId(string userName);
	}
}