using Competencias.Domain;
using Competencias.Domain.Aggregates;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencia.Handlers
{
	public class ReceitaAdicionadaHandler : IHandler<ReceitaAdicionada>
	{
		private AppDbContext _context;

		public ReceitaAdicionadaHandler(AppDbContext context)
		{
			_context = context;
		}

		public Task HandleAsync(ReceitaAdicionada e)
		{
			//var competencia = await _context.Competencia.SingleAsync(x => x.EntityId == e.AggregateId);

			return Task.CompletedTask;

		}
	}
}
