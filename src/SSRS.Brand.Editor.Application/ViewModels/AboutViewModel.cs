// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The about view model class.
/// </summary>
/// <param name="model">The model instance to use.</param>
public sealed class AboutViewModel(AboutModel model) : ViewModelBase
{
	/// <summary>
	/// The model instance to use.
	/// </summary>
	public AboutModel Model => model;
}
