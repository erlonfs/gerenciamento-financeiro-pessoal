using System;

namespace Competencias.Domain.Aggregates
{
	public sealed class Despesa : Lancamento
	{
		private Despesa(Guid id) : base(id) { }

		public static Despesa Create(Guid id, int categoriaId, DateTime data, string descricao, bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao)
		{
			if (categoriaId <= 0) throw new ArgumentOutOfRangeException(nameof(categoriaId));

			return new Despesa(id)
			{
				TipoId = (int)LancamentoTipo.Despesa,
				Tipo = LancamentoTipo.Despesa.ToString(),
				DataCriacao = DateTime.Now,
				CategoriaId = categoriaId,
				Data = data,
				Descricao = descricao,
				IsLancamentoPago = isLancamentoPago,
				Valor = valor,
				FormaDePagtoId = (int)formaDePagto,
				Anotacao = anotacao
			};
		}

		public static decimal operator +(decimal valor, Despesa depesa)
		{
			return valor - depesa.Valor;
		}

		public static decimal operator -(decimal valor, Despesa depesa)
		{
			return valor + depesa.Valor;
		}
	}
}
