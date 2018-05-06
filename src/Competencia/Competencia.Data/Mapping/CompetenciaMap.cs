using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencia.Data.Mapping
{
	public class CompetenciaMap : IEntityTypeConfiguration<Model.Competencia>
	{
		public void Configure(EntityTypeBuilder<Model.Competencia> builder)
		{
			builder.ToTable("Competencia", "COMP");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.EntityId);
			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.Mes);
			builder.Property(x => x.Ano);

			builder.HasMany(x => x.Lancamentos);

		}
	}
}
