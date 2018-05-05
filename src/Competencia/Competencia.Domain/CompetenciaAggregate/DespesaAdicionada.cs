using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class DespesaAdicionada : IDomainEvent
	{
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaAdicionada(Despesa despesa)
		{
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
