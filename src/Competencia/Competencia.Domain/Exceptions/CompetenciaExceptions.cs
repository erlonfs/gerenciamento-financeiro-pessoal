using System;

namespace Competencias.Domain.Exceptions
{
	public class CompetenciaNaoEncontradaException : Exception
	{
		public CompetenciaNaoEncontradaException() : base("Competência não encontrada.") { }
	}
}
