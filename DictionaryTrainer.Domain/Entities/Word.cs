using System.ComponentModel.DataAnnotations;
namespace DictionaryTrainer.Domain.Entities;

public class Word : EntityBase
{
    [Required, MaxLength(100)]
    public string Value { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Translation { get; set; } = null!;

    public override bool Equals(object? obj) => obj is Word word && word.ID == ID;

	public override int GetHashCode() => ID.GetHashCode();
}
