using DictionaryTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DictionaryTrainer.DAL.EF;

public partial class DictionaryTrainerContext : DbContext, IDictionaryTrainerContext
{
	public DictionaryTrainerContext(DbContextOptions<DictionaryTrainerContext> options)
		: base(options)
	{
	}
	public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<Word> Words { get; set; }
	// For EF Migrations
	//public DictionaryTrainerContext(){}
	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//=> optionsBuilder.UseSqlServer("Server=localhost;Database=DictionaryTrainer;User Id=DTLogin ;Password=DTPass;Trusted_Connection=True;TrustServerCertificate=True;");

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

