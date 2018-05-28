using SharedKernel.Common;
using System;

namespace Competencias.Domain.Aggregates
{
	public abstract class Lancamento : Entity<Guid>
	{
		protected Lancamento(Guid id) : base(id) { }

		public int Id { get; protected set; }
		public DateTime DataCriacao { get; protected set; }

		public string Tipo { get; protected set; }
		public int TipoId { get; protected set; }
		public int CategoriaId { get; protected set; }
		public DateTime Data { get; protected set; }
		public string Descricao { get; protected set; }
		public bool IsLancamentoPago { get; protected set; }
		public decimal Valor { get; protected set; }
		public int FormaDePagtoId { get; protected set; }
		public string Anotacao { get; protected set; }
	}
}
