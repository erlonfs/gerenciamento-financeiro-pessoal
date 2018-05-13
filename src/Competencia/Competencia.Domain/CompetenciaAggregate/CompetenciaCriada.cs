using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class CompetenciaCriada : IDomainEvent
	{
		public Guid AggregateId { get; }
		public CompetenciaAggregateRoot Competencia { get; }
		public DateTime DataCriacao { get; }

		public CompetenciaCriada(Guid aggregateId, CompetenciaAggregateRoot competencia)
		{
			AggregateId = aggregateId;
			Competencia = competencia;
			DataCriacao = DateTime.Now;
		}
	}

}
