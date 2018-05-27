using System.ComponentModel;

namespace Competencias.Domain.Aggregates
{
	public enum FormaDePagamento
	{
		[Description("Débito")]
		Debito = 1,

		[Description("Crédito")]
		Credito = 2,

		[Description("Dinheiro")]
		Dinheiro = 3,

		[Description("Boleto")]
		Boleto = 4
	}
}
