using DictionaryTrainer.DAL.EF;
using DictionaryTrainer.DAL.Repositories;
using DictionaryTrainer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            var connString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            services.AddDbContext<DictionaryTrainerContext>(options => options.UseSqlServer(connString));
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddTransient<IWordsRepository, WordsRepository>();

        }
    }
}