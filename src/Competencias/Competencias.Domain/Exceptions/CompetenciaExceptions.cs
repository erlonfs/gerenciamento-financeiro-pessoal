using SharedKernel.Common;

namespace Competencias.Domain.Exceptions
{
	public class CompetenciaNaoEncontradaException : ApplicationException
	{
		public CompetenciaNaoEncontradaException() : base("Competência não encontrada.") { }
	}

	public class CompetenciaJaExistenteParaAnoEMesException : ApplicationException
	{
		public CompetenciaJaExistenteParaAnoEMesException(string mes, string ano) : base($"Já existe competência para {mes}/{ano}.") { }
	}
}
