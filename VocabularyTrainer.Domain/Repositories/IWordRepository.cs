using VocabularyTrainer.Domain.Entities;
using VocabularyTrainer.Domain.Models;

namespace VocabularyTrainer.Domain.Repositories
{
	public interface IWordRepository
	{
		List<Word> GetAllWords(int userId);

		void AddWord(AddWordModel model);

		void DeleteWord(EditWordModel model);

		void UpdateWordWeight(EditWordModel model);
	}
}
