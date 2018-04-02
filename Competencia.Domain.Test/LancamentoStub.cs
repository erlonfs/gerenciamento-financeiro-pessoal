using Competencia.Domain.CompetenciaAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competencia.Domain.Test
{
    public class LancamentoStub
    {
		private static readonly LancamentoTipo _tipo = LancamentoTipo.Receita;
		private static readonly int _categoriaId = 1;
		private static readonly DateTime _data = DateTime.Today;
		private static readonly string _descricao = "Carne";
		private static readonly bool _isLancamentoPago = false;
		private static readonly decimal _valor = 45.9M;
		private static readonly FormaDePagamento _formaDePagto = FormaDePagamento.Dinheiro;
		private static readonly string _anotacao = "Carne para o churrasco";

		public static Lancamento Create()
		{
			return Lancamento.Create(_tipo, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
									   _formaDePagto, _anotacao);
		}

		public static Lancamento CreateDespesaComValor(decimal valor)
		{
			return Lancamento.Create(LancamentoTipo.Despesa, _categoriaId, _data, _descricao, _isLancamentoPago, valor,
									   _formaDePagto, _anotacao);
		}

		public static Lancamento CreateReceitaComValor(decimal valor)
		{
			return Lancamento.Create(LancamentoTipo.Receita, _categoriaId, _data, _descricao, _isLancamentoPago, valor,
									   _formaDePagto, _anotacao);
		}
	}
}
