using System;

namespace SharedKernel.Common
{
	public interface IDomainEvent
	{
		DateTime DataCriacao { get; }
	}
}
