using Competencias.Domain.Aggregates;

namespace Competencias.Domain.Repositories
{
	public class CompetenciaRepository : Repository<Competencia>,  ICompetenciaRepository
	{
		public CompetenciaRepository(AppDbContext context) : base(context)
		{

		}
	}
}
