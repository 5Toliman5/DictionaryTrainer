namespace VocabularyTrainer.WinApp.View
{
    public interface IMainFormView
    {
		event EventHandler<string> UserChanged;

		event EventHandler? AddWordRequested;

		event EventHandler? DeleteWordRequested;

		event EventHandler? ShowNextWordRequested;

		event EventHandler? ShowTranslationRequested;

		string InputTranslation { get; }

        string InputWord { get; }

		void ClearAddWordInput();

        void ClearShowWordOutput();

        void DisplayNewWord(string word);

        void DisplayTranslation(string translation);

        void SetShowNextButtonText(string text);

        void ShowError(string message);

        bool ValidateAddWordInput();
    }
}