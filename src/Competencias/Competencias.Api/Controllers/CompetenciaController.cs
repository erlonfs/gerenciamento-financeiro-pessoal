using Competencias.Api.Dtos;
using Competencias.Domain.Aggregates;
using Competencias.Domain.Exceptions;
using Competencias.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Competencias.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompetenciaRepository _competenciaRepository;

		public CompetenciaController(IUnitOfWork unitOfWork, ICompetenciaRepository competenciaRepository)
		{
			_unitOfWork = unitOfWork;
			_competenciaRepository = competenciaRepository;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CompetenciaDto dto)
		{
			var id = Guid.NewGuid();

			var competencia = new Competencia(id, DateTime.Now, new Ano(dto.Ano), (Mes)dto.Mes);

			await _competenciaRepository.AddAsync(competencia);

			await _unitOfWork.CommitAsync();

			return competencia.EntityId;

		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task AdicionarReceitaAsync(Guid id, LancamentoDto dto)
		{
			var competencia = await _competenciaRepository.GetByEntityIdAsync(id);
			if (competencia == null) throw new CompetenciaNaoEncontradaException();

			var receita = Receita.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			competencia.AdicionarReceita(receita);

			await _unitOfWork.CommitAsync();
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-despesa")]
		public async Task AdicionarDespesaAsync(Guid id, LancamentoDto dto)
		{
			var competencia = await _competenciaRepository.GetByEntityIdAsync(id);
			if (competencia == null) throw new CompetenciaNaoEncontradaException();

			var despesa = Despesa.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			competencia.AdicionarDespesa(despesa);

			await _unitOfWork.CommitAsync();
		}

	}
}
