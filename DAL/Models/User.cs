﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class User
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public short ID { get; set; }
    [Required, MaxLength(64)]
    public string Name { get; set; } = null!;

    public string? Info { get; set; }
    [Required, MaxLength(32)]
    public string Login { get; set; } = null!;
    [Required, MaxLength(32)]
    public string Password { get; set; } = null!;

    public virtual ICollection<Word> Words { get; } = new List<Word>();
}
