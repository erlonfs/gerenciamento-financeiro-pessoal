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
			DomainEvents.Register<ReceitaAdicionada>(e =>
			{
				_lancamentos.Add(e.Receita);

				TotalContasAReceber += e.Receita;
				Saldo += e.Receita;

			});

			DomainEvents.Register<DespesaAdicionada>(e =>
			{
				_lancamentos.Add(e.Despesa);

				TotalContasAPagar += e.Despesa;
				Saldo += e.Despesa;

			});

			DomainEvents.Register<ReceitaAlterada>(e =>
			{
				var receitaAlterar = _lancamentos.SingleOrDefault(x => x.Id == e.Receita.Id) as Receita;

				TotalContasAReceber -= receitaAlterar;
				TotalContasAReceber += e.Receita;

				Saldo -= receitaAlterar;
				Saldo += e.Receita;

				receitaAlterar = e.Receita;

			});

			DomainEvents.Register<DespesaAlterada>(e =>
			{
				var despesaAlterar = _lancamentos.SingleOrDefault(x => x.Id == e.Despesa.Id) as Despesa;

				TotalContasAPagar -= despesaAlterar;
				TotalContasAPagar += e.Despesa;

				Saldo -= despesaAlterar;
				Saldo += e.Despesa;

				despesaAlterar = e.Despesa;

			});

			DomainEvents.Register<ReceitaRemovida>(e =>
			{
				var receitaRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Receita.Id) as Receita;

				TotalContasAReceber -= receitaRemover;
				Saldo -= receitaRemover;

				_lancamentos.Remove(receitaRemover);

			});

			DomainEvents.Register<DespesaRemovida>(e =>
			{
				var despesaRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Despesa.Id) as Despesa;

				TotalContasAPagar -= despesaRemover;
				Saldo -= despesaRemover;

				_lancamentos.Remove(despesaRemover);

			});
		}

		public CompetenciaAggregateRoot(Guid id, Ano ano, Mes mes) : base(id)
		{
			Register();

			Ano = ano;
			Mes = mes;

			DomainEvents.Raise(new CompetenciaCriada(this));

		}

		public void AdicionarReceita(Receita receita)
		{
			DomainEvents.Raise(new ReceitaAdicionada(receita));
		}

		public void AdicionarDespesa(Despesa despesa)
		{
			DomainEvents.Raise(new DespesaAdicionada(despesa));
		}

		public void AlterarReceita(Receita receita)
		{
			DomainEvents.Raise(new ReceitaAlterada(receita));
		}

		public void AlterarDespesa(Despesa despesa)
		{
			DomainEvents.Raise(new DespesaAlterada(despesa));
		}

		public void RemoverReceita(Receita receita)
		{
			DomainEvents.Raise(new ReceitaRemovida(receita));
		}

		public void RemoverDespesa(Despesa despesa)
		{
			DomainEvents.Raise(new DespesaRemovida(despesa));
		}

	}
}
