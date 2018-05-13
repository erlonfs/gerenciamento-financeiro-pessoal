using Competencia.Domain.CompetenciaAggregate;
using Competencia.Domain.Repositories;
using Competencia.Domain.Services;
using Dapper;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Data.Services
{
	public class CompetenciaService : ICompetenciaService
	{
		private readonly AppDbContext _context;

		public CompetenciaService(AppDbContext context)
		{
			_context = context;
		}

		public Task<CompetenciaAggregateRoot> CriarAsync(int ano, int mes)
		{
			return Task.FromResult(new CompetenciaAggregateRoot().Create(Guid.NewGuid(), DateTime.Now, new Ano(ano), (Mes)mes));
		}

		public async Task<CompetenciaAggregateRoot> ObterPorIdAsync(Guid competenciaId)
		{
			CompetenciaAggregateRoot aggregate;

			var sql = @"SELECT c.EntityId AS Id, c.DataCriacao, c.Mes FROM COMP.Competencia AS c
						WHERE c.EntityId = @AggregateId";

			try
			{
				using (IDbConnection db = new SqlConnection("Data Source=10.0.75.1;Initial Catalog=GerenciamentoFinanceiro;User Id=SA;Password=GuiGui@2016;"))
				{
					aggregate = await db.QuerySingleAsync<CompetenciaAggregateRoot>(sql, new { @AggregateId = competenciaId });
				}
			}
			catch (Exception e)
			{
				throw;
			}

			return aggregate;

		}
	}
}
