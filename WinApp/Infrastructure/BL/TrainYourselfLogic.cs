using DAL.Data.Abstract;
using DAL.Data.EF_DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Infrastructure.BL
{
    internal class TrainYourselfLogic
    {
        private readonly IWordsRepository WordsRepository;
        private Random Random;
        public short? UserId { get; set; } = null;
        public List<Word> Words { get; private set; }
        public Word CurrentWord { get; set; } = null;
        public TrainYourselfLogic(string connectionString, short userId) : this(new WordsRepository(connectionString))
        {
            UserId = userId;
        }
        public TrainYourselfLogic(string connectionString) : this(new WordsRepository(connectionString))
        {
        }
        public TrainYourselfLogic(IWordsRepository wordsRepository)
        {
            Random = new();
            WordsRepository = wordsRepository;
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
