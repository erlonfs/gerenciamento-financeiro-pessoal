﻿using Competencia.Domain.CompetenciaAggregate;
using System;

namespace Competencia.Api.Dtos
{
	public class LancamentoDto
	{
		public int CategoriaId { get; set; }
		public DateTime Data { get; set; }
		public string Descricao { get; set; }
		public bool IsLancamentoPago { get; set; }
		public decimal Valor { get; set; }
		public FormaDePagamento FormaDePagto { get; set; }
		public string Anotacao { get; set; }
	}
}
