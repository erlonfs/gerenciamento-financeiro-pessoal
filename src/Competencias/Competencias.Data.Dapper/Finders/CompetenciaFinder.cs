using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Competencias.Data.Dtos;
using Competencias.Data.Finders;
using Dapper;

namespace Competencias.Data.Dapper.Finders
{
	public class CompetenciaFinder : ICompetenciaFinder
	{
		public CompetenciaFinder()
		{

		}

		public Task<IEnumerable<CompetenciaDto>> ObterAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<LancamentoDto>> ObterLancamentosPorCompetenciaIdAsync(Guid competenciaId)
		{
			throw new NotImplementedException();
		}

		public Task<CompetenciaDto> ObterPorIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
