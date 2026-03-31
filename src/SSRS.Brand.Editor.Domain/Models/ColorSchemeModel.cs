// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

/// <summary>
/// The color scheme model representing the complete <c>colors.json</c> file.
/// </summary>
public sealed class ColorSchemeModel : ModelBase
{
	private string _name = string.Empty;
	private string _version = "1.0";

	/// <summary>
	/// Initializes a new instance of the <see cref="ColorSchemeModel"/> class.
	/// </summary>
	public ColorSchemeModel()
	{
		Interface = new InterfaceColorsModel();
		Theme = new ThemeColorsModel();
	}

	/// <summary>
	/// The name of the color scheme.
	/// </summary>
	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	/// <summary>
	/// The version of the color scheme.
	/// </summary>
	public string Version
	{
		get => _version;
		set => SetProperty(ref _version, value);
	}

	/// <summary>
	/// The interface colors that control the web portal UI appearance.
	/// </summary>
	public InterfaceColorsModel Interface { get; }

	/// <summary>
	/// The theme colors for mobile reports and chart theming.
	/// </summary>
	public ThemeColorsModel Theme { get; }
}
