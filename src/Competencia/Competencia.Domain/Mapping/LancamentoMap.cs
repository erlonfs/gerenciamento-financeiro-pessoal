using Competencias.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competencias.Domain.Mapping
{
	public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
	{
		public void Configure(EntityTypeBuilder<Lancamento> builder)
		{
			builder.ToTable("Lancamento", "COMP");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.EntityId);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.Data);
			builder.Property(x => x.Descricao);
			builder.Property(x => x.IsLancamentoPago);
			builder.Property(x => x.Valor);
			builder.Property(x => x.FormaDePagtoId);
			builder.Property(x => x.Anotacao);

			builder.HasDiscriminator(x => x.Tipo);


		}
	}
}
