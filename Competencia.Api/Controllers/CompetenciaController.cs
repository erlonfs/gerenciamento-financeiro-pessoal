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
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet("{id:guid}", Name = "Get")]
		public string Get(Guid id)
		{
			return "value";
		}

		[HttpPost]
		public void Post([FromBody]string value)
		{
			var options = new DbContextOptionsBuilder<AppDbContext>()
			 .UseInMemoryDatabase(databaseName: "test")
			 .Options;

			using (var context = new AppDbContext(options))
			{
				var id = Guid.NewGuid();
				var competencia = new CompetenciaAggregateRoot(id, new Ano(2018), Mes.Janeiro);

				context.Competencia.Add(new Data.Model.Competencia {
					Mes = (int)competencia.Mes,
					Ano = competencia.Ano.Numero
				});

				context.SaveChanges();
			}

		}

		[HttpPut("{id:guid}")]
		public void Put(Guid id, [FromBody]string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
