using VocabularyTrainer.Domain.Entities;
using VocabularyTrainer.Domain.Models;

namespace VocabularyTrainer.DataAccess.SqlQueries
{
	public class WordSqlQueries
	{
		#region Words
		public const string InsertWord = $"INSERT INTO Words(Value, Translation) OUTPUT INSERTED.ID VALUES(@{nameof(Word.Value)},@{nameof(Word.Translation)})";

		public const string DeleteWord = $"DELETE FROM Words WHERE Id = @{nameof(EditWordRequest.WordId)}";

		public const string SelectAllWords = "SELECT w.Id, w.Value, w.Translation, uw.Weight FROM Words w JOIN UserWords uw on w.ID = uw.WordId WHERE uw.UserId = @UserId";
		#endregion

		#region UserWords
		public const string UpdateWordWeight = "UPDATE UserWords SET Weight = Weight {0} 1 " + UserWordsWhereClause;

		public const string DeleteUserWord = $"DELETE FROM UserWords" + UserWordsWhereClause;

		public const string SelectUserCountOfWord = $"SELECT COUNT(*) FROM UserWords" + UserWordsWhereClause;

		public const string InsertUserWord = $"INSERT INTO UserWords(WordId, UserId, Weight) VALUES(@{nameof(EditWordRequest.WordId)}, @{nameof(EditWordRequest.UserId)}, 0)";

		private const string UserWordsWhereClause = $" WHERE WordId = @{nameof(EditWordRequest.WordId)} and UserId = @{nameof(EditWordRequest.UserId)}"; 
		#endregion
	}
}
