using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class ReceitaJaAdicionadaException : ApplicationException
	{
		public ReceitaJaAdicionadaException() : base("Receita já adicionada.") { }
	}
}
