using System;
using System.Threading.Tasks;

namespace SharedKernel.Common
{
	public interface IDomainEvents
	{
		void Register<T>(Action<T> callback) where T : IDomainEvent;
		Task Raise<T>(T args) where T : IDomainEvent;
		void ClearCallbacks();
	}
}
