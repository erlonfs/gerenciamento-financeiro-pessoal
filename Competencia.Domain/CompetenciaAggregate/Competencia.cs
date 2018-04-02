using SharedKernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class Competencia : Entity<Guid>
	{
		public Ano Ano { get; private set; }
		public Mes Mes { get; private set; }

		public Decimal TotalContasAPagar { get; private set; }
		public Decimal TotalContasAReceber { get; private set; }
		public Decimal Saldo { get; private set; }

		private List<Lancamento> _lancamentos = new List<Lancamento>();
		public IReadOnlyList<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

		public Competencia(Guid id, Ano ano, Mes mes, List<Lancamento> lancamentos) : base(id)
		{
			Ano = ano;
			Mes = mes;

			_lancamentos = lancamentos;
			AtualizarSaldos();
		}

		public void AdicionarLancamento(Lancamento lancamento)
		{
			_lancamentos.Add(lancamento);

			AtualizarSaldos();
			//Raise Domain Event
		}

		public void AlterarLancamento(Lancamento lancamento)
		{
			var lancamentoAlterar = _lancamentos.SingleOrDefault(x => x.Id == lancamento.Id);

			lancamentoAlterar = lancamento;

			AtualizarSaldos();
			//Raise Domain Event
		}

		public void RemoverLancamento(Lancamento lancamento)
		{
			var lancamentoRemover = _lancamentos.SingleOrDefault(x => x == lancamento);

			_lancamentos.Remove(lancamentoRemover);

			AtualizarSaldos();
			//Raise Domain Event
		}

		private void AtualizarSaldos()
		{
			_lancamentos.ForEach(lancamento =>
			{
				if (lancamento.Tipo == LancamentoTipo.Receita)
				{
					TotalContasAReceber += lancamento.Valor;
					Saldo += lancamento.Valor;
				}
				else if (lancamento.Tipo == LancamentoTipo.Despesa)
				{
					TotalContasAPagar += lancamento.Valor;
					Saldo -= lancamento.Valor;
				}
			});
		}
	}
}
