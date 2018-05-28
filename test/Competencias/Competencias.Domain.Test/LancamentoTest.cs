using Competencias.Domain.Aggregates;
using FluentAssertions;
using System;
using Xunit;

namespace Competencias.Domain.Test
{
	public class LancamentoTest
	{
		private readonly Guid _id = Guid.NewGuid();
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
			var receita = Receita.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
										   _formaDePagto, _anotacao);

			receita.TipoId.Should().Be((int)LancamentoTipo.Receita);
			receita.CategoriaId.Should().Be(_categoriaId);
			receita.Data.Should().Be(_data);
			receita.Descricao.Should().Be(_descricao);
			receita.IsLancamentoPago.Should().Be(_isLancamentoPago);
			receita.Valor.Should().Be(_valor);
			receita.FormaDePagtoId.Should().Be((int)_formaDePagto);
			receita.Anotacao.Should().Be(_anotacao);
		}

		[Fact]
		public void Quando_criar_despesa_deve_constar_todos_os_dados_informados()
		{
			var despesa = Despesa.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
										   _formaDePagto, _anotacao);

			despesa.TipoId.Should().Be((int)LancamentoTipo.Despesa);
			despesa.CategoriaId.Should().Be(_categoriaId);
			despesa.Data.Should().Be(_data);
			despesa.Descricao.Should().Be(_descricao);
			despesa.IsLancamentoPago.Should().Be(_isLancamentoPago);
			despesa.Valor.Should().Be(_valor);
			despesa.FormaDePagtoId.Should().Be((int)_formaDePagto);
			despesa.Anotacao.Should().Be(_anotacao);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Nao_pode_criar_receita_com_categoria_invalida(int categoriaId)
		{
			Action act = () => Receita.Create(_id, categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("categoriaId"); ;

		}

		[Fact]
		public void Nao_pode_criar_receita_com_id_invalido()
		{
			Action act = () => Receita.Create(Guid.Empty, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("id"); ;

		}

		[InlineData(0001, 01, 01)]
		[Theory]
		public void Nao_pode_criar_receita_com_data_invalida(int ano, int mes, int dia)
		{
			Action act = () => Receita.Create(_id, _categoriaId, new DateTime(ano, mes, dia), _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("data"); ;

		}

		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[Theory]
		public void Nao_pode_criar_receita_com_descricao_invalida(string descricao)
		{
			Action act = () => Receita.Create(_id, _categoriaId, _data, descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("descricao"); ;

		}

		[InlineData(-5)]
		[InlineData(-0.60)]
		[Theory]
		public void Nao_pode_criar_receita_com_valor_negativo(decimal valor)
		{
			Action act = () => Receita.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("valor"); ;

		}

		[InlineData(-1)]
		[InlineData(0)]
		[InlineData(5)]
		[Theory]
		public void Nao_pode_criar_receita_com_formaDePagto_invalido(int formaDePagtoId)
		{
			Action act = () => Receita.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  (FormaDePagamento)formaDePagtoId, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("formaDePagto"); ;

		}

		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[Theory]
		public void Nao_pode_criar_receita_com_anotacao_invalida(string anotacao)
		{
			Action act = () => Receita.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("anotacao"); ;

		}

		[Fact]
		public void Nao_pode_criar_despesa_com_id_invalido()
		{
			Action act = () => Despesa.Create(Guid.Empty, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("id"); ;

		}

		[InlineData(0001, 01, 01)]
		[Theory]
		public void Nao_pode_criar_despesa_com_data_invalida(int ano, int mes, int dia)
		{
			Action act = () => Despesa.Create(_id, _categoriaId, new DateTime(ano, mes, dia), _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("data"); ;

		}

		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[Theory]
		public void Nao_pode_criar_despesa_com_descricao_invalida(string descricao)
		{
			Action act = () => Despesa.Create(_id, _categoriaId, _data, descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("descricao"); ;

		}

		[InlineData(-5)]
		[InlineData(-0.60)]
		[Theory]
		public void Nao_pode_criar_despesa_com_valor_negativo(decimal valor)
		{
			Action act = () => Despesa.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("valor"); ;

		}

		[InlineData(-1)]
		[InlineData(0)]
		[InlineData(5)]
		[Theory]
		public void Nao_pode_criar_despesa_com_formaDePagto_invalido(int formaDePagtoId)
		{
			Action act = () => Despesa.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  (FormaDePagamento)formaDePagtoId, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("formaDePagto"); ;

		}

		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[Theory]
		public void Nao_pode_criar_despesa_com_anotacao_invalida(string anotacao)
		{
			Action act = () => Despesa.Create(_id, _categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, anotacao);

			Assert.Throws<ArgumentNullException>(act).ParamName.Should().Be("anotacao"); ;

		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Nao_pode_criar_despesa_com_categoria_invalida(int categoriaId)
		{
			Action act = () => Despesa.Create(_id, categoriaId, _data, _descricao, _isLancamentoPago, _valor,
							  _formaDePagto, _anotacao);

			Assert.Throws<ArgumentOutOfRangeException>(act).ParamName.Should().Be("categoriaId"); ;

		}
	}
}
