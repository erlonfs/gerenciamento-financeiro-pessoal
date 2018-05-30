using Competencias.Api.Dtos;
using Competencias.Domain.Aggregates;
using Competencias.Domain.Exceptions;
using Competencias.Domain.Repositories;
using Competencias.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;
using System;
using System.Threading.Tasks;

namespace Competencias.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompetenciaService _competenciaService;

		public CompetenciaController(IUnitOfWork unitOfWork,
									 ICompetenciaService competenciaService)
		{
			_unitOfWork = unitOfWork;
			_competenciaService = competenciaService;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CompetenciaDto dto)
		{
			var id = Guid.NewGuid();

			var competencia = await _competenciaService.CriarAsync(id, dto.Ano, dto.Mes);

			await _unitOfWork.CommitAsync();

			return competencia.EntityId;

		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task<Guid> AdicionarReceitaAsync(Guid id, LancamentoDto dto)
		{
			var receitaId = Guid.NewGuid();

			var receita = await _competenciaService.AdicionarReceitaAsync(id, receitaId, dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			await _unitOfWork.CommitAsync();

			return receitaId;
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-despesa")]
		public async Task<Guid> AdicionarDespesaAsync(Guid id, LancamentoDto dto)
		{
			var despesaId = Guid.NewGuid();

			var despesa = await _competenciaService.AdicionarDespesaAsync(id, despesaId, dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			await _unitOfWork.CommitAsync();

			return despesaId;
		}

	}
}
