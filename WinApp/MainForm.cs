using DictinaryTrainer.BusinessLogic.Services.Abstract;
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
		private readonly IMainFormPresenter Presenter;
		public event EventHandler<string> UserChanged;
		public MainForm(IUserService userService, IWordTrainerService wordTrainerService)
		{
			Presenter = new MainFormPresenter(this, userService, wordTrainerService);
			UserChanged = Presenter.OnUserChanged;
			InitializeComponent();
			SetUserOnInitialize();
		}
		public string InputWord => this.InputWordTextBox.Text;
		public string InputTranslation => this.InputTranslationTextBox.Text;
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
		private void SetUserOnInitialize()
		{
			var userName = this.CurrentUserTextBox.Text;
			if (!string.IsNullOrEmpty(userName))
				UserChanged.Invoke(this, userName);
		}
		private void AddDataButton_Click(object sender, EventArgs e)
		{
			Presenter.AddWord();
		}
		private void TrainYourselfPage_Enter(object sender, EventArgs e)
		{
			Presenter.DisplayNewWord();
		}
		private void ShowNextButton_Click(object sender, EventArgs e)
		{
			Presenter.DisplayNewWord();
		}
		private void ShowTranslationButton_Click(object sender, EventArgs e)
		{
			Presenter.ShowTranslation();
		}
		private void DeleteWordButton_Click(object sender, EventArgs e)
		{
			Presenter.DeleteWord();
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
		private void CreateUserButton_Click(object sender, EventArgs e)
		{

		}
		private void DeleteUserButton_Click(object sender, EventArgs e)
		{

		}
	}
}