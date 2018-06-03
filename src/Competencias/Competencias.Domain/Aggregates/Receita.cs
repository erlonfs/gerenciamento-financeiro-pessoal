using System;

namespace Competencias.Domain.Aggregates
{
	public class Receita : Lancamento
	{
		protected Receita() { }
		private Receita(Guid id) : base(id) { }

		public static Receita Create(Guid id, int categoriaId, DateTime data, string descricao,
										bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao)
		{
			if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
			if (data <= DateTime.MinValue) throw new ArgumentOutOfRangeException(nameof(data));
			if (valor < 0) throw new ArgumentOutOfRangeException(nameof(valor));
			if (!Enum.IsDefined(typeof(FormaDePagamento), formaDePagto)) throw new ArgumentOutOfRangeException(nameof(formaDePagto));
			if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentNullException(nameof(descricao));
			if (string.IsNullOrWhiteSpace(anotacao)) throw new ArgumentNullException(nameof(anotacao));
			if (categoriaId <= 0) throw new ArgumentOutOfRangeException(nameof(categoriaId));

			return new Receita(id)
			{
				TipoId = (int)LancamentoTipo.Receita,
				Tipo = LancamentoTipo.Receita.ToString(),
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

		public static decimal operator +(decimal valor, Receita receita)
		{
			return valor + receita.Valor;
		}

		public static decimal operator -(decimal valor, Receita receita)
		{
			return valor - receita.Valor;
		}
	}
}
