using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Competencias.Domain.Aggregates
{
	public class Competencia : Entity<Guid>
	{
		public int Id { get; private set; }
		public DateTime DataCriacao { get; private set; }

		[NotMapped]
		public Mes Mes { get; private set; }
		public int MesInt { get { return (int)Mes; } private set { Mes = (Mes)value; } }

		public virtual Ano Ano { get; private set; }

		public Decimal TotalContasAPagar { get; private set; }
		public Decimal TotalContasAReceber { get; private set; }
		public Decimal Saldo { get; private set; }

		public virtual HashSet<Lancamento> Lancamentos { get; private set; } = new HashSet<Lancamento>();

		protected Competencia()
		{

		}

		public Competencia(Guid id, DateTime dataCriacao, Ano ano, Mes mes)
		{
			EntityId = id;
			DataCriacao = dataCriacao;
			Ano = ano;
			Mes = mes;

			DomainEvents.Raise(new CompetenciaCriada(EntityId, this));

		}

		public void AdicionarReceita(Receita receita)
		{
			var existeReceita = Lancamentos.OfType<Receita>().Any(x => x.EntityId == receita.EntityId);
			if (existeReceita) throw new Exception("Receita já adicionada!");

			TotalContasAReceber += receita;
			Saldo += receita;

			Lancamentos.Add(receita);

			DomainEvents.Raise(new ReceitaAdicionada(EntityId, receita));
		}

		public void AdicionarDespesa(Despesa despesa)
		{
			var existeDespesa = Lancamentos.OfType<Despesa>().Any(x => x.EntityId == despesa.EntityId);
			if (existeDespesa) throw new Exception("Despesa já adicionada!");

			TotalContasAPagar += despesa;
			Saldo += despesa;

			Lancamentos.Add(despesa);

			DomainEvents.Raise(new DespesaAdicionada(EntityId, despesa));
		}

		public void AlterarReceita(Receita receita)
		{
			var receitaAlterar = Lancamentos.OfType<Receita>().SingleOrDefault(x => x.EntityId == receita.EntityId);

			TotalContasAReceber -= receitaAlterar;
			Saldo -= receitaAlterar;

			TotalContasAReceber += receita;
			Saldo += receita;

			receitaAlterar = receita;

			DomainEvents.Raise(new ReceitaAlterada(EntityId, receita));
		}

		public void AlterarDespesa(Despesa despesa)
		{
			var despesaAlterar = Lancamentos.OfType<Despesa>().SingleOrDefault(x => x.EntityId == despesa.EntityId);

			TotalContasAPagar -= despesaAlterar;
			Saldo -= despesaAlterar;

			TotalContasAPagar += despesa;
			Saldo += despesa;

			despesaAlterar = despesa;

			DomainEvents.Raise(new DespesaAlterada(EntityId, despesa));
		}

		public void RemoverReceita(Receita receita)
		{
			var receitaRemover = Lancamentos.OfType<Receita>().SingleOrDefault(x => x.EntityId == receita.EntityId);

			TotalContasAReceber -= receitaRemover;
			Saldo -= receitaRemover;

			Lancamentos.Remove(receitaRemover);

			DomainEvents.Raise(new ReceitaRemovida(EntityId, receita));
		}

		public void RemoverDespesa(Despesa despesa)
		{
			var despesaRemover = Lancamentos.OfType<Despesa>().SingleOrDefault(x => x.EntityId == despesa.EntityId);

			TotalContasAPagar -= despesaRemover;
			Saldo -= despesaRemover;

			Lancamentos.Remove(despesa);

			DomainEvents.Raise(new DespesaRemovida(EntityId, despesa));
		}

	}
}
