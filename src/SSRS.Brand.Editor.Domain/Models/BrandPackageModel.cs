// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

/// <summary>
/// The brand package model representing a complete SSRS brand package.
/// </summary>
/// <remarks>
/// An SSRS brand package is a ZIP file containing a <c>metadata.xml</c>, 
/// a <c>colors.json</c>, and an optional <c>logo.png</c>.
/// </remarks>
public sealed class BrandPackageModel : ModelBase
{
	private byte[]? _logo;

	/// <summary>
	/// Initializes a new instance of the <see cref="BrandPackageModel"/> class.
	/// </summary>
	public BrandPackageModel()
	{
		Metadata = new MetadataModel();
		ColorScheme = new ColorSchemeModel();
	}

	/// <summary>
	/// The brand package metadata.
	/// </summary>
	public MetadataModel Metadata { get; }

	/// <summary>
	/// The color scheme containing interface and theme colors.
	/// </summary>
	public ColorSchemeModel ColorScheme { get; }

	/// <summary>
	/// The raw bytes of the optional logo image (PNG format).
	/// </summary>
	/// <remarks>
	/// When <see langword="null"/>, the brand package does not include a logo.
	/// The recommended dimensions are approximately 290 x 60 pixels.
	/// </remarks>
	public byte[]? Logo
	{
		get => _logo;
		set
		{
			SetProperty(ref _logo, value);
			Metadata.HasLogo = value is not null && value.Length > 0;
		}
	}
}
