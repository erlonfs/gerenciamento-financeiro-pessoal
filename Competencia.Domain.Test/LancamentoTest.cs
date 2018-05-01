using Competencia.Domain.CompetenciaAggregate;
using FluentAssertions;
using System;
using Xunit;

namespace Competencia.Domain.Test
{
	public class LancamentoTest
	{
		private readonly int _categoriaId = 1;
		private readonly DateTime _data = DateTime.Today;
		private readonly string _descricao = "Carne";
		private readonly bool _isLancamentoPago = false;
		private readonly decimal _valor = 45.9M;
		private readonly FormaDePagamento _formaDePagto = FormaDePagamento.Dinheiro;
		private readonly string _anotacao = "Carne para o churrasco";

		[Fact]
		public void Quando_criar_receita_deve_constar_todos_os_dados_informados()
		{
			var receita = Receita.Create(_categoriaId, _data, _descricao, _isLancamentoPago, _valor,
										   _formaDePagto, _anotacao);

			receita.Tipo.Should().Be(LancamentoTipo.Receita);
			receita.CategoriaId.Should().Be(_categoriaId);
			receita.Data.Should().Be(_data);
			receita.Descricao.Should().Be(_descricao);
			receita.IsLancamentoPago.Should().Be(_isLancamentoPago);
			receita.Valor.Should().Be(_valor);
			receita.FormaDePagto.Should().Be(_formaDePagto);
			receita.Anotacao.Should().Be(_anotacao);
		}

		[Fact]
		public void Quando_criar_despesa_deve_constar_todos_os_dados_informados()
		{
			var despesa = Despesa.Create(_categoriaId, _data, _descricao, _isLancamentoPago, _valor,
										   _formaDePagto, _anotacao);

			despesa.Tipo.Should().Be(LancamentoTipo.Despesa);
			despesa.CategoriaId.Should().Be(_categoriaId);
			despesa.Data.Should().Be(_data);
			despesa.Descricao.Should().Be(_descricao);
			despesa.IsLancamentoPago.Should().Be(_isLancamentoPago);
			despesa.Valor.Should().Be(_valor);
			despesa.FormaDePagto.Should().Be(_formaDePagto);
			despesa.Anotacao.Should().Be(_anotacao);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Nao_pode_criar_receita_com_categoria_invalida(int categoriaId)
		{
			Action act = () => Receita.Create(categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("categoriaId"); ;

		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Nao_pode_criar_despesa_com_categoria_invalida(int categoriaId)
		{
			Action act = () => Receita.Create(categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("categoriaId"); ;

		}
	}
}
