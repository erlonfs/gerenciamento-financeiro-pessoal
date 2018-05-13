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
		public DateTime DataCriacao { get; private set; }

		public Decimal TotalContasAPagar { get; private set; }
		public Decimal TotalContasAReceber { get; private set; }
		public Decimal Saldo { get; private set; }

		private List<Lancamento> _lancamentos = new List<Lancamento>();
		public IReadOnlyList<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

		public CompetenciaAggregateRoot()
		{
			Register();
		}

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
				if (receitaAlterar == null) return;

				TotalContasAReceber -= receitaAlterar;
				TotalContasAReceber += e.Receita;

				Saldo -= receitaAlterar;
				Saldo += e.Receita;

				receitaAlterar = e.Receita;

			});

			DomainEvents.Register<DespesaAlterada>(e =>
			{
				var despesaAlterar = _lancamentos.SingleOrDefault(x => x.Id == e.Despesa.Id) as Despesa;
				if (despesaAlterar == null) return;

				TotalContasAPagar -= despesaAlterar;
				TotalContasAPagar += e.Despesa;

				Saldo -= despesaAlterar;
				Saldo += e.Despesa;

				despesaAlterar = e.Despesa;

			});

			DomainEvents.Register<ReceitaRemovida>(e =>
			{
				var receitaRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Receita.Id) as Receita;
				if (receitaRemover == null) return;

				TotalContasAReceber -= receitaRemover;
				Saldo -= receitaRemover;

				_lancamentos.Remove(receitaRemover);

			});

			DomainEvents.Register<DespesaRemovida>(e =>
			{
				var despesaRemover = _lancamentos.SingleOrDefault(x => x.Id == e.Despesa.Id) as Despesa;
				if (despesaRemover == null) return;

				TotalContasAPagar -= despesaRemover;
				Saldo -= despesaRemover;

				_lancamentos.Remove(despesaRemover);

			});
		}

		public CompetenciaAggregateRoot Create(Guid id, DateTime dataCriacao, Ano ano, Mes mes)
		{
			Id = id;
			DataCriacao = dataCriacao;
			Ano = ano;
			Mes = mes;

			DomainEvents.Raise(new CompetenciaCriada(Id, this));

			return this;

		}

		public void AdicionarReceita(Receita receita)
		{
			var existeReceita = _lancamentos.OfType<Receita>().Any(x => x.Id == receita.Id);
			if (existeReceita) throw new Exception("Receita já adicionada!");

			DomainEvents.Raise(new ReceitaAdicionada(Id, receita));
		}

		public void AdicionarDespesa(Despesa despesa)
		{
			var existeDespesa = _lancamentos.OfType<Despesa>().Any(x => x.Id == despesa.Id);
			if (existeDespesa) throw new Exception("Despesa já adicionada!");

			DomainEvents.Raise(new DespesaAdicionada(Id, despesa));
		}

		public void AlterarReceita(Receita receita)
		{
			DomainEvents.Raise(new ReceitaAlterada(Id, receita));
		}

		public void AlterarDespesa(Despesa despesa)
		{
			DomainEvents.Raise(new DespesaAlterada(Id, despesa));
		}

		public void RemoverReceita(Receita receita)
		{
			DomainEvents.Raise(new ReceitaRemovida(Id, receita));
		}

		public void RemoverDespesa(Despesa despesa)
		{
			DomainEvents.Raise(new DespesaRemovida(Id, despesa));
		}

	}
}
