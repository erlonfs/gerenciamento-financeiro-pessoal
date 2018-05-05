using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class DespesaRemovida : IDomainEvent
	{
		public Despesa Despesa { get; }
		public DateTime DataCriacao { get; }

		public DespesaRemovida(Despesa despesa)
		{
			Despesa = despesa;
			DataCriacao = DateTime.Now;
		}
	}

}
