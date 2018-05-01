using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class CompetenciaAggregateRoot : Entity<Guid>
	{
		public Ano Ano { get; private set; }
		public Mes Mes { get; private set; }

		public Decimal TotalContasAPagar { get; private set; }
		public Decimal TotalContasAReceber { get; private set; }
		public Decimal Saldo { get; private set; }

		private List<Lancamento> _lancamentos = new List<Lancamento>();
		public IReadOnlyList<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

		private void Register()
		{
			DomainEvents.Register<LancamentoAdicionado>(e =>
			{
				_lancamentos.Add(e.Lancamento);

				if (e.Lancamento.Tipo == LancamentoTipo.Receita)
				{
					TotalContasAReceber += e.Lancamento.Valor;
					Saldo += e.Lancamento.Valor;
				}

				if (e.Lancamento.Tipo == LancamentoTipo.Despesa)
				{
					TotalContasAPagar += e.Lancamento.Valor;
					Saldo -= e.Lancamento.Valor;
				}

			});

			DomainEvents.Register<LancamentoAlterado>(e =>
			{
				var lancamentoAlterar = _lancamentos.SingleOrDefault(x => x.Id == e.Lancamento.Id);

				if (e.Lancamento.Tipo == LancamentoTipo.Receita)
				{
					TotalContasAReceber -= lancamentoAlterar.Valor;
					TotalContasAReceber += e.Lancamento.Valor;

					Saldo -= lancamentoAlterar.Valor;
					Saldo += e.Lancamento.Valor;
				}

				if (e.Lancamento.Tipo == LancamentoTipo.Despesa)
				{
					TotalContasAPagar -= lancamentoAlterar.Valor;
					TotalContasAPagar += e.Lancamento.Valor;

					Saldo += lancamentoAlterar.Valor;
					Saldo -= e.Lancamento.Valor;
				}

				lancamentoAlterar = e.Lancamento;

			});

			DomainEvents.Register<LancamentoRemovido>(e =>
			{
				var lancamentoRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Lancamento.Id);

				if (e.Lancamento.Tipo == LancamentoTipo.Receita)
				{
					TotalContasAReceber -= lancamentoRemover.Valor;
					Saldo -= lancamentoRemover.Valor;
				}

				if (e.Lancamento.Tipo == LancamentoTipo.Despesa)
				{
					TotalContasAPagar -= lancamentoRemover.Valor;
					Saldo += lancamentoRemover.Valor;
				}

				_lancamentos.Remove(lancamentoRemover);

			});
		}

		public CompetenciaAggregateRoot(Guid id, Ano ano, Mes mes) : base(id)
		{
			Register();

			Ano = ano;
			Mes = mes;

			DomainEvents.Raise(new CompetenciaCriada(this));

		}

		public void AdicionarLancamento(Lancamento lancamento)
		{
			DomainEvents.Raise(new LancamentoAdicionado(lancamento));
		}

		public void AlterarLancamento(Lancamento lancamento)
		{
			DomainEvents.Raise(new LancamentoAlterado(lancamento));
		}

		public void RemoverLancamento(Lancamento lancamento)
		{
			DomainEvents.Raise(new LancamentoRemovido(lancamento));
		}

	}
}
