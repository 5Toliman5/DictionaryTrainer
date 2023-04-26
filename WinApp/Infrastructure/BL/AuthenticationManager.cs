using DAL.Data.Abstract;
using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.BL
{
    internal class AuthenticationManager
    {
        private IAuthenticationRepository authenticationRepository;
        public AuthenticationManager(string connectionString)
        {
            authenticationRepository = new AuthenticationRepository(connectionString);
        }
        public User GetUser(string username)
        {
            try
            {
                return authenticationRepository.GetUser(username);
            }
            catch
            {
                return null;
            }
        }
    }
}
