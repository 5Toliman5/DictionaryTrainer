using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.WinApp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using WinApp;
using System.Configuration;
using DictionaryTrainer.DAL.Repositories;
using DictionaryTrainer.Domain.Services;
using DictionaryTrainer.BusinessLogic.Services;
using DictionaryTrainer.WinApp.View;

namespace DictionaryTrainer.WinApp
{
	internal class DependencyResolver
	{
		public static IServiceCollection ConstructServices()
		{
			var services = new ServiceCollection();

			services.AddSingleton<IMainFormView, MainForm>();
			services.AddSingleton(sp => (MainForm)sp.GetRequiredService<IMainFormView>());

			var connString = ConfigurationManager.AppSettings["ConnectionString"];
			services.AddSingleton<IUserRepository>(x => new UserRepository(connString));
			services.AddSingleton<IWordRepository>(x => new WordRepository(connString));

			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IWordTrainerService, WordTrainerService>();

			services.AddSingleton<MainFormPresenter>();

			return services;
		}
	}
}
