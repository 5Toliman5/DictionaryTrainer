using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DAL.Models;

public class Word
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
