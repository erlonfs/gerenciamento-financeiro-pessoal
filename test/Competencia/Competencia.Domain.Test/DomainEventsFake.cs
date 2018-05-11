using SharedKernel.Common;
using System;
using System.Collections.Generic;

namespace Competencia.Domain.Test
{
	public class DomainEventsFake : IDomainEvents
	{
		private List<Delegate> actions;

		public void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (actions == null) { actions = new List<Delegate>(); }
			actions.Add(callback);
		}

		public void ClearCallbacks()
		{
			actions = null;
		}

		public void Raise<T>(T args) where T : IDomainEvent
		{
			if (actions != null)
			{
				foreach (var action in actions)
				{
					if (action is Action<T>) { ((Action<T>)action)(args); }
				}
			}
		}
	}
}
