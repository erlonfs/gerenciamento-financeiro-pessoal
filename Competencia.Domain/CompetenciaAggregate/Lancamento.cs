using SharedKernel.Common;
using System;

namespace Competencia.Domain.CompetenciaAggregate
{
	public sealed class Lancamento : Entity<Guid>
	{
		public LancamentoTipo Tipo { get; private set; }
		public int CategoriaId { get; private set; }
		public DateTime Data { get; private set; }
		public string Descricao { get; private set; }
		public bool IsLancamentoPago { get; private set; }
		public decimal Valor { get; private set; }
		public FormaDePagamento FormaDePagto { get; private set; }
		public string Anotacao { get; private set; }

		private Lancamento(Guid id)
		{

		}

		public static Lancamento Create(LancamentoTipo tipo, int categoriaId, DateTime data, string descricao,
										bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao)
		{

			if (!Enum.IsDefined(typeof(LancamentoTipo), tipo)) throw new ArgumentOutOfRangeException(nameof(tipo));
			if (categoriaId <= 0) throw new ArgumentOutOfRangeException(nameof(categoriaId));

			return new Lancamento(new Guid())
			{
				Tipo = tipo,
				CategoriaId = categoriaId,
				Data = data,
				Descricao = descricao,
				IsLancamentoPago = isLancamentoPago,
				Valor = valor,
				FormaDePagto = formaDePagto,
				Anotacao = anotacao
			};
		}
	}
}
