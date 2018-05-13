using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Common
{
	public class DomainEventsFromHistory : IDomainEvents
	{
		[ThreadStatic]
		private static List<Delegate> actions;

		public DomainEventsFromHistory()
		{

		}

		public void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (actions == null) { actions = new List<Delegate>(); }
			actions.Add(callback);
		}

		public void ClearCallbacks()
		{
			actions = null;
		}

		public Task Raise<T>(T args) where T : IDomainEvent
		{
			if (actions != null)
			{
				foreach (var action in actions)
				{
					if (action is Action<T>) { ((Action<T>)action)(args); }
				}
			}

			return Task.CompletedTask;

		}
	}
}
