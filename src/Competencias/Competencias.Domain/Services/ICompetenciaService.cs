using Competencias.Domain.Aggregates;
using SharedKernel.Common.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Competencias.Domain.Services
{
	public interface ICompetenciaService
	{
		Task<Competencia> CriarAsync(Guid id, int ano, Mes mes);

		Task<Lancamento> AdicionarReceitaAsync(Guid competenciaId, Guid id, int categoriaId, DateTime data, string descricao, bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao);
		Task RemoverReceitaAsync(Guid competenciaId, Guid receitaId);

		Task<Lancamento> AdicionarDespesaAsync(Guid competenciaId, Guid id, int categoriaId, DateTime data, string descricao, bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao);
		Task RemoverDespesaAsync(Guid competenciaId, Guid despesaId);
	}
}
