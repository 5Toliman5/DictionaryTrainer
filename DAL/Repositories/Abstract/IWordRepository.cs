using DictionaryTrainer.DAL.Models;
using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.DAL.Repositories.Abstract
{
	public interface IWordRepository
	{
		List<Word> GetAllWords(int userId);

		void AddWord(AddWordModel model);

		void DeleteWord(EditWordModel model);

		void UpdateWordWeight(EditWordModel model);
	}
}
