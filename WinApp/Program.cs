using DictinaryTrainer.BusinessLogic.Services;
using DictinaryTrainer.BusinessLogic.Services.Abstract;
using DictionaryTrainer.DAL.Repositories;
using DictionaryTrainer.DAL.Repositories.Abstract;
using DictionaryTrainer.WinApp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WinApp;

namespace WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            using var serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainForm>();

            var connString = ConfigurationManager.AppSettings["ConnectionString"];
			services.AddScoped<IUserRepository>(x => new UserRepository(connString));
			services.AddScoped<IWordRepository>(x => new WordRepository(connString));

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IWordTrainerService, WordTrainerService>();
			services.AddScoped<IMainFormPresenter, MainFormPresenter>();
		}
    }
}