using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class LancamentoRemovido : IDomainEvent
	{
		public Lancamento Lancamento { get; }
		public DateTime DataCriacao { get; }

		public LancamentoRemovido(Lancamento lancamento)
		{
			Lancamento = lancamento;
			DataCriacao = DateTime.Now;
		}
	}

}
