using FluentAssertions;
using Lancamentos.Domain.CompetenciaAggregate;
using System;
using Xunit;

namespace Lancamentos.Domain.Test
{
	public class LancamentoTest
	{
		private readonly LancamentoTipo _tipo = LancamentoTipo.Receita;
		private readonly int _categoriaId = 1;
		private readonly DateTime _data = DateTime.Today;
		private readonly string _descricao = "Carne";
		private readonly bool _isLancamentoPago = false;
		private readonly decimal _valor = 45.9M;
		private readonly FormaDePagamento _formaDePagto = FormaDePagamento.Dinheiro;
		private readonly string _anotacao = "Carne para o churrasco";

		[Fact]
		public void Nao_pode_criar_lancamento_com_tipo_de_lancamento_invalido()
		{
			Action act = () => Lancamento.Create(default(LancamentoTipo), _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("tipo");

		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Nao_pode_criar_lancamento_com_categoria_invalida(int categoriaId)
		{
			Action act = () => Lancamento.Create(_tipo, categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("categoriaId"); ;


		}
	}
}
