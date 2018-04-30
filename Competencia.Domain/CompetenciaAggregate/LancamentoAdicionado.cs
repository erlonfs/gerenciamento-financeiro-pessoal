using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class LancamentoAdicionado : IDomainEvent
	{
		public Lancamento Lancamento { get; }
		public DateTime DataCriacao { get; }

		public LancamentoAdicionado(Lancamento lancamento)
		{
			Lancamento = lancamento;
			DataCriacao = DateTime.Now;
		}
	}

}
