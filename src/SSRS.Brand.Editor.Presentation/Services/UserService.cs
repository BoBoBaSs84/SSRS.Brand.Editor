// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

namespace SSRS.Brand.Editor.Presentation.Services;

/// <summary>
/// The user service implementation.
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class UserService : IUserService
{
	/// <inheritdoc/>
	public string Name => Environment.UserName;

	/// <inheritdoc/>
	public string Domain => Environment.UserDomainName;

	/// <inheritdoc/>
	public string Machine => Environment.MachineName;
}
