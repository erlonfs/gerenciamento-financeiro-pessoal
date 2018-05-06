using System;

namespace Competencia.Data.Model
{
	public class Lancamento
	{
		public int Id { get; set; }
		public Guid EntityId { get; set; }
		public DateTime DataCriacao { get; set; }

		public int TipoId { get; set; }
		public virtual LancamentoTipo Tipo { get; set; }

		public int CategoriaId { get; set; }
		public virtual LancamentoCategoria Categoria { get; set; }

		public DateTime Data { get; set; }
		public string Descricao { get; set; }
		public bool IsLancamentoPago { get; set; }
		public decimal Valor { get; set; }
		public int FormaDePagtoId { get; set; }
		public string Anotacao { get; set; }

		public int CompetenciaId { get; set; }
		public virtual Competencia Competencia { get; set; }
	}
}
