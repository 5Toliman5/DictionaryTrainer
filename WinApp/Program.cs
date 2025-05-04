using DictionaryTrainer.WinApp;
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
			var services = DependencyResolver.ConstructServices();
			using var serviceProvider = services.BuildServiceProvider();
			var mainForm = serviceProvider.GetRequiredService<MainForm>();
			Application.Run(mainForm);
		}
	}
}