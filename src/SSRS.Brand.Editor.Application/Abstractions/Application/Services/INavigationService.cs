// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.Abstractions.Application.Services;

/// <summary>
/// The navgigation service interface.
/// </summary>
public interface INavigationService
{
	/// <summary>
	/// The current view model.
	/// </summary>
	ViewModelBase CurrentView { get; }

	/// <summary>
	/// Navigates to the provided view model.
	/// </summary>
	/// <typeparam name="T">The view model to navigate to.</typeparam>
	void NavigateTo<T>() where T : ViewModelBase;
}
