using DAL.Data.Abstract;
using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.BL
{
    internal class AddNewWordsLogic
    {
        private readonly IWordsRepository WordsRepository;

        public AddNewWordsLogic(string connectionString) : this(new WordsRepository(connectionString))
        {
            
        }
        public AddNewWordsLogic(IWordsRepository wordsRepository)
        {
            WordsRepository = wordsRepository;
        }
        public void AddWordToDictionary(Word word)
        {
            try
            {
                WordsRepository.InsertWord(word);
            }
            catch (Exception ex)
            {

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
