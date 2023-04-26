using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.FormHandling
{
    internal static class Validator
    {
        public static bool ValidateTextBoxInput(TextBox textBox)
        {
            var regex = new Regex(Constants.InputTextBoxRegex);
            if (string.IsNullOrEmpty(textBox.Text)) return true;
            return regex.IsMatch(textBox.Text);
        }
    }
}
