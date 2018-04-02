using Xunit;
using Competencia.Domain.CompetenciaAggregate;
using System;
using SharedKernel.Common;
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

		[Fact]
		public void Quando_adicionar_lancamentos_deve_constar_saldos_e_totais_corretamente()
		{
			var lancamentos = new List<Lancamento>();

			lancamentos.Add(LancamentoStub.CreateDespesaComValor(15M));
			lancamentos.Add(LancamentoStub.CreateReceitaComValor(10M));

			var competencia = new CompetenciaAggregate.Competencia(_competenciaId, _ano, _mes, lancamentos);

			competencia.Saldo.Should().Be(-5M);
			competencia.TotalContasAPagar.Should().Be(15M);
			competencia.TotalContasAReceber.Should().Be(10M);
		}
	}
}
