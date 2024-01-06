using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.BL
{
    internal class BusinessLogic
    {
        private string UserName { get; set; }
        public AddNewWordsLogic AddNewWordsLogic { get; }
        public TrainYourselfLogic TrainYourselfLogic { get; }
        public AuthenticationManager AuthManager { get; }
        public User? CurrentUser { get; private set; }
        private readonly string ConnectionString;
        public BusinessLogic(string username)
        {
            this.UserName = username;
            ConnectionString = ConfigurationManager.ConnectionStrings[Constants.DefaultDbConnection].ConnectionString;
            AuthManager = new(ConnectionString);
            CurrentUser = AuthManager.GetUser(UserName);
            AddNewWordsLogic = new(ConnectionString, CurrentUser?.ID);
            TrainYourselfLogic = new(ConnectionString, CurrentUser?.ID);

        }
    }
}
