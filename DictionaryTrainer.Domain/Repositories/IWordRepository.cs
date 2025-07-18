using DictionaryTrainer.Domain.Entities;
using DictionaryTrainer.Domain.Models;

namespace DictionaryTrainer.Domain.Abstract
{
	public interface IWordRepository
	{
		List<Word> GetAllWords(int userId);

		void AddWord(AddWordModel model);

		void DeleteWord(EditWordModel model);

		void UpdateWordWeight(EditWordModel model);
	}
}
