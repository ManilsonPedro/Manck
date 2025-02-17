using Manck.Models;
using Microsoft.EntityFrameworkCore;

namespace Manck.Data
{
	public class ManckDbContext : DbContext
	{

		public ManckDbContext(DbContextOptions<ManckDbContext> options) : base(options)
		{ 
		
		
		}

		public DbSet<AutorModels> Autor { get; set; }
		public DbSet<LivroModels> Livro { get; set; }
	}
}
