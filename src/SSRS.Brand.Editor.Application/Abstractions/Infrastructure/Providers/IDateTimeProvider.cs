// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;

/// <summary>
/// This interface defines a contract for date time provider.
/// </summary>
/// <remarks>
/// Serves as an abstraction for the <see cref="DateTime"/> properties.
/// </remarks>
public interface IDateTimeProvider
{
	/// <inheritdoc cref="DateTime.Now"/>
	public DateTime Now { get; }

	/// <inheritdoc cref="DateTime.UtcNow"/>
	public DateTime UtcNow { get; }

	/// <inheritdoc cref="DateTime.TimeOfDay"/>
	public TimeSpan TimeOfDay { get; }

	/// <inheritdoc cref="DateTime.Today"/>
	public DateTime Today { get; }

	/// <inheritdoc cref="DateTime.MaxValue"/>
	public DateTime MaxValue { get; }

	/// <inheritdoc cref="DateTime.MinValue"/>
	public DateTime MinValue { get; }
}
