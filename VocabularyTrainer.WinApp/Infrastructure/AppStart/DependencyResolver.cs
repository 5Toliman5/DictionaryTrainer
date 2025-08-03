using Microsoft.Extensions.DependencyInjection;
using WinApp;
using VocabularyTrainer.BusinessLogic.Services;
using VocabularyTrainer.WinApp.Presenter;
using VocabularyTrainer.WinApp.View;
using VocabularyTrainer.Domain.Services;
using VocabularyTrainer.Domain.Repositories;
using VocabularyTrainer.DataAccess.Repositories;

namespace VocabularyTrainer.WinApp.Infrastructure.AppStart
{
	internal class DependencyResolver
	{
		public static IServiceCollection ConstructServices()
		{
			var config = ConfigLoader.Load();
			var services = new ServiceCollection();

			services.AddSingleton<IMainFormView, MainForm>();
			services.AddSingleton(sp => (MainForm)sp.GetRequiredService<IMainFormView>());

			services.AddSingleton<IUserRepository>(x => new UserRepository(config.ConnectionString));
			services.AddSingleton<IWordRepository>(x => new WordRepository(config.ConnectionString));

			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IWordsShuffleService, WordsShuffleService>();
			services.AddSingleton<IWordTrainerService>(provider =>
			new WordTrainerService(config.MaxWordWeight, provider.GetRequiredService<IWordRepository>(), provider.GetRequiredService<IWordsShuffleService>()));

			services.AddSingleton<MainFormPresenter>();

			return services;
		}
	}
}
