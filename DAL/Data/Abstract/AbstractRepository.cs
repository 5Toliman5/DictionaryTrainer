using DAL.Data.EF_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Abstract
{
    public class AbstractRepository
    {
        protected readonly DictionaryTrainerContext dbContext;
        public AbstractRepository(string connectionString)
        {
            this.dbContext = new(connectionString);
        }
    }
}
