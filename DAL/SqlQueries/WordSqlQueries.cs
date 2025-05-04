using DictionaryTrainer.DAL.Models;
using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.DAL.SqlQueries
{
	public class WordSqlQueries
	{
		#region Words
		public const string InsertWord = $"INSERT INTO Words(Value, Translation) OUTPUT INSERTED.ID VALUES(@{nameof(Word.Value)},@{nameof(Word.Translation)})";

		public const string DeleteWord = $"DELETE FROM Words WHERE Id = @{nameof(EditWordModel.WordId)}";

		public const string SelectAllWords = "SELECT w.* FROM Words w JOIN UserWords uw on w.ID = uw.WordId WHERE uw.UserId = @UserId";
		#endregion

		#region UserWords
		public const string UpdateWordWeight = $"UPDATE UserWords SET Weight = Weight + 1" + UserWordsWhereClause;

		public const string DeleteUserWord = $"DELETE FROM UserWords" + UserWordsWhereClause;

		public const string SelectUserCountOfWord = $"SELECT COUNT(*) FROM UserWords" + UserWordsWhereClause;

		public const string InsertUserWord = $"INSERT INTO UserWords(WordId, UserId, Weight) VALUES(@{nameof(EditWordModel.WordId)}, @{nameof(EditWordModel.UserId)}, 0)";

		private const string UserWordsWhereClause = $" WHERE WordId = @{nameof(EditWordModel.WordId)} and UserId = @{nameof(EditWordModel.UserId)}"; 
		#endregion
	}
}
