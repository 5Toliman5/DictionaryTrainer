using DAL.Data.Abstract;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.EF_DAL
{
    public class AuthenticationRepository : AbstractRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(string connectionString) : base(connectionString)
        {
        }

        public User GetUser(string userName)
        {
            return dbContext.Users.Single(x => x.Name == userName);
        }
    }
}
