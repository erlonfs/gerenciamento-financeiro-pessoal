using Competencias.Api.Dtos;
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

		public CompetenciaController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CompetenciaDto dto)
		{
			//var competencia = await _competenciaService.CriarAsync(dto.Ano, dto.Mes);

			await _unitOfWork.CommitAsync();

			//return competencia.Id;

			return Guid.NewGuid();
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task AdicionarReceitaAsync(Guid id, LancamentoDto dto)
		{
			//var competencia = await _competenciaService.ObterPorIdAsync(id);
			//if (competencia == null) throw new Exception("Competencia não encontrada.");

			//var receita = Receita.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao,
			//							dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			//competencia.AdicionarReceita(receita);

			await _unitOfWork.CommitAsync();
		}

	}
}
