using Competencias.Api.Dtos;
using Competencias.Data.Dtos;
using Competencias.Data.Finders;
using Competencias.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Competencias.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompetenciaService _competenciaService;
		private readonly ICompetenciaFinder _competenciaFinder;

		public CompetenciaController(IUnitOfWork unitOfWork,
									 ICompetenciaService competenciaService,
									 ICompetenciaFinder competenciaFinder)
		{
			_unitOfWork = unitOfWork;
			_competenciaService = competenciaService;
			_competenciaFinder = competenciaFinder;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CriarCompetenciaDto dto)
		{
			var id = Guid.NewGuid();

			var competencia = await _competenciaService.CriarAsync(id, dto.Ano, dto.Mes);

			await _unitOfWork.CommitAsync();

			return competencia.EntityId;

		}

		[HttpGet]
		[Route("")]
		public async Task<IEnumerable<CompetenciaDto>> ObterAsync()
		{
			return await _competenciaFinder.ObterAsync();
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<CompetenciaDto> ObterPorIdAsync(Guid id)
		{
			return await _competenciaFinder.ObterPorIdAsync(id);
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task<Guid> AdicionarReceitaAsync(Guid id, CriarLancamentoDto dto)
		{
			var receitaId = Guid.NewGuid();

			var receita = await _competenciaService.AdicionarReceitaAsync(id, receitaId, dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			await _unitOfWork.CommitAsync();

			return receitaId;
		}

		[HttpDelete]
		[Route("{id:guid}/remover-receita/{receitaId:guid}")]
		public async Task RemoverReceitaAsync(Guid id, Guid receitaId)
		{
			await _competenciaService.RemoverReceitaAsync(id, receitaId);

			await _unitOfWork.CommitAsync();
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-despesa")]
		public async Task<Guid> AdicionarDespesaAsync(Guid id, CriarLancamentoDto dto)
		{
			var despesaId = Guid.NewGuid();

			var despesa = await _competenciaService.AdicionarDespesaAsync(id, despesaId, dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			await _unitOfWork.CommitAsync();

			return despesaId;
		}

		[HttpDelete]
		[Route("{id:guid}/remover-despesa/{despesaId:guid}")]
		public async Task RemoverDespesaAsync(Guid id, Guid despesaId)
		{
			await _competenciaService.RemoverDespesaAsync(id, despesaId);

			await _unitOfWork.CommitAsync();
		}

		[HttpGet]
		[Route("{id:guid}/lancamentos")]
		public async Task<IEnumerable<LancamentoDto>> ObterLancamentosPorCompetenciaIdAsync(Guid id)
		{
			return await _competenciaFinder.ObterLancamentosPorCompetenciaIdAsync(id);
		}
	}
}
