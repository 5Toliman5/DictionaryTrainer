using DictionaryTrainer.WinApp;
using DictionaryTrainer.WinApp.Presenter;
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
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ApplicationConfiguration.Initialize();

			var services = DependencyResolver.ConstructServices();
			using var serviceProvider = services.BuildServiceProvider();
			var mainForm = serviceProvider.GetRequiredService<MainForm>();
			var presenter = serviceProvider.GetRequiredService<MainFormPresenter>();

			Application.Run(mainForm);
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) => ShowGlobalExceptionMessage();

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) => ShowGlobalExceptionMessage();

		private static void ShowGlobalExceptionMessage()
		{
			MessageBox.Show(
				$"An unexpected error occurred. Please, try reloading the application.",
				"Application Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
		}
	}
}