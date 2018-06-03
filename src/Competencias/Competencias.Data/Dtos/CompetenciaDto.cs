using System;

namespace Competencias.Data.Dtos
{
	public class CompetenciaDto
    {
		public Guid EntityId { get; set; }
		public DateTime DataCriacao { get; set; }
		public string Mes { get; set; }
		public int Ano { get; set; }
	}
}
