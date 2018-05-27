using System;
using SharedKernel.Common;

namespace Competencias.Domain.Aggregates
{
	public class DespesaRemovida : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaRemovida(Guid aggregateId, Despesa despesa)
		{
			AggregateId = aggregateId;
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
