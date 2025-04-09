using DictinaryTrainer.BusinessLogic.Services.Abstract;
using DictionaryTrainer.DAL.EF;

namespace DictinaryTrainer.BusinessLogic.Services
{
    public class UserService : IUserService
	{
		private readonly IDictionaryTrainerContext Context;

		public UserService(IDictionaryTrainerContext context)
		{
			Context = context;
		}

		public short? GetUserId(string userName)
		{
			return Context.Users.SingleOrDefault(x => x.Name == userName)?.ID;
		}
	}
}
