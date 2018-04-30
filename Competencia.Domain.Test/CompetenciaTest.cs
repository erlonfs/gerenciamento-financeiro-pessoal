using Xunit;
using Competencia.Domain.CompetenciaAggregate;
using System;
using SharedKernel.Common.ValueObjects;
using FluentAssertions;
using System.Collections.Generic;

namespace Competencia.Domain.Test
{
	public class CompetenciaTest
	{
		private readonly Guid _competenciaId = Guid.NewGuid();
		private readonly Mes _mes = Mes.Janeiro;
		private readonly Ano _ano = new Ano(2018);

		private readonly List<Lancamento> _lancamentos = new List<Lancamento>
		{
			LancamentoStub.Create()
		};

		[Fact]
		public void Quando_criar_uma_competencia_deve_contar_dados_informados()
		{
			var competencia = new CompetenciaAggregate.Competencia(_competenciaId, _ano, _mes, _lancamentos);

			competencia.Id.Should().Be(_competenciaId);
			competencia.Ano.Should().Be(_ano);
			competencia.Mes.Should().Be(_mes);
			competencia.Lancamentos.Count.Should().Be(_lancamentos.Count);
		}

		[Theory]
		[InlineData(15, 10, -5, 15, 10)]
		[InlineData(5, 5, 0, 5, 5)]
		[InlineData(1, 0, -1, 1, 0)]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(99, 99, 0, 99, 99)]
		[InlineData(99, 0, -99, 99, 0)]
		public void Quando_adicionar_lancamentos_deve_constar_saldos_e_totais_corretamente(decimal despesa, decimal receita, decimal saldo, decimal totalContasAPagar, decimal totalContasAReceber)
		{
			var lancamentos = new List<Lancamento>();

			lancamentos.Add(LancamentoStub.CreateDespesaComValor(despesa));
			lancamentos.Add(LancamentoStub.CreateReceitaComValor(receita));

			var competencia = new CompetenciaAggregate.Competencia(_competenciaId, _ano, _mes, lancamentos);

			competencia.Saldo.Should().Be(saldo);
			competencia.TotalContasAPagar.Should().Be(totalContasAPagar);
			competencia.TotalContasAReceber.Should().Be(totalContasAReceber);
		}
	}
}
