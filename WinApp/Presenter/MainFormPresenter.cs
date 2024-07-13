using DictionaryTrainer.WinApp.Infrastructure.BusinessLogic;
using DictionaryTrainer.WinApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Infrastructure;

namespace DictionaryTrainer.WinApp.Presenter
{
    internal class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView _view;
        private readonly WordsUnitOfWork _wordsUnitOfWork;

        public MainFormPresenter(IMainFormView view, WordsUnitOfWork wordsUnitOfWork)
        {
            _view = view;
            _wordsUnitOfWork = wordsUnitOfWork;
        }
        public void Initialize()
        {
            DisplayNewWord();
        }
        public void AddWord()
        {
            try
            {
                if (!_view.ValidateInput(_view.GetAddDataInputsList()))
                {
                    return;
                }
                var word = _wordsUnitOfWork.AddNewWordsManager.CreateWordObject(_view.InputWord, _view.InputTranslation, _wordsUnitOfWork.CurrentUser.ID);
                _wordsUnitOfWork.AddNewWordsManager.AddWordToDictionary(word);
                _view.ClearInput();
            }
            catch (Exception ex)
            {
                _view.ShowError($"An error occurred: {ex.Message}");
            }
        }
        public void DisplayNewWord()
        {
            _view.ClearOutput();
            var word = _wordsUnitOfWork.TrainYourselfManager.GetNewWord();
            if (word != null)
            {
                _view.DisplayNewWord(word.Value);
            }
            _view.SetNextButtonText(Constants.DefaultShowNextButtonText);
        }
        public void ShowTranslation()
        {
            if (_wordsUnitOfWork.TrainYourselfManager.CurrentWord == null) return;
            _wordsUnitOfWork.TrainYourselfManager.UpdateCurrentWord();
            _view.DisplayTranslation(_wordsUnitOfWork.TrainYourselfManager.CurrentWord.Translation);
            _view.SetNextButtonText(Constants.ChangedShowNextButtonText);
        }
        public void DeleteWord()
        {
            if (_wordsUnitOfWork.TrainYourselfManager.CurrentWord == null) return;
            _wordsUnitOfWork.TrainYourselfManager.DeleteCurrentWord();
            DisplayNewWord();
        }
    }
}
