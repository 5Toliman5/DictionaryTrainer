using DictionaryTrainer.WinApp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using WinApp;
using System.Configuration;
using DictionaryTrainer.Domain.Services;
using DictionaryTrainer.WinApp.View;
using DictionaryTrainer.Domain.Abstract;
using DictionaryTrainer.DataAccess.Repositories;
using DictionaryTrainer.BusinessLogic.Services;

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
			if (string.IsNullOrEmpty(connString))
			{
				throw new ConfigurationErrorsException("Connection string is not configured.");
			}
			services.AddSingleton<IUserRepository>(x => new UserRepository(connString));
			services.AddSingleton<IWordRepository>(x => new WordRepository(connString));

			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IWordTrainerService, WordTrainerService>();

			services.AddSingleton<MainFormPresenter>();

			return services;
		}
	}
}
