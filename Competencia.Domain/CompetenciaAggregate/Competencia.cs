using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
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

		private void Register()
		{
			DomainEvents.Register<LancamentoAdicionado>(e =>
			{
				_lancamentos.Add(e.Lancamento);

				AtualizarSaldos();

			});

			DomainEvents.Register<LancamentoAlterado>(e =>
			{
				var lancamentoAlterar = _lancamentos.SingleOrDefault(x => x.Id == e.Lancamento.Id);
				lancamentoAlterar = e.Lancamento;

				AtualizarSaldos();

			});

			DomainEvents.Register<LancamentoRemovido>(e =>
			{
				var lancamentoRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Lancamento.Id);
				_lancamentos.Remove(lancamentoRemover);

				AtualizarSaldos();

			});
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

		public Competencia(Guid id, Ano ano, Mes mes, List<Lancamento> lancamentos) : base(id)
		{
			Register();

			Ano = ano;
			Mes = mes;

			foreach (var item in lancamentos)
			{
				DomainEvents.Raise(new LancamentoAdicionado(item));
			}

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
