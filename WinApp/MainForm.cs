using DictionaryTrainer.Domain.Repositories;
using DictionaryTrainer.WinApp.Infrastructure.BusinessLogic;
using DictionaryTrainer.WinApp.Infrastructure.Validation;
using DictionaryTrainer.WinApp.Presenter;
using DictionaryTrainer.WinApp.View;
using Microsoft.IdentityModel.Tokens;
using WinApp.Infrastructure;
using TextBox = System.Windows.Forms.TextBox;

namespace WinApp
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly IMainFormPresenter _presenter;
		public string InputWord => this.InputWordTextBox.Text;
		public string InputTranslation => this.InputTranslationTextBox.Text;
		public MainForm(IWordsRepository wordsRepository, IAuthenticationRepository authenticationRepository)
        {
            InitializeComponent();
            var userName = UserNameTextBox.Text;
            var wordsUnitOfWork = new WordsUnitOfWork(authenticationRepository, wordsRepository, userName);
			_presenter = new MainFormPresenter(this, wordsUnitOfWork);
			_presenter.Initialize();
        }
        public List<TextBox> GetAddDataInputsList()
        {
            return new List<TextBox>
            {
                this.InputWordTextBox,
                this.InputTranslationTextBox
            };
        }
        public bool ValidateInput(List<TextBox> textboxes)
        {
            foreach (var textBox in textboxes)
            {
                if (textBox.Text.IsNullOrEmpty())
                {
                    this.AddWordsErrorProvider.SetError(textBox, string.Format(Constants.EmptyInput, textBox.Tag));
                    return false;
                }
            }
            return true;
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Clear()
        {
            this.InputWordTextBox.Text = string.Empty;
			this.InputTranslationTextBox.Text = string.Empty;
			this.AddWordsErrorProvider.Clear();

		}
        public void ClearOutput()
        {
            this.DisplayWordTextBox.Text = string.Empty;
			this.DisplayTranslationTextBox.Text = string.Empty;
        }
        public void DisplayNewWord(string word)
        {
			this.DisplayWordTextBox.Text = word;
        }
        public void DisplayTranslation(string translation)
        {
            this.DisplayTranslationTextBox.Text = translation;
        }
        public void SetNextButtonText(string text)
        {
            this.ShowNextButton.Text = text;
        }
        private void AddDataButton_Click(object sender, EventArgs e)
        {
            _presenter.AddWord();
        }
        private void TrainYourselfPage_Enter(object sender, EventArgs e)
        {
            _presenter.DisplayNewWord();
        }
        private void ShowNextButton_Click(object sender, EventArgs e)
        {
            _presenter.DisplayNewWord();
        }
        private void ShowTranslationButton_Click(object sender, EventArgs e)
        {
            _presenter.ShowTranslation();
        }
        private void DeleteWordButton_Click(object sender, EventArgs e)
        {
            _presenter.DeleteWord();
        }
        private void TextBox_Validating(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!MainFormValidator.ValidateTextBoxInput(textBox))
            {
                this.AddWordsErrorProvider.SetError(textBox, "Input must contain only letters and digits.");
                textBox.Text = string.Empty;
            }
        }
    }
}