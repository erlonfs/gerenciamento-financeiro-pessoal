using Competencias.Domain;
using Competencias.Domain.Aggregates;
using Competencias.Domain.Repositories;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencias.Handlers
{
	public class CompetenciaCriadaHandler : IHandler<CompetenciaCriada>
	{
		private ICompetenciaRepository _competenciaRepository;

		public CompetenciaCriadaHandler(ICompetenciaRepository competenciaRepository)
		{
			_competenciaRepository = competenciaRepository;
		}

		public Task HandleAsync(CompetenciaCriada e)
		{
			return Task.CompletedTask;
		}
	}
}
