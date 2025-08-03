using Dapper;
using Microsoft.Data.SqlClient;
using VocabularyTrainer.DataAccess.SqlQueries;
using VocabularyTrainer.Domain.Entities;
using VocabularyTrainer.Domain.Models;
using VocabularyTrainer.Domain.Repositories;

namespace VocabularyTrainer.DataAccess.Repositories
{
	public class WordRepository : IWordRepository
	{
		private readonly string _connectionString;

		public WordRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<WordDto> GetAllWords(int userId)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var words = connection.Query<WordDto>(WordSqlQueries.SelectAllWords, new { UserId = userId });			
			connection.Close();
			return words.ToList();
		}

		public void AddWord(AddWordRequest request)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			using var transaction = connection.BeginTransaction();
			try
			{
				var insertedWordId = connection.ExecuteScalar<int>(WordSqlQueries.InsertWord, request.Word, transaction);
				connection.Execute(WordSqlQueries.InsertUserWord, new EditWordRequest(insertedWordId, request.UserId), transaction);
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
			finally
			{
				connection.Close();
			}
		}

		public void DeleteWord(EditWordRequest request)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			using var transaction = connection.BeginTransaction();
			try
			{
				connection.Execute(WordSqlQueries.DeleteUserWord, request, transaction);

				var userCount = connection.ExecuteScalar<int>(WordSqlQueries.SelectUserCountOfWord, request, transaction);
				if (userCount == 0)
					connection.Execute(WordSqlQueries.DeleteWord, request, transaction);
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
			finally
			{
				connection.Close();
			}
		}

		public void UpdateWordWeight(UpdateWordWeightRequest request)
		{
			var query = string.Format(WordSqlQueries.UpdateWordWeight, request.Operator);
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			connection.Execute(query, request);
			connection.Close();
		}
	}
}
