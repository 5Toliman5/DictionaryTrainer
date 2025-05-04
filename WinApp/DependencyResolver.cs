using DictinaryTrainer.BusinessLogic.Services;
using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.WinApp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using WinApp;
using System.Configuration;
using DictionaryTrainer.DAL.Repositories;
using DictionaryTrainer.Domain.Services;

namespace DictionaryTrainer.WinApp
{
	internal class DependencyResolver
	{
		public static IServiceCollection ConstructServices()
		{
			var services = new ServiceCollection();
			services.AddSingleton<MainForm>();

			var connString = ConfigurationManager.AppSettings["ConnectionString"];
			services.AddScoped<IUserRepository>(x => new UserRepository(connString));
			services.AddScoped<IWordRepository>(x => new WordRepository(connString));

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IWordTrainerService, WordTrainerService>();
			services.AddScoped<IMainFormPresenter, MainFormPresenter>();

			return services;
		}
	}
}
