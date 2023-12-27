using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Models;

namespace SuperHeroWebApi.Data
{
	public class DataContext :DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

		//connection sting
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=.; initial Catalog=superherodb ; User Id=sa; password=1234; TrustServerCertificate= True");
		}

	   public DbSet<SuperHero> SuperHeroes { get; set; }

	}
}
