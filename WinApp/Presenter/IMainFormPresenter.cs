using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTrainer.WinApp.Presenter
{
    internal interface IMainFormPresenter
    {
        void AddWord();
        void DisplayNewWord();
        void ShowTranslation();
        void DeleteWord();
        void Initialize();
    }

}
