using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure
{
    public static class Constants
    {
        public static string DefaultDbConnection = "default";
        public static string EmptyInput = "Please, enter the {0}.";
        public static string InputTextBoxRegex = @"\b[\p{L}\p{M}'-]+\b";
        public static string DefaultShowNextButtonText = "I remember!";
        public static string ChangedShowNextButtonText = "Show the next word";
    }
}
