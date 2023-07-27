using DAL.Data.Abstract;
using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinApp.Infrastructure.BL.Abstract;

namespace WinApp.Infrastructure.BL
{
    internal class AddNewWordsLogic : AbstractBusinessLogic
    {
        public AddNewWordsLogic(string connectionString, short? userId) : base(new WordsRepository(connectionString), userId)
        { 
            if (userId.HasValue)
            {
                this.Words = this.WordsRepository.GetAllWords(userId.Value);
            }
        }
        public string AddWordToDictionary(Word word)
        {
            try
            {
                if (this.Words.Any(x => x.Value == word.Value))
                    return "You have already had this word!";
                WordsRepository.InsertWord(word);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Word CreateWordObject(string value, string traslation, string dictionary, short userId)
        {
            return new Word()
            {
                Value = value,
                Translation = traslation,
                Dictionary = dictionary,
                UserId = userId
            };
        }
    }
}
