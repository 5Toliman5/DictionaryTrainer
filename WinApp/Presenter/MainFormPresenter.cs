using Common.Extensions;
using DictinaryTrainer.BusinessLogic.Models;
using DictinaryTrainer.BusinessLogic.Services.Abstract;
using DictionaryTrainer.WinApp.View;
using WinApp.Infrastructure;

namespace DictionaryTrainer.WinApp.Presenter
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView View;
        private readonly IUserService UserService;
        private readonly IWordTrainerService WordTrainerService;
        private short? UserId;
		public MainFormPresenter(IMainFormView view, IUserService userService, IWordTrainerService wordTrainerService)
		{
			View = view;
			UserService = userService;
			WordTrainerService = wordTrainerService;
		}
		public void OnUserChanged(object? sender, string userName)
		{
			UserId = UserService.GetUserId(userName);
			if (!ValidateUser()) 
				return;
			WordTrainerService.SetUser(UserId.Value);
		}

		public void AddWord()
        {
			if (!View.ValidateInput(View.GetAddDataInputsList()))
				return;
			
			if (!ValidateUser())
				return;
			var word = new WordDto(View.InputWord, View.InputTranslation);
			WordTrainerService.AddWord(word);
			View.Clear();
		}
        public void DisplayNewWord()
        {
			View.ClearOutput();
			if (!UserId.HasValue)
				return;
            var wordsCount = WordTrainerService.LoadAllWords();
            if (wordsCount == 0)
                View.ShowError(Constants.NoWordsFoundError);

			var word = WordTrainerService.GetNewWord();
            if (word is not null)
				View.DisplayNewWord(word.Value);
			View.SetNextButtonText(Constants.DefaultShowNextButtonText);
        }
        public void ShowTranslation()
        {
            var currentWord = WordTrainerService.GetCurrentWord();

			if (currentWord is null) 
                return;
			WordTrainerService.UpdateCurrentWord();
			View.DisplayTranslation(currentWord.Translation);
			View.SetNextButtonText(Constants.ChangedShowNextButtonText);
        }
        public void DeleteWord()
        {
            if (WordTrainerService.GetCurrentWord() is null)
                return;
			WordTrainerService.DeleteCurrentWord();
			DisplayNewWord();
        }
		private bool ValidateUser()
		{
			if (!UserId.HasValue)
			{
				View.ShowError("User has not been found!");
				return false;
			}
			return true;
		}
    }
}
