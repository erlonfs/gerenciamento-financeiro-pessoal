using Competencia.Api.Dtos;
using Competencia.Domain.CompetenciaAggregate;
using Competencia.Domain.Services;
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
		private readonly ICompetenciaService _competenciaService;

		public CompetenciaController(IUnitOfWork unitOfWork, ICompetenciaService competenciaService)
		{
			_unitOfWork = unitOfWork;
			_competenciaService = competenciaService;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CompetenciaDto dto)
		{
			var competencia = await _competenciaService.CriarAsync(dto.Ano, dto.Mes);

			await _unitOfWork.CommitAsync();

			return competencia.Id;
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task AdicionarReceitaAsync(Guid id, LancamentoDto dto)
		{
			var competencia = await _competenciaService.ObterPorIdAsync(id);
			if (competencia == null) throw new Exception("Competencia não encontrada.");

			var receita = Receita.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao, 
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			competencia.AdicionarReceita(receita);

			await _unitOfWork.CommitAsync();
		}

	}
}
