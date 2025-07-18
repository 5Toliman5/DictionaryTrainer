using DictionaryTrainer.Domain.Entities;

namespace DictionaryTrainer.Domain.Models
{
	public record AddWordModel(Word Word, int UserId);
}
