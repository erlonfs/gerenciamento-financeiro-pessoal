using Competencias.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Competencias.Domain.Repositories
{
	public class CompetenciaRepository : Repository<Competencia>,  ICompetenciaRepository
	{
		private AppDbContext _context;

		public CompetenciaRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Competencia> ObterPorAnoEMesAsync(int ano, int mes)
		{
			return await _context.Competencia.SingleOrDefaultAsync(x => x.Ano.Numero == ano && (int)x.Mes == mes);
		}
	}
}
