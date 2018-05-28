using Competencias.Domain;
using Competencias.Domain.Aggregates;
using Competencias.Domain.Repositories;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencias.Handlers
{
	public class ReceitaAdicionadaHandler : IHandler<ReceitaAdicionada>
	{
		private ICompetenciaRepository _competenciaRepository;

		public ReceitaAdicionadaHandler(ICompetenciaRepository competenciaRepository)
		{
			_competenciaRepository = competenciaRepository;
		}

		public Task HandleAsync(ReceitaAdicionada e)
		{
			return Task.CompletedTask;
		}
	}
}
