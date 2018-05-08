using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedKernel.Common
{
	public class DomainEvents
	{
		[ThreadStatic]
		private static List<Delegate> actions;

		public DomainEvents(Container container)
		{
			_container = container;
		}

		private Container _container { get; }

		public void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (actions == null)
			{
				actions = new List<Delegate>();
			}
			actions.Add(callback);
		}

		public void ClearCallbacks()
		{
			actions = null;
		}

		public void Raise<T>(T args) where T : IDomainEvent
		{
			foreach (var handler in _container.GetAllInstances<IHandler<T>>())
			{
				handler.Handle(args);
			}

			if (actions != null)
			{
				foreach (var action in actions)
				{
					if (action is Action<T>)
					{
						((Action<T>)action)(args);
					}
				}
			}
		}
	}
}
