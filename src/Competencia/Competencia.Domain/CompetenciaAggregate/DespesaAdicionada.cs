using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class DespesaAdicionada : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaAdicionada(Guid aggregateId, Despesa despesa)
		{
			AggregateId = aggregateId;
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
