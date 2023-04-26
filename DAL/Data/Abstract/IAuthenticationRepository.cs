using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Abstract
{
    public interface IAuthenticationRepository
    {
        User GetUser(string userName);
    }
}
