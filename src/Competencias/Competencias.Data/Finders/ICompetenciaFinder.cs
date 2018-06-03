using Competencias.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Competencias.Data.Finders
{
	public interface ICompetenciaFinder
	{
		Task<IEnumerable<CompetenciaDto>> ObterAsync();
		Task<CompetenciaDto> ObterPorIdAsync(Guid id);
		Task<IEnumerable<LancamentoDto>> ObterLancamentosPorCompetenciaIdAsync(Guid competenciaId);
	}
}
