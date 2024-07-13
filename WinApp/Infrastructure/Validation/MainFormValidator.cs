using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinApp.Infrastructure;

namespace DictionaryTrainer.WinApp.Infrastructure.Validation
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
