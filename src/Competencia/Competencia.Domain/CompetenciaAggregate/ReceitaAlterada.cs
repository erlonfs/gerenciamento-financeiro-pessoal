﻿using System;
using SharedKernel.Common;

namespace Competencia.Domain.CompetenciaAggregate
{
	public class ReceitaAlterada : IDomainEvent
	{
		public Guid AggregateId { get; }
		public Receita Receita { get; }
		public DateTime DataCriacao { get; }

		public ReceitaAlterada(Guid aggregateId, Receita receita)
		{
			AggregateId = aggregateId;
			Receita = receita;
			DataCriacao = DateTime.Now;
		}
	}

}
