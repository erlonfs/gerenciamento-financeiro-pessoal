using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class DespesaAlterada : IDomainEvent
	{
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaAlterada(Despesa despesa)
		{
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
