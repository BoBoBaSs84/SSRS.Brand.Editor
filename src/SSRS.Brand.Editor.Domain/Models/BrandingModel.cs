#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

[ExcludeFromCodeCoverage(Justification = "Generated")]
public sealed class BrandingModel : ModelBase
{
	private ColorsModel _colors;
	private MetadataModel _metadata;

	public BrandingModel()
	{
		_colors = new();
		_metadata = new();
	}

	public ColorsModel Colors
	{
		get => _colors;
		set => SetProperty(ref _colors, value);
	}

	public MetadataModel Metadata
	{
		get => _metadata;
		set => SetProperty(ref _metadata, value);
	}
}
