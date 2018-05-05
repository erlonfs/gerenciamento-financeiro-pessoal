using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competencia.Data.Mapping
{
	public class FormaPagtoMap : IEntityTypeConfiguration<Model.FormaPagto>
	{
		public void Configure(EntityTypeBuilder<Model.FormaPagto> builder)
		{
			builder.ToTable("FormaPagto", "COMP");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id);
			builder.Property(x => x.Nome);
		}
	}
}
