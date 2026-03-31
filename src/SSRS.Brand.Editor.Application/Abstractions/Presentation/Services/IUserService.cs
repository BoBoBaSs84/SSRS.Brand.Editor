// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

/// <summary>
/// The interface for the user service.
/// </summary>
public interface IUserService
{
	/// <summary>
	/// The user name.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// The user domain name.
	/// </summary>
	string Domain { get; }

	/// <summary>
	/// The user machine name.
	/// </summary>
	string Machine { get; }
}
