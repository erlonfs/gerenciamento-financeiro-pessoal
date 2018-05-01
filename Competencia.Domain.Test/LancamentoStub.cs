using Competencia.Domain.CompetenciaAggregate;
using System;

namespace Competencia.Domain.Test
{
	public class LancamentoStub
	{
		private static readonly int _categoriaId = 1;
		private static readonly DateTime _data = DateTime.Today;
		private static readonly string _descricao = "Carne";
		private static readonly bool _isLancamentoPago = false;
		private static readonly FormaDePagamento _formaDePagto = FormaDePagamento.Dinheiro;
		private static readonly string _anotacao = "Carne para o churrasco";

		public static Despesa CreateDespesaComValor(Guid id, decimal valor)
		{
			return Despesa.Create(id, _categoriaId, _data, _descricao, _isLancamentoPago, valor, _formaDePagto, _anotacao);
		}

		public static Despesa CreateDespesaComValor(decimal valor)
		{
			return Despesa.Create(Guid.NewGuid(), _categoriaId, _data, _descricao, _isLancamentoPago, valor, _formaDePagto, _anotacao);
		}

		public static Receita CreateReceitaComValor(Guid id, decimal valor)
		{
			return Receita.Create(id, _categoriaId, _data, _descricao, _isLancamentoPago, valor, _formaDePagto, _anotacao);
		}

		public static Receita CreateReceitaComValor(decimal valor)
		{
			return Receita.Create(Guid.NewGuid(), _categoriaId, _data, _descricao, _isLancamentoPago, valor, _formaDePagto, _anotacao);
		}
	}
}
