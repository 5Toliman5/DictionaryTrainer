namespace DictionaryTrainer.WinApp.Presenter
{
	public interface IMainFormPresenter
    {
        void AddWord();

        void DisplayNewWord();

        void ShowTranslation();

        void DeleteWord();

		void OnUserChanged(object? sender, string userName);
	}

}
