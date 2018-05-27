using System;
using SharedKernel.Common;

namespace Competencias.Domain.Aggregates
{
	public class ReceitaRemovida : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Receita Receita { get; }
		public DateTime DataCriacao { get; }

		public ReceitaRemovida(Guid aggregateId, Receita receita)
		{
			AggregateId = aggregateId;
			Receita = receita;
			DataCriacao = DateTime.Now;
		}
	}

}
