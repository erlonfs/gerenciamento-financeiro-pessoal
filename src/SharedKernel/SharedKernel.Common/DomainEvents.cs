using SimpleInjector;
using System;
using System.Collections.Generic;

namespace SharedKernel.Common
{
	public class DomainEvents
	{
		[ThreadStatic]
		private static List<Delegate> actions;

		public static void Init(Container container)
		{
			_container = container;
		}

		static Container _container { get; set; }

		public static void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (actions == null) { actions = new List<Delegate>(); }
			actions.Add(callback);
		}

		public void ClearCallbacks()
		{
			actions = null;
		}

		public static void Raise<T>(T args) where T : IDomainEvent
		{
			if (_container != null)
			{
				foreach (var handler in _container.GetAllInstances<IHandler<T>>())
				{
					handler.HandleAsync(args).ConfigureAwait(true);
				}
			}

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
