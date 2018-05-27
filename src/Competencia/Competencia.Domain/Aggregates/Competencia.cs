using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Competencias.Domain.Aggregates
{
	public class Competencia : Entity<Guid>
	{
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

			TotalContasAReceber += receita;
			Saldo += receita;

			_lancamentos.Add(receita);

			DomainEvents.Raise(new ReceitaAdicionada(Id, receita));
		}

		public void AdicionarDespesa(Despesa despesa)
		{
			var existeDespesa = _lancamentos.OfType<Despesa>().Any(x => x.Id == despesa.Id);
			if (existeDespesa) throw new Exception("Despesa já adicionada!");

			TotalContasAPagar += despesa;
			Saldo += despesa;

			_lancamentos.Add(despesa);

			DomainEvents.Raise(new DespesaAdicionada(Id, despesa));
		}

		public void AlterarReceita(Receita receita)
		{
			var receitaAlterar = _lancamentos.OfType<Receita>().SingleOrDefault(x => x.Id == receita.Id);

			TotalContasAReceber -= receitaAlterar;
			Saldo -= receitaAlterar;

			TotalContasAReceber += receita;
			Saldo += receita;

			receitaAlterar = receita;

			DomainEvents.Raise(new ReceitaAlterada(Id, receita));
		}

		public void AlterarDespesa(Despesa despesa)
		{
			var despesaAlterar = _lancamentos.OfType<Despesa>().SingleOrDefault(x => x.Id == despesa.Id);

			TotalContasAPagar -= despesaAlterar;
			Saldo -= despesaAlterar;

			TotalContasAPagar += despesa;
			Saldo += despesa;

			despesaAlterar = despesa;

			DomainEvents.Raise(new DespesaAlterada(Id, despesa));
		}

		public void RemoverReceita(Receita receita)
		{
			var receitaRemover = _lancamentos.OfType<Receita>().SingleOrDefault(x => x.Id == receita.Id);

			TotalContasAReceber -= receitaRemover;
			Saldo -= receitaRemover;

			_lancamentos.Remove(receitaRemover);

			DomainEvents.Raise(new ReceitaRemovida(Id, receita));
		}

		public void RemoverDespesa(Despesa despesa)
		{
			var despesaRemover = _lancamentos.OfType<Despesa>().SingleOrDefault(x => x.Id == despesa.Id);

			TotalContasAPagar -= despesaRemover;
			Saldo -= despesaRemover;

			_lancamentos.Remove(despesa);

			DomainEvents.Raise(new DespesaRemovida(Id, despesa));
		}

	}
}
