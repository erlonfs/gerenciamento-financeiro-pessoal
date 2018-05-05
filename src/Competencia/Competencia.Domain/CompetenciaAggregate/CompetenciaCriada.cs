using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class CompetenciaCriada : IDomainEvent
	{
		public CompetenciaAggregateRoot Competencia { get; }
		public DateTime DataCriacao { get; }

		public CompetenciaCriada(CompetenciaAggregateRoot competencia)
		{
			Competencia = competencia;
			DataCriacao = DateTime.Now;
		}
	}

}
