using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class ReceitaAlterada : IDomainEvent
	{
		public Receita Receita { get; }
		public DateTime DataCriacao { get; }

		public ReceitaAlterada(Receita receita)
		{
			Receita = receita;
			DataCriacao = DateTime.Now;
		}
	}

}
