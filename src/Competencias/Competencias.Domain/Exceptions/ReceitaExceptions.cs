using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class ReceitaNaoEncontradaException : ApplicationException
	{
		public ReceitaNaoEncontradaException() : base("Receita não encontrada.") { }
	}

	public class ReceitaJaAdicionadaException : ApplicationException
	{
		public ReceitaJaAdicionadaException() : base("Receita já adicionada.") { }
	}
}
