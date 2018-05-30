using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class CompetenciaNaoEncontradaException : ApplicationException
	{
		public CompetenciaNaoEncontradaException() : base("Competência não encontrada.") { }
	}

	public class CompetenciaJaExistenteParaAnoEMesException : ApplicationException
	{
		public CompetenciaJaExistenteParaAnoEMesException(int mes, int ano) : base($"Já existe competência para {mes}/{ano}.") { }
	}
}
