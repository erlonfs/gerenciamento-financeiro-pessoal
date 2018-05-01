using System;

namespace Competencia.Domain.CompetenciaAggregate
{
	public sealed class Receita : Lancamento
	{
		public override LancamentoTipo Tipo => LancamentoTipo.Receita;

		public Receita(Guid id) : base(id) { }

		public static Receita Create(int categoriaId, DateTime data, string descricao,
										bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao)
		{

			if (categoriaId <= 0) throw new ArgumentOutOfRangeException(nameof(categoriaId));

			return new Receita(Guid.NewGuid())
			{
				CategoriaId = categoriaId,
				Data = data,
				Descricao = descricao,
				IsLancamentoPago = isLancamentoPago,
				Valor = valor,
				FormaDePagto = formaDePagto,
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
