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
			DomainEvents.Register<LancamentoAdicionado>(x => { AtualizarSaldos(); });
			DomainEvents.Register<LancamentoAlterado>(x => { AtualizarSaldos(); });
			DomainEvents.Register<LancamentoRemovido>(x => { AtualizarSaldos(); });

			Ano = ano;
			Mes = mes;

			foreach (var item in lancamentos)
			{
				_lancamentos.Add(item);
				DomainEvents.Raise(new LancamentoAdicionado(item));
			}

		}

		public void AdicionarLancamento(Lancamento lancamento)
		{
			_lancamentos.Add(lancamento);

			DomainEvents.Raise(new LancamentoAdicionado(lancamento));
		}

		public void AlterarLancamento(Lancamento lancamento)
		{
			var lancamentoAlterar = _lancamentos.SingleOrDefault(x => x.Id == lancamento.Id);

			lancamentoAlterar = lancamento;

			DomainEvents.Raise(new LancamentoAlterado(lancamento));
		}

		public void RemoverLancamento(Lancamento lancamento)
		{
			var lancamentoRemover = _lancamentos.SingleOrDefault(x => x.Id == lancamento.Id);

			_lancamentos.Remove(lancamentoRemover);

			DomainEvents.Raise(new LancamentoRemovido(lancamento));

		}

		private void AtualizarSaldos()
		{
			TotalContasAReceber = 0;
			TotalContasAPagar = 0;
			Saldo = 0;

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
