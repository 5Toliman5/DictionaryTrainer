namespace VocabularyTrainer.WinApp.Infrastructure
{
	public static class Constants
    {
        public const string DefaultDbConnection = "default";
        public const string EmptyInput = "Please, enter the {0}.";
        public const string InputTextBoxRegex = @"\b[\p{L}\p{M}'-]+\b";
        public const string DefaultShowNextButtonText = "I remember!";
        public const string ChangedShowNextButtonText = "Next word";
		public const string NoWordsFoundError = "No words have been found for the specified user.";
	}
}
