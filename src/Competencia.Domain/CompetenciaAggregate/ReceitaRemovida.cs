using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class ReceitaRemovida : IDomainEvent
	{
		public Receita Receita { get; }
		public DateTime DataCriacao { get; }

		public ReceitaRemovida(Receita receita)
		{
			Receita = receita;
			DataCriacao = DateTime.Now;
		}
	}

}
