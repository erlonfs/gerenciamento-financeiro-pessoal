using System;

namespace Competencia.Data.Model
{
	public class Lancamento
    {
		public int Id { get; set; }
		public DateTime DataCriacao { get; set; }

		public int CompetenciaId { get; set; }
		public virtual Competencia Competencia { get; set; }
	}
}
