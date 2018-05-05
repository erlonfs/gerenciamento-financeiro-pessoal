using SharedKernel.Common;
using System;

namespace Competencia.Domain.CompetenciaAggregate
{
	public abstract class Lancamento : Entity<Guid>
	{
		protected Lancamento(Guid id) : base(id) { }

		public virtual LancamentoTipo Tipo { get; protected set; }
		public int CategoriaId { get; protected set; }
		public DateTime Data { get; protected set; }
		public string Descricao { get; protected set; }
		public bool IsLancamentoPago { get; protected set; }
		public decimal Valor { get; protected set; }
		public FormaDePagamento FormaDePagto { get; protected set; }
		public string Anotacao { get; protected set; }
	}
}
