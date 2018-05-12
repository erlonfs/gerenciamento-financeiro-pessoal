using Competencia.Domain.CompetenciaAggregate;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Competencia.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly CompetenciaAggregateRoot _competenciaAggregateRoot;

		public CompetenciaController(CompetenciaAggregateRoot competenciaAggregateRoot,
									 IUnitOfWork unitOfWork)
		{
			_competenciaAggregateRoot = competenciaAggregateRoot;
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		public async Task PostAsync()
		{
			var id = Guid.NewGuid();

			var competencia = _competenciaAggregateRoot.Create(id, new Ano(2018), Mes.Janeiro);

			await _unitOfWork.CommitAsync();
		}

	}
}
