
namespace DictionaryTrainer.WinApp.View
{
    public interface IMainFormView
    {
        string InputTranslation { get; }

        string InputWord { get; }

		event EventHandler<string> UserChanged;

		void Clear();

        void ClearOutput();

        void DisplayNewWord(string word);

        void DisplayTranslation(string translation);

        List<TextBox> GetAddDataInputsList();

        void SetNextButtonText(string text);

        void ShowError(string message);

        bool ValidateInput(List<TextBox> textboxes);
    }
}