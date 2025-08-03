using System.Text.RegularExpressions;
using VocabularyTrainer.WinApp.Infrastructure;

namespace VocabularyTrainer.WinApp.Infrastructure.Validation
{
    internal static class MainFormValidator
    {
        public static bool ValidateTextBoxInput(TextBox textBox)
        {
            var regex = new Regex(Constants.InputTextBoxRegex);
            if (string.IsNullOrEmpty(textBox.Text)) return true;
            return regex.IsMatch(textBox.Text);
        }
    }
}
