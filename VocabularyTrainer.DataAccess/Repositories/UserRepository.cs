using Microsoft.Data.SqlClient;
using Dapper;
using VocabularyTrainer.DataAccess.SqlQueries;
using VocabularyTrainer.Domain.Repositories;

namespace VocabularyTrainer.DataAccess.Repositories
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
