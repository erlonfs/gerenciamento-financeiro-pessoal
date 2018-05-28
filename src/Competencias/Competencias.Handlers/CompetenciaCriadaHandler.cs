using Competencias.Domain;
using Competencias.Domain.Aggregates;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencias.Handlers
{
	public class CompetenciaCriadaHandler : IHandler<CompetenciaCriada>
	{
		private AppDbContext _context;

		public CompetenciaCriadaHandler(AppDbContext context)
		{
			_context = context;
		}

		public Task HandleAsync(CompetenciaCriada e)
		{

			//TODO

			return Task.CompletedTask;

		}
	}
}
