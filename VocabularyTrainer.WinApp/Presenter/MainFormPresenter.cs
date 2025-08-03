using VocabularyTrainer.Domain.Models;
using VocabularyTrainer.Domain.Services;
using VocabularyTrainer.WinApp.Infrastructure;
using VocabularyTrainer.WinApp.View;

namespace VocabularyTrainer.WinApp.Presenter
{
	public class MainFormPresenter
	{
        private readonly IMainFormView _view;
        private readonly IUserService _userService;
        private readonly IWordTrainerService _wordTrainerService;

        private int? _userId;
		private bool _translationWasShown = false;

		public MainFormPresenter(IMainFormView view, IUserService userService, IWordTrainerService wordTrainerService)
		{
			_view = view;
			_userService = userService;
			_wordTrainerService = wordTrainerService;
			SubscribeToEvents();
		}

		private void SubscribeToEvents()
		{
			_view.UserChanged += OnUserChanged;
			_view.AddWordRequested += OnAddWordRequested;
			_view.ShowNextWordRequested += OnShowNextWordRequested;
			_view.ShowTranslationRequested += OnShowTranslationRequested;
			_view.DeleteWordRequested += OnDeleteWordRequested;
		}

		private void OnUserChanged(object? sender, string userName)
		{
			_userId = _userService.GetUserId(userName);
			if (!ValidateUser()) 
				return;
			_wordTrainerService.SetUser(_userId.Value);
		}

		private void OnAddWordRequested(object? sender, EventArgs e)
        {
			if (!_view.ValidateAddWordInput())
				return;
			
			if (!ValidateUser())
				return;

			var word = new WordDto(_view.InputWord, _view.InputTranslation);
			_wordTrainerService.AddWord(word);
			_view.ClearAddWordInput();
		}

		private void OnShowNextWordRequested(object? sender, EventArgs e)
        {
			_view.ClearShowWordOutput();

			if (!_userId.HasValue)
				return;

			if (!_translationWasShown)
			{
				_wordTrainerService.UpdateCurrentWord(UpdateWeightType.Decrease);
			}
			_translationWasShown = false;

			var word = _wordTrainerService.GetNewWord();
			if (word is null)
			{
				_view.ShowError(Constants.NoWordsFoundError);
				return;
			}

			_view.DisplayNewWord(word.Value);
			_view.SetShowNextButtonText(Constants.DefaultShowNextButtonText);
        }

		private void OnShowTranslationRequested(object? sender, EventArgs e)
        {
            var currentWord = _wordTrainerService.GetCurrentWord();
			if (currentWord is null) 
                return;

			_wordTrainerService.UpdateCurrentWord(UpdateWeightType.Increase);
			_view.DisplayTranslation(currentWord.Translation);
			_view.SetShowNextButtonText(Constants.ChangedShowNextButtonText);
        }

		private void OnDeleteWordRequested(object? sender, EventArgs e)
        {
            if (_wordTrainerService.GetCurrentWord() is null)
                return;
			_wordTrainerService.DeleteCurrentWord();
		}

		private bool ValidateUser()
		{
			if (!_userId.HasValue)
			{
				_view.ShowError("User has not been found!");
				return false;
			}
			return true;
		}
    }
}
