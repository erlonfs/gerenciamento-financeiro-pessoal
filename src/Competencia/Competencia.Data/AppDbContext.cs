using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Competencia.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Model.Competencia> Competencia { get; set; }
		public DbSet<Model.Lancamento> Lancamento { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			AddMappingsDynamically(modelBuilder);
		}

		private void AddMappingsDynamically(ModelBuilder modelBuilder)
		{
			var currentAssembly = typeof(AppDbContext).Assembly;
			var mappings = currentAssembly.GetTypes().Where(t => t.FullName.StartsWith("Competencia.Data.Mapping.") && t.FullName.EndsWith("Map"));

			foreach (var map in mappings.Select(Activator.CreateInstance))
			{
				modelBuilder.ApplyConfiguration((dynamic)map);
			}
		}
	}
}
