using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DictionaryTrainer.Domain.Entities;

public class Word
{
    [Key]
    public int ID { get; set; }
    [Required, MaxLength(100)]
    public string Value { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Translation { get; set; } = null!;
    [MaxLength(64)]
    public string? Dictionary { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
    [Required]
    public short UserId { get; set; }
    [Required]
    public ushort Weight { get; set; } = 0;

}
