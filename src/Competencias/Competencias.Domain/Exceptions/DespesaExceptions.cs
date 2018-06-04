using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class DespesaNaoEncontradaException : ApplicationException
	{
		public DespesaNaoEncontradaException() : base("Despesa não encontrada.") { }
	}

	public class DespesaJaAdicionadaException : ApplicationException
	{
		public DespesaJaAdicionadaException() : base("Despesa já adicionada.") { }
	}
}
