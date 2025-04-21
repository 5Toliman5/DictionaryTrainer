using Dapper;
using DictionaryTrainer.DAL.Models;
using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.DAL.SqlQueries;
using DictionaryTrainer.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace DictionaryTrainer.DAL.Repositories
{
	public class WordRepository : IWordRepository
	{
		private readonly string ConnectionString;

		public WordRepository(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public List<Word> GetAllWords(int userId)
		{
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection.Query<Word>(WordSqlQueries.SelectAllWords, new { UserId = userId }).ToList();
		}

		public void AddWord(AddWordModel model)
		{
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			var insertedWordId = connection.ExecuteScalar<int>(WordSqlQueries.InsertWord, model.Word);
			connection.Execute(WordSqlQueries.InsertUserWord, new UpdateWordModel(insertedWordId, model.UserId));
		}

		public void DeleteWord(UpdateWordModel model)
		{
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();

			connection.Execute(WordSqlQueries.DeleteUserWord, model);

			var userCount = connection.ExecuteScalar<int>(WordSqlQueries.SelectUserCountOfWord, model);
			if (userCount == 0)
			{
				connection.Execute(WordSqlQueries.DeleteWord, model.WordId);
			}
		}

		public void UpdateWordWeight(UpdateWordModel model)
		{
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			connection.Execute(WordSqlQueries.UpdateWordWeight, model);
		}
	}
}
