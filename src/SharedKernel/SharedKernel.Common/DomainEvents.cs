﻿using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Common
{
	public class DomainEvents : IDomainEvents
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
			if (actions == null) { actions = new List<Delegate>(); }
			actions.Add(callback);
		}

		public void ClearCallbacks()
		{
			actions = null;
		}

		public async Task Raise<T>(T args, bool fromHistory = false) where T : IDomainEvent
		{
			foreach (var handler in _container.GetAllInstances<IHandler<T>>())
			{
				if (fromHistory) continue;

				await handler.HandleAsync(args);

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
