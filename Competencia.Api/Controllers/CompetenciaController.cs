using Microsoft.AspNetCore.Mvc;
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
