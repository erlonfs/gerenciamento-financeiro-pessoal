using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class CompetenciaCriada : IDomainEvent
	{
		public Competencia Competencia { get; }
		public DateTime DataCriacao { get; }

		public CompetenciaCriada(Competencia competencia)
		{
			Competencia = competencia;
			DataCriacao = DateTime.Now;
		}
	}

}
