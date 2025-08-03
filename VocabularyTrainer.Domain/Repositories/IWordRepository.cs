using VocabularyTrainer.Domain.Models;

namespace VocabularyTrainer.Domain.Repositories
{
	public interface IWordRepository
	{
		List<WordDto> GetAllWords(int userId);

		void AddWord(AddWordRequest request);

		void DeleteWord(EditWordRequest request);

		void UpdateWordWeight(UpdateWordWeightRequest request);
	}
}
