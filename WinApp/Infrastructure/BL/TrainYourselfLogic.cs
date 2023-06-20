using DAL.Data.Abstract;
using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Infrastructure.BL.Abstract;

namespace WinApp.Infrastructure.BL
{
    internal class TrainYourselfLogic : AbstractBusinessLogic
    {
        private Random Random;
        public Word CurrentWord { get; set; } = null;
        public TrainYourselfLogic(string connectionString, short? userId) : this(new WordsRepository(connectionString), userId)
        {
        }
        public TrainYourselfLogic(IWordsRepository wordsRepository, short? userId) : base(wordsRepository, userId)
        {
            Random = new();
            LoadAllWords();
        }
        public void LoadAllWords()
        {
            try
            {
                if (UserId != null)
                    Words = WordsRepository.GetAllWords(UserId.Value);
            }
            catch (Exception ex)
            {
                
            }
        }

        public Word GetNewWord()
        {
            if (CurrentWord != null) Words.Remove(CurrentWord);
            if (Words == null || !Words.Any())
            {
                LoadAllWords();
                if (Words == null || !Words.Any())
                    return null;

            }
            return CurrentWord = Words[Random.Next(Words.Count)];

        }
        public void DeleteWord()
        {
            try
            {
                SaveProgress(DatabaseAction.Delete);
                Words.Remove(CurrentWord);
                CurrentWord = null;
            }
            catch(Exception ex)
            {

            }
        }
        public void SaveProgress(DatabaseAction action)
        {
            try
            {
                if (action == DatabaseAction.Update)
                    CurrentWord.Weight++;
                WordsRepository.SaveProgress(CurrentWord, action);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
