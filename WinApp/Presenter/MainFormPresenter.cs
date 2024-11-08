using Common.Extensions;
using DictionaryTrainer.WinApp.BusinessLogic;
using DictionaryTrainer.WinApp.View;
using WinApp.Infrastructure;

namespace DictionaryTrainer.WinApp.Presenter
{
    internal class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView View;
        private readonly IWordsUnitOfWork WordsUnitOfWork;

        public MainFormPresenter(IMainFormView view, IWordsUnitOfWork wordsUnitOfWork)
        {
			View = view;
			WordsUnitOfWork = wordsUnitOfWork;
        }
        public void Initialize()
        {
			DisplayNewWord();
        }
        public void AddWord()
        {
            try
            {
                if (!View.ValidateInput(View.GetAddDataInputsList()))
                {
                    return;
                }
                var word = WordsUnitOfWork.AddNewWordsManager.CreateWordObject(View.InputWord, View.InputTranslation, WordsUnitOfWork.CurrentUser.ID);
				WordsUnitOfWork.AddNewWordsManager.AddWordToDictionary(word);
				View.Clear();
            }
            catch (Exception ex)
            {
				View.ShowError($"An error occurred: {ex.Message}");
            }
        }
        public void DisplayNewWord()
        {
			View.ClearOutput();

            WordsUnitOfWork.TrainYourselfManager.LoadAllWords();
            if (WordsUnitOfWork.TrainYourselfManager.Words.IsNullOrEmpty())
                View.ShowError(Constants.NoWordsFoundError);

			var word = WordsUnitOfWork.TrainYourselfManager.GetNewWord();
            if (word is not null)
				View.DisplayNewWord(word.Value);
			View.SetNextButtonText(Constants.DefaultShowNextButtonText);
        }
        public void ShowTranslation()
        {
            if (WordsUnitOfWork.TrainYourselfManager.CurrentWord == null) return;
			WordsUnitOfWork.TrainYourselfManager.UpdateCurrentWord();
			View.DisplayTranslation(WordsUnitOfWork.TrainYourselfManager.CurrentWord.Translation);
			View.SetNextButtonText(Constants.ChangedShowNextButtonText);
        }
        public void DeleteWord()
        {
            if (WordsUnitOfWork.TrainYourselfManager.CurrentWord == null) return;
			WordsUnitOfWork.TrainYourselfManager.DeleteCurrentWord();
			DisplayNewWord();
        }
    }
}
