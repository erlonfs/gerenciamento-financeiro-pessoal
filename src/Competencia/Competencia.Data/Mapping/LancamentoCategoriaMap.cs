using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencia.Data.Mapping
{
	public class LancamentoCategoriaMap : IEntityTypeConfiguration<Model.LancamentoCategoria>
	{
		public void Configure(EntityTypeBuilder<Model.LancamentoCategoria> builder)
		{
			builder.ToTable("LancamentoCategoria", "COMP");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.EntityId);
			builder.Property(x => x.Id);
			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.Nome);
		}
	}
}
