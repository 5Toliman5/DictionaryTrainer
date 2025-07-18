using Dapper;
using DictionaryTrainer.DAL.SqlQueries;
using DictionaryTrainer.Domain.Abstract;
using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Models;
using Microsoft.Data.SqlClient;

namespace DictionaryTrainer.DataAccess.Repositories
{
	public class WordRepository : IWordRepository
	{
		private readonly string _connectionString;

		public WordRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<Word> GetAllWords(int userId)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var words = connection.Query<Word>(WordSqlQueries.SelectAllWords, new { UserId = userId });			
			connection.Close();
			return words.ToList();
		}

		public void AddWord(AddWordModel model)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			using var transaction = connection.BeginTransaction();
			try
			{
				var insertedWordId = connection.ExecuteScalar<int>(WordSqlQueries.InsertWord, model.Word, transaction);
				connection.Execute(WordSqlQueries.InsertUserWord, new EditWordModel(insertedWordId, model.UserId), transaction);
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

		public void DeleteWord(EditWordModel model)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			using var transaction = connection.BeginTransaction();
			try
			{
				connection.Execute(WordSqlQueries.DeleteUserWord, model, transaction);

				var userCount = connection.ExecuteScalar<int>(WordSqlQueries.SelectUserCountOfWord, model, transaction);
				if (userCount == 0)
					connection.Execute(WordSqlQueries.DeleteWord, model, transaction);
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

		public void UpdateWordWeight(EditWordModel model)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			connection.Execute(WordSqlQueries.UpdateWordWeight, model);
			connection.Close();
		}
	}
}
