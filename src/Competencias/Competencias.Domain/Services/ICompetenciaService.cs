using Competencias.Domain.Aggregates;
using System;
using System.Threading.Tasks;

namespace Competencias.Domain.Services
{
	public interface ICompetenciaService
    {
		Task<Competencia> CriarAsync(Guid id, int ano, int mes);
		Task<Lancamento> AdicionarReceitaAsync(Guid competenciaId, Guid id, int categoriaId, DateTime data, string descricao,
											   bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao);
		Task<Lancamento> AdicionarDespesaAsync(Guid competenciaId, Guid id, int categoriaId, DateTime data, string descricao,
											   bool isLancamentoPago, decimal valor, FormaDePagamento formaDePagto, string anotacao);
	}
}
