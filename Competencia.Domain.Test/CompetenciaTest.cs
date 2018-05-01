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
			LancamentoStub.CreateDespesaComValor(50),
			LancamentoStub.CreateReceitaComValor(100),
			LancamentoStub.CreateDespesaComValor(400),
			LancamentoStub.CreateReceitaComValor(2500),
		};

		[Fact]
		public void Quando_criar_uma_competencia_deve_contar_dados_informados()
		{
			var competencia = new CompetenciaAggregateRoot(_competenciaId, _ano, _mes);

			competencia.Id.Should().Be(_competenciaId);
			competencia.Ano.Should().Be(_ano);
			competencia.Mes.Should().Be(_mes);
		}

		[Theory]
		[InlineData(15, 10, -5, -15, 10)]
		[InlineData(5, 5, 0, -5, 5)]
		[InlineData(1, 0, -1, -1, 0)]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(99, 99, 0, -99, 99)]
		[InlineData(99, 0, -99, -99, 0)]
		public void Quando_adicionar_lancamentos_deve_constar_saldos_e_totais_corretamente(decimal despesa, decimal receita, decimal saldo, decimal totalContasAPagar, decimal totalContasAReceber)
		{
			var competencia = new CompetenciaAggregateRoot(_competenciaId, _ano, _mes);

			competencia.AdicionarDespesa(LancamentoStub.CreateDespesaComValor(despesa));
			competencia.AdicionarReceita(LancamentoStub.CreateReceitaComValor(receita));

			competencia.Saldo.Should().Be(saldo);
			competencia.TotalContasAPagar.Should().Be(totalContasAPagar);
			competencia.TotalContasAReceber.Should().Be(totalContasAReceber);
		}

		[Fact]
		public void Quando_remover_lancamento_deve_constar_saldos_e_totais_corretamente()
		{
			var competencia = new CompetenciaAggregateRoot(_competenciaId, _ano, _mes);

			var lancamentoARemover = LancamentoStub.CreateDespesaComValor(50);

			competencia.AdicionarDespesa(lancamentoARemover);
			competencia.AdicionarReceita(LancamentoStub.CreateReceitaComValor(10));
			competencia.RemoverDespesa(lancamentoARemover);

			competencia.Saldo.Should().Be(10);
			competencia.TotalContasAPagar.Should().Be(0);
			competencia.TotalContasAReceber.Should().Be(10);
		}
	}
}
