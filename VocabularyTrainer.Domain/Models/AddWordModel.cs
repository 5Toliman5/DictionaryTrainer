using VocabularyTrainer.Domain.Entities;

namespace VocabularyTrainer.Domain.Models
{
	public record AddWordModel(Word Word, int UserId);
}
