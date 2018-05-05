using Competencia.Domain.CompetenciaAggregate;
using SharedKernel.Common;
using System;

namespace Competencia.Handlers
{
	//TODO Handle apenas será chamado pela camada de aplicação
	public class LancamentoAdicionadoHandler : IHandler<ReceitaAdicionada>
	{
		public void Handle(ReceitaAdicionada domainEvent)
		{
			throw new NotImplementedException();
		}
	}
}
