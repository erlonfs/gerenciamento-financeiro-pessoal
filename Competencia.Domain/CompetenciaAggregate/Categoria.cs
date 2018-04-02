using SharedKernel.Common;
using System;

namespace Lancamentos.Domain.CompetenciaAggregate
{
	public class Categoria : Entity<int>
	{
		public string Nome { get; private set; }

		public Categoria(int id) : base(id)
		{

		}
	}
}
