using System;

namespace Competencia.Data.Model
{
	public class LancamentoCategoria
	{
		public int Id { get; set; }
		public Guid EntityId { get; set; }
		public DateTime DataCriacao { get; set; }
		public string Nome { get; set; }
	}
}
