using DictionaryTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DictionaryTrainer.DAL.EF
{
	public interface IDictionaryTrainerContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Word> Words { get; set; }

		int SaveChanges();
	}
}