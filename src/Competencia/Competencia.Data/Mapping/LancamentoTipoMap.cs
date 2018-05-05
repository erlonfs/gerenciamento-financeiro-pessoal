using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencia.Data.Mapping
{
	public class LancamentoTipoMap : IEntityTypeConfiguration<Model.LancamentoTipo>
	{
		public void Configure(EntityTypeBuilder<Model.LancamentoTipo> builder)
		{
			builder.ToTable("LancamentoTipo", "COMP");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id);
			builder.Property(x => x.Nome);
		}
	}
}
