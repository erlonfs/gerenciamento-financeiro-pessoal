using Competencia.Domain.CompetenciaAggregate;
using SharedKernel.Common;
using System;

namespace Competencia.Handlers
{
	//TODO Handle apenas será chamado pela camada de aplicação
	public class LancamentoAdicionadoHandler : IHandler<LancamentoAdicionado>
	{
		public void Handle(LancamentoAdicionado domainEvent)
		{
			throw new NotImplementedException();
		}
	}
}
