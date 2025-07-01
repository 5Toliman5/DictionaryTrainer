using DictionaryTrainer.Domain.Models;
using DictionaryTrainer.Domain.Services;
using DictionaryTrainer.WinApp.View;
using WinApp.Infrastructure;

namespace DictionaryTrainer.WinApp.Presenter
{
	public class MainFormPresenter
	{
        private readonly IMainFormView View;
        private readonly IUserService UserService;
        private readonly IWordTrainerService WordTrainerService;
        private int? UserId;

		public MainFormPresenter(IMainFormView view, IUserService userService, IWordTrainerService wordTrainerService)
		{
			View = view;
			UserService = userService;
			WordTrainerService = wordTrainerService;
			SubscribeToEvents();
		}

		private void SubscribeToEvents()
		{
			View.UserChanged += OnUserChanged;
			View.AddWordRequested += OnAddWordRequested;
			View.ShowNextWordRequested += OnShowNextWordRequested;
			View.ShowTranslationRequested += OnShowTranslationRequested;
			View.DeleteWordRequested += OnDeleteWordRequested;
		}

		private void OnUserChanged(object? sender, string userName)
		{
			UserId = UserService.GetUserId(userName);
			if (!ValidateUser()) 
				return;
			WordTrainerService.SetUser(UserId.Value);
		}

		private void OnAddWordRequested(object? sender, EventArgs e)
        {
			if (!View.ValidateAddWordInput())
				return;
			
			if (!ValidateUser())
				return;

			var word = new WordDto(View.InputWord, View.InputTranslation);
			WordTrainerService.AddWord(word);
			View.ClearAddWordInput();
		}

		private void OnShowNextWordRequested(object? sender, EventArgs e)
        {
			View.ClearShowWordOutput();
			if (!UserId.HasValue)
				return;

			var word = WordTrainerService.GetNewWord();
			if (word is null)
			{
				View.ShowError(Constants.NoWordsFoundError);
				return;
			}

			View.DisplayNewWord(word.Value);
			View.SetShowNextButtonText(Constants.DefaultShowNextButtonText);
        }

		private void OnShowTranslationRequested(object? sender, EventArgs e)
        {
            var currentWord = WordTrainerService.GetCurrentWord();

			if (currentWord is null) 
                return;
			WordTrainerService.UpdateCurrentWord();
			View.DisplayTranslation(currentWord.Translation);
			View.SetShowNextButtonText(Constants.ChangedShowNextButtonText);
        }

		private void OnDeleteWordRequested(object? sender, EventArgs e)
        {
            if (WordTrainerService.GetCurrentWord() is null)
                return;
			WordTrainerService.DeleteCurrentWord();
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
