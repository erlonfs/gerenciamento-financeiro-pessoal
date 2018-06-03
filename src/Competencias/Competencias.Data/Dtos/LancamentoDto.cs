using System;

namespace Competencias.Data.Dtos
{
	public class LancamentoDto
	{
		public Guid EntityId { get; set; }
		public DateTime DataCriacao { get; set; }
		public Guid CompetenciaId { get; set; }

		public string Tipo { get; set; }
		public int TipoId { get; set; }

		public string Categoria { get; set; }
		public int CategoriaId { get; set; }

		public DateTime Data { get; set; }
		public string Descricao { get; set; }
		public bool IsLancamentoPago { get; set; }
		public decimal Valor { get; set; }

		public string FormaDePagto { get; set; }
		public int FormaDePagtoId { get; set; }

		public string Anotacao { get; set; }
	}
}
