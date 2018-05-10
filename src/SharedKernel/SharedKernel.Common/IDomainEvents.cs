using System;

namespace SharedKernel.Common
{
	public interface IDomainEvents
	{
		void Register<T>(Action<T> callback) where T : IDomainEvent;
		void Raise<T>(T args) where T : IDomainEvent;
		void ClearCallbacks();
	}
}
