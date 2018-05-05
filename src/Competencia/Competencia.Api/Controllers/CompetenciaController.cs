using Competencia.Data;
using Competencia.Domain.CompetenciaAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common.ValueObjects;
using System;
using System.Collections.Generic;

namespace Competencia.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/competencia")]
	public class CompetenciaController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public CompetenciaController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		[HttpPost]
		public void Post()
		{

			var id = Guid.NewGuid();
			var competencia = new CompetenciaAggregateRoot(id, new Ano(2018), Mes.Janeiro);

			_appDbContext.Competencia.Add(new Data.Model.Competencia
			{
				DataCriacao = DateTime.Now,
				Mes = (int)competencia.Mes,
				Ano = competencia.Ano.Numero,
				Lancamentos = new HashSet<Data.Model.Lancamento>
					{
						new Data.Model.Lancamento
						{
							DataCriacao = DateTime.Now,
							Anotacao = "Teste de lançamento",
							CategoriaId = 1,
							Data = new DateTime(2018,04,02),
							Descricao = "Compras",
							FormaDePagtoId = (int)FormaDePagamento.Credito,
							IsLancamentoPago = true,
							TipoId = (int)LancamentoTipo.Despesa,
							Valor = 78.64M

						}
					}
			});

			_appDbContext.SaveChanges();


		}

	}
}
