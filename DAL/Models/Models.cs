using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.DAL.Models
{
	public record AddWordModel(Word Word, int UserId);

	public record EditWordModel(int WordId, int UserId);
}
