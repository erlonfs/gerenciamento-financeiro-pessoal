using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencia.Data.Mapping
{
	public class LancamentoMap : IEntityTypeConfiguration<Model.Lancamento>
	{
		public void Configure(EntityTypeBuilder<Model.Lancamento> builder)
		{
			builder.ToTable("Lancamento", "COMP");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.DataCriacao);
			builder.HasOne(x => x.Competencia);
		}
	}
}
