using Microsoft.Extensions.DependencyInjection;
using WinApp;
using System.Configuration;
using VocabularyTrainer.BusinessLogic.Services;
using VocabularyTrainer.WinApp.Presenter;
using VocabularyTrainer.WinApp.View;
using VocabularyTrainer.Domain.Services;
using VocabularyTrainer.Domain.Repositories;
using VocabularyTrainer.DataAccess.Repositories;

namespace VocabularyTrainer.WinApp
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
				throw new ConfigurationErrorsException("Connection string is not configured.");
			services.AddSingleton<IUserRepository>(x => new UserRepository(connString));
			services.AddSingleton<IWordRepository>(x => new WordRepository(connString));

			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IWordTrainerService, WordTrainerService>();

			services.AddSingleton<MainFormPresenter>();

			return services;
		}
	}
}
