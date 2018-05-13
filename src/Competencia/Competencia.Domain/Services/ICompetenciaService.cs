using Competencia.Domain.CompetenciaAggregate;
using System;
using System.Threading.Tasks;

namespace Competencia.Domain.Services
{
	public interface ICompetenciaService
	{
		Task<CompetenciaAggregateRoot> CriarAsync(int ano, int mes);
		Task<CompetenciaAggregateRoot> ObterPorIdAsync(Guid competenciaId);
	}
}
