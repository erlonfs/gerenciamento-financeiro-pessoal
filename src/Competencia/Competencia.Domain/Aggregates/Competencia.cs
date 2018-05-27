using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Competencias.Domain.Aggregates
{
	public class Competencia : Entity<Guid>
	{
		public int Id { get; private set; }
		public Ano Ano { get; private set; }
		public Mes Mes { get; private set; }
		public DateTime DataCriacao { get; private set; }

		public Decimal TotalContasAPagar { get; private set; }
		public Decimal TotalContasAReceber { get; private set; }
		public Decimal Saldo { get; private set; }

		private List<Lancamento> _lancamentos = new List<Lancamento>();
		public IReadOnlyList<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

		public Competencia()
		{

		}

		public Competencia Create(Guid id, DateTime dataCriacao, Ano ano, Mes mes)
		{
			EntityId = id;
			DataCriacao = dataCriacao;
			Ano = ano;
			Mes = mes;

			DomainEvents.Raise(new CompetenciaCriada(EntityId, this));

			return this;

		}

		public void AdicionarReceita(Receita receita)
		{
			var existeReceita = _lancamentos.OfType<Receita>().Any(x => x.EntityId == receita.EntityId);
			if (existeReceita) throw new Exception("Receita já adicionada!");

			TotalContasAReceber += receita;
			Saldo += receita;

			_lancamentos.Add(receita);

			DomainEvents.Raise(new ReceitaAdicionada(EntityId, receita));
		}

		public void AdicionarDespesa(Despesa despesa)
		{
			var existeDespesa = _lancamentos.OfType<Despesa>().Any(x => x.EntityId == despesa.EntityId);
			if (existeDespesa) throw new Exception("Despesa já adicionada!");

			TotalContasAPagar += despesa;
			Saldo += despesa;

			_lancamentos.Add(despesa);

			DomainEvents.Raise(new DespesaAdicionada(EntityId, despesa));
		}

		public void AlterarReceita(Receita receita)
		{
			var receitaAlterar = _lancamentos.OfType<Receita>().SingleOrDefault(x => x.EntityId == receita.EntityId);

			TotalContasAReceber -= receitaAlterar;
			Saldo -= receitaAlterar;

			TotalContasAReceber += receita;
			Saldo += receita;

			receitaAlterar = receita;

			DomainEvents.Raise(new ReceitaAlterada(EntityId, receita));
		}

		public void AlterarDespesa(Despesa despesa)
		{
			var despesaAlterar = _lancamentos.OfType<Despesa>().SingleOrDefault(x => x.EntityId == despesa.EntityId);

			TotalContasAPagar -= despesaAlterar;
			Saldo -= despesaAlterar;

			TotalContasAPagar += despesa;
			Saldo += despesa;

			despesaAlterar = despesa;

			DomainEvents.Raise(new DespesaAlterada(EntityId, despesa));
		}

		public void RemoverReceita(Receita receita)
		{
			var receitaRemover = _lancamentos.OfType<Receita>().SingleOrDefault(x => x.EntityId == receita.EntityId);

			TotalContasAReceber -= receitaRemover;
			Saldo -= receitaRemover;

			_lancamentos.Remove(receitaRemover);

			DomainEvents.Raise(new ReceitaRemovida(EntityId, receita));
		}

		public void RemoverDespesa(Despesa despesa)
		{
			var despesaRemover = _lancamentos.OfType<Despesa>().SingleOrDefault(x => x.EntityId == despesa.EntityId);

			TotalContasAPagar -= despesaRemover;
			Saldo -= despesaRemover;

			_lancamentos.Remove(despesa);

			DomainEvents.Raise(new DespesaRemovida(EntityId, despesa));
		}

	}
}
