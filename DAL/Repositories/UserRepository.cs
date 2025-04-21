using Microsoft.Data.SqlClient;
using Dapper;
using DictionaryTrainer.DAL.SqlQueries;
using DictionaryTrainer.DAL.Repositories.Abstract;

namespace DictionaryTrainer.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly string ConnectionString;

		public UserRepository(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public int? GetUserId(string userName)
		{
			using var connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection.QuerySingleOrDefault<int?>(UserSqlQueries.GetUserId, new { UserName = userName });
		}
	}
}
