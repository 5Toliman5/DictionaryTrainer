using DictionaryTrainer.DAL.Models;
using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.DAL.SqlQueries
{
	public class WordSqlQueries
	{
		#region Words
		public const string InsertWord = $"INSERT INTO Words(Value, Translation) VALUES(@{nameof(Word.Value)},@{nameof(Word.Translation)})";

		public const string DeleteWord = "DELETE FROM Words WHERE WordId = @WordId)";

		public const string SelectAllWords = "SELECT w.* FROM Words w JOIN UserWords uw on w.ID = uw.WordId WHERE uw.UserId = @UserId";
		#endregion

		#region UserWords
		public const string UpdateWordWeight = $"UPDATE UserWords SET Weight = Weight + 1" + UserWordsWhereClause;

		public const string DeleteUserWord = $"DELETE FROM UserWords" + UserWordsWhereClause;

		public const string SelectUserCountOfWord = $"SELECT COUNT(*) FROM Words" + UserWordsWhereClause;

		public const string InsertUserWord = $"INSERT INTO UserWords(WordId, UserId) VALUES(@{nameof(UpdateWordModel.WordId)}, @{nameof(UpdateWordModel.UserId)})";

		private const string UserWordsWhereClause = $" WHERE WordId = @{nameof(UpdateWordModel.WordId)} and UserId = @{nameof(UpdateWordModel.UserId)}"; 
		#endregion
	}
}
