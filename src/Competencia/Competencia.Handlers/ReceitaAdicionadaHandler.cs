using Competencia.Data;
using Competencia.Domain.CompetenciaAggregate;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;
using System.Linq;
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

		public async Task HandleAsync(ReceitaAdicionada e)
		{
			var competencia = await _context.Competencia.SingleAsync(x => x.EntityId == e.AggregateId);
		}
	}
}
