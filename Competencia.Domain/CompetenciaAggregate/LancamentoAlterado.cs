using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class LancamentoAlterado : IDomainEvent
	{
		public Lancamento Lancamento { get; }
		public DateTime DataCriacao { get; }

		public LancamentoAlterado(Lancamento lancamento)
		{
			Lancamento = lancamento;
			DataCriacao = DateTime.Now;
		}
	}

}
