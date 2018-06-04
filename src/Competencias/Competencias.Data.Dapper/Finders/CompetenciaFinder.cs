using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Competencias.Data.Dtos;
using Competencias.Data.Finders;
using Dapper;

namespace Competencias.Data.Dapper.Finders
{
	public class CompetenciaFinder : ICompetenciaFinder
	{
		private readonly AppConnectionString _appConnectionString;

		public CompetenciaFinder(AppConnectionString appConnectionString)
		{
			_appConnectionString = appConnectionString;
		}

		public async Task<IEnumerable<CompetenciaDto>> ObterAsync()
		{
			string sql = @"SELECT c.EntityId, c.DataCriacao, c.Mes, c.Ano FROM COMP.Competencia AS c";

			using(var connection = new SqlConnection(_appConnectionString))
			{
				return await connection.QueryAsync<CompetenciaDto>(sql);
			}
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
