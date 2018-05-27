using System;
using SharedKernel.Common;

namespace Competencias.Domain.Aggregates
{
	public class DespesaAlterada : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaAlterada(Guid aggregateId, Despesa despesa)
		{
			AggregateId = aggregateId;
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
