using Competencia.Data;
using Competencia.Domain.CompetenciaAggregate;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencia.Handlers
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
			_context.Add(new Data.Model.Competencia
			{
				Mes = (int)e.Competencia.Mes,
				Ano = e.Competencia.Ano.Numero,
				DataCriacao = e.DataCriacao,
				EntityId = e.Competencia.Id
			});

			return Task.CompletedTask;

		}
	}
}
