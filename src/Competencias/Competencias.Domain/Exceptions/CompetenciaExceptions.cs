using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class CompetenciaNaoEncontradaException : ApplicationException
	{
		public CompetenciaNaoEncontradaException() : base("Competência não encontrada.") { }
	}
}
