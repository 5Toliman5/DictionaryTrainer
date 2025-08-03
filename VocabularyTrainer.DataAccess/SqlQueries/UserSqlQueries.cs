namespace VocabularyTrainer.DataAccess.SqlQueries
{
	public class UserSqlQueries
	{
		public const string GetUserId = "SELECT ID FROM Users WHERE Name = @UserName";
	}
}
