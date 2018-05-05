using Competencia.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Competencia.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Model.Competencia> Competencia { get; set; }
		public DbSet<Model.Lancamento> Lancamento { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Data Source=10.0.75.1;Initial Catalog=GerenciamentoFinanceiro;User Id=SA;Password=GuiGui@2016;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CompetenciaMap());
			modelBuilder.ApplyConfiguration(new LancamentoMap());
		}
	}
}
