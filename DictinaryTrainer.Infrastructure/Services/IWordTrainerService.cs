using DictinaryTrainer.BusinessLogic.Models;

namespace DictinaryTrainer.BusinessLogic.Services
{
	public interface IWordTrainerService
	{
		void AddWord(WordDto word);
		void DeleteCurrentWord();
		WordDto? GetCurrentWord();
		WordDto? GetNewWord();
		int LoadAllWords();
		void SetUser(short userId);
		void UpdateCurrentWord();
	}
}