using Microsoft.Data.SqlClient;
using Dapper;
using DictionaryTrainer.DAL.SqlQueries;
using DictionaryTrainer.Domain.Abstract;

namespace DictionaryTrainer.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly string _connectionString;

		public UserRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public int? GetUserId(string userName)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			return connection.QuerySingleOrDefault<int?>(UserSqlQueries.GetUserId, new { UserName = userName });
		}
	}
}
