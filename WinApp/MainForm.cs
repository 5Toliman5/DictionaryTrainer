using DAL.Data.EF_DAL;
using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinApp.Infrastructure;
using WinApp.Infrastructure.BL;
using WinApp.Infrastructure.FormHandling;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace WinApp
{
    public partial class MainForm : Form
    {
        private readonly BusinessLogic BusinessLogic;
        public MainForm()
        {
            InitializeComponent();
            BusinessLogic = new();
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputTextBoxes(GetAddDataTextBoxes)) return;
                string dictionary = null;
                var word = BusinessLogic.AddNewWordsLogic.CreateWordObject(this.InputWordTextBox.Text, this.InputTranslationTextBox.Text, dictionary, BusinessLogic.CurrentUser.ID);
                var addWordResponse = BusinessLogic.AddNewWordsLogic.AddWordToDictionary(word);
                InputWordTextBox.Text = null;
                InputTranslationTextBox.Text = null;
                if (addWordResponse is null)
                    addWordsErrorProvider.Clear();
                else
                    this.addWordsErrorProvider.SetError((Control)sender, addWordResponse);
            }
            catch (Exception ex)
            {

            }

        }
        private List<TextBox> GetAddDataTextBoxes
        {
            get
            {
                var textboxes = new List<TextBox>
                {
                    this.InputWordTextBox,
                    this.InputTranslationTextBox
                };
                return textboxes;
            }

        }
        private bool CheckInputTextBoxes(List<TextBox> textboxes)
        {
            foreach (var textBox in textboxes)
            {
                if (textBox.Text.IsNullOrEmpty())
                {
                    this.addWordsErrorProvider.SetError(textBox, string.Format(Constants.EmptyInput, textBox.Tag));
                    return false;
                }
            }
            return true;
        }
        private void TextBox_Validating(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!Validator.ValidateTextBoxInput(textBox))
            {
                this.addWordsErrorProvider.SetError(textBox, "Input must contain only letters and digits.");
                textBox.Text = string.Empty;
            }
        }

        private void DisplayNewWord()
        {
            DisplayWordTextBox.Text = string.Empty;
            DisplayTranslationTextBox.Text = string.Empty;
            var word = BusinessLogic.TrainYourselfLogic.GetNewWord();
            if (word != null)
                DisplayWordTextBox.Text = word.Value;
        }
        private void TrainYourselfPage_Enter(object sender, EventArgs e)
        {
            DisplayNewWord();
        }

        private void ShowNextButton_Click(object sender, EventArgs e)
        {
            DisplayNewWord();
            ShowNextButton.Text = Constants.DefaultShowNextButtonText;

        }

        private void ShowTranslationButton_Click(object sender, EventArgs e)
        {
            if (BusinessLogic.TrainYourselfLogic.CurrentWord == null) return;
            BusinessLogic.TrainYourselfLogic.SaveProgress(DAL.Data.Abstract.DatabaseAction.Update);
            DisplayTranslationTextBox.Text = BusinessLogic.TrainYourselfLogic.CurrentWord.Translation;
            ShowNextButton.Text = Constants.ChangedShowNextButtonText;
        }

        private void DeleteWordButton_Click(object sender, EventArgs e)
        {
            if (BusinessLogic.TrainYourselfLogic.CurrentWord == null) return;
            BusinessLogic.TrainYourselfLogic.DeleteWord();
            DisplayNewWord();
        }
    }
}