// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The interface colors view model class.
/// </summary>
/// <param name="model">The interface colors model instance to use.</param>
public sealed class InterfaceColorsViewModel(InterfaceColorsModel model) : ViewModelBase
{
	/// <summary>
	/// The interface colors model instance.
	/// </summary>
	public InterfaceColorsModel Model => model;
}
