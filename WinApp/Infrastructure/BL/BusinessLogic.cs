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
        private string UserName = "Toliman";
        public AddNewWordsLogic AddNewWordsLogic { get; }
        public TrainYourselfLogic TrainYourselfLogic { get; }
        public AuthenticationManager AuthManager { get; }
        public User? CurrentUser { get; private set; }
        private readonly string ConnectionString;
        public BusinessLogic()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[Constants.DefaultDbConnection].ConnectionString;
            AddNewWordsLogic = new(ConnectionString);
            AuthManager = new(ConnectionString);
            CurrentUser = AuthManager.GetUser(UserName);
            if (CurrentUser != null)
                TrainYourselfLogic = new(ConnectionString, CurrentUser.ID);
            else
                TrainYourselfLogic = new(ConnectionString);

        }
    }
}
