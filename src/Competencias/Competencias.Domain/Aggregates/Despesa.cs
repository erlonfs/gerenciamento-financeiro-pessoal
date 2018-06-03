using System;

namespace Competencias.Domain.Aggregates
{
	public class Despesa : Lancamento
	{
		protected Despesa() { }
		private Despesa(Guid id) : base(id) { }

		public static Despesa Create(Guid id, int categoriaId, DateTime data, string descricao, bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao)
		{
			if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
			if (data <= DateTime.MinValue) throw new ArgumentOutOfRangeException(nameof(data));
			if (valor < 0) throw new ArgumentOutOfRangeException(nameof(valor));
			if (!Enum.IsDefined(typeof(FormaDePagamento), formaDePagto)) throw new ArgumentOutOfRangeException(nameof(formaDePagto));
			if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentNullException(nameof(descricao));
			if (string.IsNullOrWhiteSpace(anotacao)) throw new ArgumentNullException(nameof(anotacao));
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
