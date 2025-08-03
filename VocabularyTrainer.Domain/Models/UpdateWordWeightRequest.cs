namespace VocabularyTrainer.Domain.Models
{
	public record UpdateWordWeightRequest(int WordId, int UserId, UpdateWeightType Type) : EditWordRequest(WordId, UserId)
	{
		public string Operator => Type switch
		{
			UpdateWeightType.Increase => "+",
			UpdateWeightType.Decrease => "-",
			_ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Word weight can be eigher increased or decreased.")
		};
	}

	public enum UpdateWeightType
	{
		Increase,
		Decrease
	}
}
