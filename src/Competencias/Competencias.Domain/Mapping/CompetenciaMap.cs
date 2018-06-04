using Competencias.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencias.Domain.Mapping
{
	public class CompetenciaMap : IEntityTypeConfiguration<Competencia>
	{
		public void Configure(EntityTypeBuilder<Competencia> builder)
		{
			builder.ToTable("Competencia", "COMP");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.MesInt).HasColumnName("Mes");

			builder.OwnsOne(x => x.Ano, cb =>
			{
				cb.Property(c => c.Numero).HasColumnName("Ano");
			});

			builder.Property(x => x.Saldo);
			builder.Property(x => x.TotalContasAPagar);
			builder.Property(x => x.TotalContasAReceber);

			builder.HasMany(x => x.Lancamentos).WithOne(x => x.Competencia);

		}
	}
}
