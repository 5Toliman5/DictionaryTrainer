namespace VocabularyTrainer.WinApp.Infrastructure.AppStart
{
	public class AppConfig
	{
		public string ConnectionString { get; init; }
		public int MaxWordWeight { get; init; }

		public AppConfig(string connectionString, int maxWordWeight)
		{
			ConnectionString = connectionString;
			MaxWordWeight = maxWordWeight;
		}
	}
}
