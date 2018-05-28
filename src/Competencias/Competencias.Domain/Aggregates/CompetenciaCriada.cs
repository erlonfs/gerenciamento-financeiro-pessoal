using System;
using SharedKernel.Common;

namespace Competencias.Domain.Aggregates
{
	public class CompetenciaCriada : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Competencia Competencia { get; }
		public DateTime DataCriacao { get; }

		public CompetenciaCriada(Guid aggregateId, Competencia competencia)
		{
			AggregateId = aggregateId;
			Competencia = competencia;
			DataCriacao = DateTime.Now;
		}
	}

}
