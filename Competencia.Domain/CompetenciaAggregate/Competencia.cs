using SharedKernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lancamentos.Domain.CompetenciaAggregate
{
	public class Competencia : Entity<Guid>
	{
		public int Ano { get; private set; }
		public Mes Mes { get; private set; }

		private List<Lancamento> _lancamentos = new List<Lancamento>();
		public IReadOnlyList<Lancamento> Lancamentos => _lancamentos.AsReadOnly();

		public Competencia(Guid id, int ano, Mes mes, List<Lancamento> lancamentos) : base(id)
		{
			Ano = ano;
			Mes = mes;
			_lancamentos = lancamentos;
		}

		public void AdicionarLancamento(Lancamento lancamento)
		{
			_lancamentos.Add(lancamento);

			//Raise Domain Event
		}

		public void AlterarLancamento(Lancamento lancamento)
		{
			var lancamentoAlterar = _lancamentos.SingleOrDefault(x => x.Id == lancamento.Id);

			lancamentoAlterar = lancamento;

			//Raise Domain Event
		}

		public void RemoverLancamento(Lancamento lancamento)
		{
			var lancamentoRemover = _lancamentos.SingleOrDefault(x => x == lancamento);

			_lancamentos.Remove(lancamentoRemover);

			//Raise Domain Event
		}
	}
}
