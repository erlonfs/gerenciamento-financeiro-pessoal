using Competencia.Data;
using Competencia.Domain.CompetenciaAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;

namespace Competencia.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : Controller
	{
		private readonly DomainEvents _domainEvents;
		private readonly AppDbContext _appDbContext;

		public CompetenciaController(DomainEvents domainEvents)
		{
			_domainEvents = domainEvents;
		}

		[HttpPost]
		public void Post()
		{
			var id = Guid.NewGuid();
			var competencia = new CompetenciaAggregateRoot(_domainEvents, id, new Ano(2018), Mes.Janeiro);
		}

	}
}
