using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.EF_DAL;

public partial class DictionaryTrainerContext : DbContext
{
    private string _connectionString;
    public DictionaryTrainerContext(string connectionString) : this(new DbContextOptions<DictionaryTrainerContext>())
    {
        _connectionString = connectionString;
    }

    private DictionaryTrainerContext(DbContextOptions<DictionaryTrainerContext> options)
        : base(options)
    {
    }
    //public DictionaryTrainerContext()
    //{
        
    //}
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Words)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

    }
}

