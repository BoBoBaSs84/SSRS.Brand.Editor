// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;

/// <summary>
/// The interface for the web service.
/// </summary>
public interface IWebService
{
	/// <summary>
	/// Returns the wikpedia pizza content.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the request.</param>
	/// <returns>The wikipedia pizza content.</returns>
	Task<string> GetPizzaContentAsync(CancellationToken cancellationToken = default);
}
