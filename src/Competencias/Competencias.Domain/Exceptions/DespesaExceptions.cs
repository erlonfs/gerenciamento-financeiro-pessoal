using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class DespesaJaAdicionadaException : ApplicationException
	{
		public DespesaJaAdicionadaException() : base("Despesa já adicionada.") { }
	}
}
