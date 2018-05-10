using Competencia.Data;
using Competencia.Domain.CompetenciaAggregate;
using SharedKernel.Common;

namespace Competencia.Handlers
{
	public class CompetenciaCriadaHandler : IHandler<CompetenciaCriada>
	{
		private AppDbContext _context;

		public CompetenciaCriadaHandler(AppDbContext context)
		{
			_context = context;
		}

		public void Handle(CompetenciaCriada e)
		{
			_context.Add(new Data.Model.Competencia
			{
				Mes = (int)e.Competencia.Mes,
				Ano = e.Competencia.Ano.Numero,
				DataCriacao = e.DataCriacao,
				EntityId = e.Competencia.Id
			});

			//_context.SaveChanges();
		}
	}
}
