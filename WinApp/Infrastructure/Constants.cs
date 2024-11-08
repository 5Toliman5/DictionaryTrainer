namespace WinApp.Infrastructure
{
	public static class Constants
    {
        public static string DefaultDbConnection = "default";
        public static string EmptyInput = "Please, enter the {0}.";
        public static string InputTextBoxRegex = @"\b[\p{L}\p{M}'-]+\b";
        public static string DefaultShowNextButtonText = "I remember!";
        public static string ChangedShowNextButtonText = "Next word";
		public static string NoWordsFoundError = "No words have been found for the specified user.";
	}
}
