// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Application.Abstractions.Application.Services;

namespace SSRS.Brand.Editor.Application.Services;

/// <summary>
/// Represents a simple event service for publishing and subscribing to events.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Event service simple implementation.")]
internal sealed class EventService : IEventService
{
	private readonly Dictionary<Type, List<Action<object>>> _subscribers = [];

	public void Subscribe<T>(Action<T> handler) where T : notnull
	{
		if (!_subscribers.TryGetValue(typeof(T), out var handlers))
		{
			handlers = [];
			_subscribers[typeof(T)] = handlers;
		}

		handlers.Add(obj => handler((T)obj));
	}

	public void Publish<T>(T message) where T : notnull
	{
		if (_subscribers.TryGetValue(typeof(T), out List<Action<object>>? handlers))
			handlers.ForEach(handler => handler(message));
	}
}
