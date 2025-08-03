using System.Configuration;

namespace VocabularyTrainer.WinApp.Infrastructure.AppStart
{
	public static class ConfigLoader
	{
		public static AppConfig Load()
		{
			var connString = ConfigurationManager.AppSettings["ConnectionString"];
			if (string.IsNullOrEmpty(connString))
				throw new ConfigurationErrorsException("Connection string is not configured.");

			if (!int.TryParse(ConfigurationManager.AppSettings["MaxWordWeight"], out var weight))
				throw new ConfigurationErrorsException("MaxWordWeight is not configured.");

			return new AppConfig(connString, weight);
		}
	}
}
