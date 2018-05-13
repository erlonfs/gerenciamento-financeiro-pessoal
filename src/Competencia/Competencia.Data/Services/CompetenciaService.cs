using Competencia.Domain.CompetenciaAggregate;
using Competencia.Domain.Repositories;
using Competencia.Domain.Services;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competencia.Data.Services
{
	public class CompetenciaService : ICompetenciaService
	{
		private readonly AppDbContext _context;
		private readonly IDomainEvents _domainEvents;
		private readonly DomainEventsFromHistory _domainEventsFromHistory;

		public CompetenciaService(AppDbContext context, IDomainEvents domainEvents)
		{
			_context = context;
			_domainEvents = domainEvents;
		}

		public Task<CompetenciaAggregateRoot> CriarAsync(int ano, int mes)
		{
			var aggregate = new CompetenciaAggregateRoot(_domainEvents);

			aggregate.Create(Guid.NewGuid(), DateTime.Now, new Ano(ano), (Mes)mes);

			_context.Add(new Model.Competencia
			{
				Ano = aggregate.Ano.Numero,
				Mes = (int)aggregate.Mes,
				DataCriacao = aggregate.DataCriacao,
				EntityId = aggregate.Id
			});

			return Task.FromResult(aggregate);

		}

		public async Task<CompetenciaAggregateRoot> ObterPorIdAsync(Guid competenciaId)
		{
			var competencia = await _context.Competencia.SingleOrDefaultAsync(x => x.EntityId == competenciaId);

			var aggregate = new CompetenciaAggregateRoot(_domainEventsFromHistory);

			aggregate.Create(competencia.EntityId, competencia.DataCriacao, new Ano(competencia.Ano), (Mes)competencia.Mes);

			return aggregate;

		}
	}
}
