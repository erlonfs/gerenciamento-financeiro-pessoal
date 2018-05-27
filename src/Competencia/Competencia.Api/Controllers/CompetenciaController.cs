using Competencias.Api.Dtos;
using Competencias.Domain;
using Competencias.Domain.Aggregates;
using Competencias.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;
using SharedKernel.Common.ValueObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Competencias.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private AppDbContext _context;

		public CompetenciaController(IUnitOfWork unitOfWork, AppDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}

		[HttpPost]
		[Route("")]
		public async Task<Guid> CriarAsync(CompetenciaDto dto)
		{
			var id = Guid.NewGuid();

			var competencia = new Domain.Aggregates.Competencia().Create(id, DateTime.Now, new Ano(dto.Ano), (Mes)dto.Mes);

			_context.Competencia.Add(competencia);

			await _context.SaveChangesAsync();

			return competencia.EntityId;

		}

		[HttpPost]
		[Route("{id:guid}/adicionar-receita")]
		public async Task AdicionarReceitaAsync(Guid id, LancamentoDto dto)
		{
			var competencia = await _context.Competencia.SingleOrDefaultAsync(x => x.EntityId == id);
			if (competencia == null) throw new CompetenciaNaoEncontradaException();

			var receita = Receita.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			competencia.AdicionarReceita(receita);

			await _context.SaveChangesAsync();
		}

		[HttpPost]
		[Route("{id:guid}/adicionar-despesa")]
		public async Task AdicionarDespesaAsync(Guid id, LancamentoDto dto)
		{
			var competencia = await _context.Competencia.SingleOrDefaultAsync(x => x.EntityId == id);
			if (competencia == null) throw new CompetenciaNaoEncontradaException();

			var despesa = Despesa.Create(Guid.NewGuid(), dto.CategoriaId, dto.Data, dto.Descricao,
										dto.IsLancamentoPago, dto.Valor, dto.FormaDePagto, dto.Anotacao);

			competencia.AdicionarDespesa(despesa);

			await _context.SaveChangesAsync();
		}

	}
}
