using Competencia.Domain.CompetenciaAggregate;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common.ValueObjects;
using System;

namespace Competencia.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : Controller
	{
		private readonly CompetenciaAggregateRoot _competenciaAggregateRoot;

		public CompetenciaController(CompetenciaAggregateRoot competenciaAggregateRoot)
		{
			_competenciaAggregateRoot = competenciaAggregateRoot;
		}

		[HttpPost]
		public void Post()
		{
			var id = Guid.NewGuid();
			var competencia = _competenciaAggregateRoot.Create(id, new Ano(2018), Mes.Janeiro);
		}

	}
}
