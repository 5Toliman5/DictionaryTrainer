using DictionaryTrainer.Domain.Services;
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

		public bool ValidateInput(List<TextBox> textboxes)
		{
			foreach (var textBox in textboxes)
			{
				if (textBox.Text.IsNullOrEmpty())
				{
					AddWordsErrorProvider.SetError(textBox, string.Format(Constants.EmptyInput, textBox.Tag));
					return false;
				}
			}
			return true;
		}

		public void Clear()
		{
			InputWordTextBox.Text = string.Empty;
			InputTranslationTextBox.Text = string.Empty;
			AddWordsErrorProvider.Clear();

		}

		public void ClearOutput()
		{
			DisplayWordTextBox.Text = string.Empty;
			DisplayTranslationTextBox.Text = string.Empty;
		}

		public string InputWord => InputWordTextBox.Text;

		public string InputTranslation => InputTranslationTextBox.Text;

		public List<TextBox> GetAddDataInputsList() => [InputWordTextBox, InputTranslationTextBox];

		public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		public void DisplayNewWord(string word) => DisplayWordTextBox.Text = word;

		public void DisplayTranslation(string translation) => DisplayTranslationTextBox.Text = translation;

		public void SetNextButtonText(string text) => ShowNextButton.Text = text;

		private void SetUserOnInitialize()
		{
			var userName = CurrentUserTextBox.Text;
			if (!string.IsNullOrEmpty(userName))
				UserChanged.Invoke(this, userName);
		}

		private void TextBox_Validating(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			if (!MainFormValidator.ValidateTextBoxInput(textBox))
			{
				AddWordsErrorProvider.SetError(textBox, "Input must contain only letters and digits.");
				textBox.Text = string.Empty;
			}
		}

		private void AddDataButton_Click(object sender, EventArgs e) => Presenter.AddWord();

		private void TrainYourselfPage_Enter(object sender, EventArgs e) => Presenter.DisplayNewWord();

		private void ShowNextButton_Click(object sender, EventArgs e) => Presenter.DisplayNewWord();

		private void ShowTranslationButton_Click(object sender, EventArgs e) => Presenter.ShowTranslation();

		private void DeleteWordButton_Click(object sender, EventArgs e) => Presenter.DeleteWord();

		private void InputTranslationTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode is Keys.Down or Keys.Up)
			{
				InputWordTextBox.Focus();
				e.Handled = true;
			}
		}

		private void InputWordTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode is Keys.Down or Keys.Up)
			{
				InputTranslationTextBox.Focus();
				e.Handled = true;
			}
		}

		private void DisplayWordTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode is Keys.Down or Keys.Up)
			{
				DisplayTranslationTextBox.Focus();
				e.Handled = true;
			}
		}

		private void DisplayTranslationTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode is Keys.Down or Keys.Up)
			{
				DisplayWordTextBox.Focus();
				e.Handled = true;
			}
		}
	}
}