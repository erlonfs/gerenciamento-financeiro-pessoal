using Competencias.Domain.Aggregates;
using SharedKernel.Common;
using System.Threading.Tasks;

namespace Competencias.Domain.Repositories
{
	public interface ICompetenciaRepository : IRepository<Competencia>
	{
		Task<Competencia> ObterPorAnoEMesAsync(int ano, int mes);
	}
}
