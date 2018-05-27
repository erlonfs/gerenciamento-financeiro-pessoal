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
			builder.Property(x => x.Mes);
			builder.Property(x => x.Ano);

			builder.HasMany(x => x.Lancamentos);

		}
	}
}
