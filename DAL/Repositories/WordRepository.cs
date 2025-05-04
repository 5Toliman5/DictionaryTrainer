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
			var words = connection.Query<Word>(WordSqlQueries.SelectAllWords, new { UserId = userId });			
			connection.Close();
			return words.ToList();
		}

		public void AddWord(AddWordModel model)
		{
			using var connection = new SqlConnection(ConnectionString);
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
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			using var transaction = connection.BeginTransaction();
			try
			{
				connection.Execute(WordSqlQueries.DeleteUserWord, model, transaction);

				var userCount = connection.ExecuteScalar<int>(WordSqlQueries.SelectUserCountOfWord, model, transaction);
				if (userCount == 0)
				{
					connection.Execute(WordSqlQueries.DeleteWord, model, transaction);
				}
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
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			connection.Execute(WordSqlQueries.UpdateWordWeight, model);
			connection.Close();
		}
	}
}
