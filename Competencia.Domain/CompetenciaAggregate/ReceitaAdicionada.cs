using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class ReceitaAdicionada : IDomainEvent
	{
		public Receita Receita { get; }
		public DateTime DataCriacao { get; }

		public ReceitaAdicionada(Receita receita)
		{
			Receita = receita;
			DataCriacao = DateTime.Now;
		}
	}

}
