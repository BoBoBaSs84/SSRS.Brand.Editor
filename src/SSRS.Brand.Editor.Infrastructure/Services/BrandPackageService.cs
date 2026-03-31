// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Converters;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Infrastructure.Services;

/// <summary>
/// The brand package service for reading and writing SSRS brand packages.
/// </summary>
internal sealed class BrandPackageService : IBrandPackageService
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		WriteIndented = true,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		Converters = { new JsonDrawingColorConverter() }
	};

	/// <inheritdoc/>
	public async Task<BrandPackageModel> ReadAsync(string filePath, CancellationToken cancellationToken = default)
	{
		BrandPackageModel model = new();

		using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
		using ZipArchive archive = new(fileStream, ZipArchiveMode.Read);

		ZipArchiveEntry? metadataEntry = archive.GetEntry(MetadataModel.ColorsPath.Replace(MetadataModel.ColorsPath, "metadata.xml"));

		MetadataModel metadata = ReadMetadata(archive);
		model.Metadata.Name = metadata.Name;
		model.Metadata.Version = metadata.Version;

		ColorSchemeModel colorScheme = await ReadColorSchemeAsync(archive, cancellationToken)
			.ConfigureAwait(false);

		model.ColorScheme.Name = colorScheme.Name;
		model.ColorScheme.Version = colorScheme.Version;
		CopyInterfaceColors(colorScheme.Interface, model.ColorScheme.Interface);
		CopyThemeColors(colorScheme.Theme, model.ColorScheme.Theme);

		if (metadata.HasLogo)
		{
			byte[]? logo = ReadLogo(archive);
			model.Logo = logo;
		}

		return model;
	}

	/// <inheritdoc/>
	public async Task WriteAsync(string filePath, BrandPackageModel model, CancellationToken cancellationToken = default)
	{
		using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
		using ZipArchive archive = new(fileStream, ZipArchiveMode.Create);

		WriteMetadata(archive, model.Metadata);
		await WriteColorSchemeAsync(archive, model.ColorScheme, cancellationToken)
			.ConfigureAwait(false);

		if (model.Metadata.HasLogo && model.Logo is not null)
			WriteLogo(archive, model.Logo);
	}

	private static MetadataModel ReadMetadata(ZipArchive archive)
	{
		ZipArchiveEntry entry = archive.GetEntry("metadata.xml")
			?? throw new InvalidOperationException("The brand package does not contain a metadata.xml file.");

		using Stream stream = entry.Open();
		XDocument document = XDocument.Load(stream);

		XNamespace ns = MetadataModel.XmlNamespace;
		XElement root = document.Root
			?? throw new InvalidOperationException("The metadata.xml file is empty or invalid.");

		MetadataModel metadata = new()
		{
			Name = root.Attribute("name")?.Value ?? string.Empty,
			Version = root.Attribute("version")?.Value ?? MetadataModel.DefaultVersion
		};

		XElement? contents = root.Element(ns + "Contents");
		if (contents is not null)
		{
			XElement? logoItem = contents.Elements(ns + "Item")
				.FirstOrDefault(e => string.Equals(e.Attribute("key")?.Value, "logo", StringComparison.OrdinalIgnoreCase));
			metadata.HasLogo = logoItem is not null;
		}

		return metadata;
	}

	private static void WriteMetadata(ZipArchive archive, MetadataModel metadata)
	{
		ZipArchiveEntry entry = archive.CreateEntry("metadata.xml");

		XNamespace ns = MetadataModel.XmlNamespace;
		XDocument document = new(
			new XDeclaration("1.0", "utf-8", null),
			new XElement(ns + "SystemResourcePackage",
				new XAttribute("type", MetadataModel.PackageType),
				new XAttribute("version", metadata.Version),
				new XAttribute("name", metadata.Name),
				new XElement(ns + "Contents",
					new XElement(ns + "Item",
						new XAttribute("key", "colors"),
						new XAttribute("path", MetadataModel.ColorsPath)),
					metadata.HasLogo
						? new XElement(ns + "Item",
							new XAttribute("key", "logo"),
							new XAttribute("path", MetadataModel.LogoPath))
						: null)));

		using Stream stream = entry.Open();
		using StreamWriter writer = new(stream, Encoding.UTF8);
		document.Save(writer);
	}

	private static async Task<ColorSchemeModel> ReadColorSchemeAsync(ZipArchive archive, CancellationToken cancellationToken)
	{
		ZipArchiveEntry entry = archive.GetEntry(MetadataModel.ColorsPath)
			?? throw new InvalidOperationException("The brand package does not contain a colors.json file.");

		using Stream stream = entry.Open();
		ColorSchemeDto? dto = await JsonSerializer.DeserializeAsync<ColorSchemeDto>(stream, JsonOptions, cancellationToken)
			.ConfigureAwait(false);

		if (dto is null)
			throw new InvalidOperationException("The colors.json file could not be deserialized.");

		ColorSchemeModel model = new()
		{
			Name = dto.Name ?? string.Empty,
			Version = dto.Version ?? "1.0"
		};

		if (dto.Interface is not null)
			MapInterfaceFromDto(dto.Interface, model.Interface);

		if (dto.Theme is not null)
			MapThemeFromDto(dto.Theme, model.Theme);

		return model;
	}

	private static async Task WriteColorSchemeAsync(ZipArchive archive, ColorSchemeModel model, CancellationToken cancellationToken)
	{
		ZipArchiveEntry entry = archive.CreateEntry(MetadataModel.ColorsPath);

		ColorSchemeDto dto = new()
		{
			Name = model.Name,
			Version = model.Version,
			Interface = MapInterfaceToDto(model.Interface),
			Theme = MapThemeToDto(model.Theme)
		};

		using Stream stream = entry.Open();
		await JsonSerializer.SerializeAsync(stream, dto, JsonOptions, cancellationToken)
			.ConfigureAwait(false);
	}

	private static byte[]? ReadLogo(ZipArchive archive)
	{
		ZipArchiveEntry? entry = archive.GetEntry(MetadataModel.LogoPath);
		if (entry is null)
			return null;

		using Stream stream = entry.Open();
		using MemoryStream memoryStream = new();
		stream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	private static void WriteLogo(ZipArchive archive, byte[] logo)
	{
		ZipArchiveEntry entry = archive.CreateEntry(MetadataModel.LogoPath);
		using Stream stream = entry.Open();
		stream.Write(logo, 0, logo.Length);
	}

	private static void CopyInterfaceColors(InterfaceColorsModel source, InterfaceColorsModel target)
	{
		target.Primary = source.Primary;
		target.PrimaryAlt = source.PrimaryAlt;
		target.PrimaryAlt2 = source.PrimaryAlt2;
		target.PrimaryAlt3 = source.PrimaryAlt3;
		target.PrimaryAlt4 = source.PrimaryAlt4;
		target.PrimaryContrast = source.PrimaryContrast;
		target.Secondary = source.Secondary;
		target.SecondaryAlt = source.SecondaryAlt;
		target.SecondaryAlt2 = source.SecondaryAlt2;
		target.SecondaryAlt3 = source.SecondaryAlt3;
		target.SecondaryContrast = source.SecondaryContrast;
		target.NeutralPrimary = source.NeutralPrimary;
		target.NeutralPrimaryAlt = source.NeutralPrimaryAlt;
		target.NeutralPrimaryAlt2 = source.NeutralPrimaryAlt2;
		target.NeutralPrimaryAlt3 = source.NeutralPrimaryAlt3;
		target.NeutralPrimaryContrast = source.NeutralPrimaryContrast;
		target.NeutralSecondary = source.NeutralSecondary;
		target.NeutralSecondaryAlt = source.NeutralSecondaryAlt;
		target.NeutralSecondaryAlt2 = source.NeutralSecondaryAlt2;
		target.NeutralSecondaryAlt3 = source.NeutralSecondaryAlt3;
		target.NeutralSecondaryContrast = source.NeutralSecondaryContrast;
		target.NeutralTertiary = source.NeutralTertiary;
		target.NeutralTertiaryAlt = source.NeutralTertiaryAlt;
		target.NeutralTertiaryAlt2 = source.NeutralTertiaryAlt2;
		target.NeutralTertiaryAlt3 = source.NeutralTertiaryAlt3;
		target.NeutralTertiaryContrast = source.NeutralTertiaryContrast;
		target.Danger = source.Danger;
		target.Success = source.Success;
		target.Warning = source.Warning;
		target.Info = source.Info;
		target.DangerContrast = source.DangerContrast;
		target.SuccessContrast = source.SuccessContrast;
		target.WarningContrast = source.WarningContrast;
		target.InfoContrast = source.InfoContrast;
		target.KpiGood = source.KpiGood;
		target.KpiBad = source.KpiBad;
		target.KpiNeutral = source.KpiNeutral;
		target.KpiNone = source.KpiNone;
		target.KpiGoodContrast = source.KpiGoodContrast;
		target.KpiBadContrast = source.KpiBadContrast;
		target.KpiNeutralContrast = source.KpiNeutralContrast;
		target.KpiNoneContrast = source.KpiNoneContrast;
		target.ItemTypeIconColor = source.ItemTypeIconColor;
		target.ReportIconBackground = source.ReportIconBackground;
		target.ExcelIconBackground = source.ExcelIconBackground;
		target.FolderIconBackground = source.FolderIconBackground;
		target.DatasetIconBackground = source.DatasetIconBackground;
		target.OtherIconBackground = source.OtherIconBackground;
		target.PrimaryButton = source.PrimaryButton;
		target.PrimaryButtonHover = source.PrimaryButtonHover;
		target.PrimaryButtonPressed = source.PrimaryButtonPressed;
		target.Link = source.Link;
		target.LinkHover = source.LinkHover;
		target.LinkVisited = source.LinkVisited;
		target.RadioButtonCheckBox = source.RadioButtonCheckBox;
		target.RadioButtonCheckBoxHover = source.RadioButtonCheckBoxHover;
	}

	private static void CopyThemeColors(ThemeColorsModel source, ThemeColorsModel target)
	{
		target.DataPoints.Clear();
		foreach (Color color in source.DataPoints)
			target.DataPoints.Add(color);

		target.Good = source.Good;
		target.Bad = source.Bad;
		target.Neutral = source.Neutral;
		target.None = source.None;
		target.Background = source.Background;
		target.Foreground = source.Foreground;
		target.MapBase = source.MapBase;
		target.PanelBackground = source.PanelBackground;
		target.PanelForeground = source.PanelForeground;
		target.PanelAccent = source.PanelAccent;
		target.TableAccent = source.TableAccent;
		target.AltBackground = source.AltBackground;
		target.AltForeground = source.AltForeground;
		target.AltMapBase = source.AltMapBase;
		target.AltPanelBackground = source.AltPanelBackground;
		target.AltPanelForeground = source.AltPanelForeground;
		target.AltPanelAccent = source.AltPanelAccent;
		target.AltTableAccent = source.AltTableAccent;
	}

	#region DTO Mapping

	private static void MapInterfaceFromDto(InterfaceColorsDto dto, InterfaceColorsModel model)
	{
		model.Primary = dto.Primary;
		model.PrimaryAlt = dto.PrimaryAlt;
		model.PrimaryAlt2 = dto.PrimaryAlt2;
		model.PrimaryAlt3 = dto.PrimaryAlt3;
		model.PrimaryAlt4 = dto.PrimaryAlt4;
		model.PrimaryContrast = dto.PrimaryContrast;
		model.Secondary = dto.Secondary;
		model.SecondaryAlt = dto.SecondaryAlt;
		model.SecondaryAlt2 = dto.SecondaryAlt2;
		model.SecondaryAlt3 = dto.SecondaryAlt3;
		model.SecondaryContrast = dto.SecondaryContrast;
		model.NeutralPrimary = dto.NeutralPrimary;
		model.NeutralPrimaryAlt = dto.NeutralPrimaryAlt;
		model.NeutralPrimaryAlt2 = dto.NeutralPrimaryAlt2;
		model.NeutralPrimaryAlt3 = dto.NeutralPrimaryAlt3;
		model.NeutralPrimaryContrast = dto.NeutralPrimaryContrast;
		model.NeutralSecondary = dto.NeutralSecondary;
		model.NeutralSecondaryAlt = dto.NeutralSecondaryAlt;
		model.NeutralSecondaryAlt2 = dto.NeutralSecondaryAlt2;
		model.NeutralSecondaryAlt3 = dto.NeutralSecondaryAlt3;
		model.NeutralSecondaryContrast = dto.NeutralSecondaryContrast;
		model.NeutralTertiary = dto.NeutralTertiary;
		model.NeutralTertiaryAlt = dto.NeutralTertiaryAlt;
		model.NeutralTertiaryAlt2 = dto.NeutralTertiaryAlt2;
		model.NeutralTertiaryAlt3 = dto.NeutralTertiaryAlt3;
		model.NeutralTertiaryContrast = dto.NeutralTertiaryContrast;
		model.Danger = dto.Danger;
		model.Success = dto.Success;
		model.Warning = dto.Warning;
		model.Info = dto.Info;
		model.DangerContrast = dto.DangerContrast;
		model.SuccessContrast = dto.SuccessContrast;
		model.WarningContrast = dto.WarningContrast;
		model.InfoContrast = dto.InfoContrast;
		model.KpiGood = dto.KpiGood;
		model.KpiBad = dto.KpiBad;
		model.KpiNeutral = dto.KpiNeutral;
		model.KpiNone = dto.KpiNone;
		model.KpiGoodContrast = dto.KpiGoodContrast;
		model.KpiBadContrast = dto.KpiBadContrast;
		model.KpiNeutralContrast = dto.KpiNeutralContrast;
		model.KpiNoneContrast = dto.KpiNoneContrast;
		model.ItemTypeIconColor = dto.ItemTypeIconColor;
		model.ReportIconBackground = dto.ReportIconBackground;
		model.ExcelIconBackground = dto.ExcelIconBackground;
		model.FolderIconBackground = dto.FolderIconBackground;
		model.DatasetIconBackground = dto.DatasetIconBackground;
		model.OtherIconBackground = dto.OtherIconBackground;
		model.PrimaryButton = dto.PrimaryButton;
		model.PrimaryButtonHover = dto.PrimaryButtonHover;
		model.PrimaryButtonPressed = dto.PrimaryButtonPressed;
		model.Link = dto.Link;
		model.LinkHover = dto.LinkHover;
		model.LinkVisited = dto.LinkVisited;
		model.RadioButtonCheckBox = dto.RadioButtonCheckBox;
		model.RadioButtonCheckBoxHover = dto.RadioButtonCheckBoxHover;
	}

	private static InterfaceColorsDto MapInterfaceToDto(InterfaceColorsModel model)
		=> new()
		{
			Primary = model.Primary,
			PrimaryAlt = model.PrimaryAlt,
			PrimaryAlt2 = model.PrimaryAlt2,
			PrimaryAlt3 = model.PrimaryAlt3,
			PrimaryAlt4 = model.PrimaryAlt4,
			PrimaryContrast = model.PrimaryContrast,
			Secondary = model.Secondary,
			SecondaryAlt = model.SecondaryAlt,
			SecondaryAlt2 = model.SecondaryAlt2,
			SecondaryAlt3 = model.SecondaryAlt3,
			SecondaryContrast = model.SecondaryContrast,
			NeutralPrimary = model.NeutralPrimary,
			NeutralPrimaryAlt = model.NeutralPrimaryAlt,
			NeutralPrimaryAlt2 = model.NeutralPrimaryAlt2,
			NeutralPrimaryAlt3 = model.NeutralPrimaryAlt3,
			NeutralPrimaryContrast = model.NeutralPrimaryContrast,
			NeutralSecondary = model.NeutralSecondary,
			NeutralSecondaryAlt = model.NeutralSecondaryAlt,
			NeutralSecondaryAlt2 = model.NeutralSecondaryAlt2,
			NeutralSecondaryAlt3 = model.NeutralSecondaryAlt3,
			NeutralSecondaryContrast = model.NeutralSecondaryContrast,
			NeutralTertiary = model.NeutralTertiary,
			NeutralTertiaryAlt = model.NeutralTertiaryAlt,
			NeutralTertiaryAlt2 = model.NeutralTertiaryAlt2,
			NeutralTertiaryAlt3 = model.NeutralTertiaryAlt3,
			NeutralTertiaryContrast = model.NeutralTertiaryContrast,
			Danger = model.Danger,
			Success = model.Success,
			Warning = model.Warning,
			Info = model.Info,
			DangerContrast = model.DangerContrast,
			SuccessContrast = model.SuccessContrast,
			WarningContrast = model.WarningContrast,
			InfoContrast = model.InfoContrast,
			KpiGood = model.KpiGood,
			KpiBad = model.KpiBad,
			KpiNeutral = model.KpiNeutral,
			KpiNone = model.KpiNone,
			KpiGoodContrast = model.KpiGoodContrast,
			KpiBadContrast = model.KpiBadContrast,
			KpiNeutralContrast = model.KpiNeutralContrast,
			KpiNoneContrast = model.KpiNoneContrast,
			ItemTypeIconColor = model.ItemTypeIconColor,
			ReportIconBackground = model.ReportIconBackground,
			ExcelIconBackground = model.ExcelIconBackground,
			FolderIconBackground = model.FolderIconBackground,
			DatasetIconBackground = model.DatasetIconBackground,
			OtherIconBackground = model.OtherIconBackground,
			PrimaryButton = model.PrimaryButton,
			PrimaryButtonHover = model.PrimaryButtonHover,
			PrimaryButtonPressed = model.PrimaryButtonPressed,
			Link = model.Link,
			LinkHover = model.LinkHover,
			LinkVisited = model.LinkVisited,
			RadioButtonCheckBox = model.RadioButtonCheckBox,
			RadioButtonCheckBoxHover = model.RadioButtonCheckBoxHover
		};

	private static void MapThemeFromDto(ThemeColorsDto dto, ThemeColorsModel model)
	{
		model.DataPoints.Clear();
		if (dto.DataPoints is not null)
		{
			foreach (Color color in dto.DataPoints)
				model.DataPoints.Add(color);
		}

		model.Good = dto.Good;
		model.Bad = dto.Bad;
		model.Neutral = dto.Neutral;
		model.None = dto.None;
		model.Background = dto.Background;
		model.Foreground = dto.Foreground;
		model.MapBase = dto.MapBase;
		model.PanelBackground = dto.PanelBackground;
		model.PanelForeground = dto.PanelForeground;
		model.PanelAccent = dto.PanelAccent;
		model.TableAccent = dto.TableAccent;
		model.AltBackground = dto.AltBackground;
		model.AltForeground = dto.AltForeground;
		model.AltMapBase = dto.AltMapBase;
		model.AltPanelBackground = dto.AltPanelBackground;
		model.AltPanelForeground = dto.AltPanelForeground;
		model.AltPanelAccent = dto.AltPanelAccent;
		model.AltTableAccent = dto.AltTableAccent;
	}

	private static ThemeColorsDto MapThemeToDto(ThemeColorsModel model)
		=> new()
		{
			DataPoints = [.. model.DataPoints],
			Good = model.Good,
			Bad = model.Bad,
			Neutral = model.Neutral,
			None = model.None,
			Background = model.Background,
			Foreground = model.Foreground,
			MapBase = model.MapBase,
			PanelBackground = model.PanelBackground,
			PanelForeground = model.PanelForeground,
			PanelAccent = model.PanelAccent,
			TableAccent = model.TableAccent,
			AltBackground = model.AltBackground,
			AltForeground = model.AltForeground,
			AltMapBase = model.AltMapBase,
			AltPanelBackground = model.AltPanelBackground,
			AltPanelForeground = model.AltPanelForeground,
			AltPanelAccent = model.AltPanelAccent,
			AltTableAccent = model.AltTableAccent
		};

	#endregion

	#region DTOs

	private sealed class ColorSchemeDto
	{
		public string? Name { get; set; }
		public string? Version { get; set; }
		public InterfaceColorsDto? Interface { get; set; }
		public ThemeColorsDto? Theme { get; set; }
	}

	private sealed class InterfaceColorsDto
	{
		public Color Primary { get; set; }
		public Color PrimaryAlt { get; set; }
		public Color PrimaryAlt2 { get; set; }
		public Color PrimaryAlt3 { get; set; }
		public Color PrimaryAlt4 { get; set; }
		public Color PrimaryContrast { get; set; }
		public Color Secondary { get; set; }
		public Color SecondaryAlt { get; set; }
		public Color SecondaryAlt2 { get; set; }
		public Color SecondaryAlt3 { get; set; }
		public Color SecondaryContrast { get; set; }
		public Color NeutralPrimary { get; set; }
		public Color NeutralPrimaryAlt { get; set; }
		public Color NeutralPrimaryAlt2 { get; set; }
		public Color NeutralPrimaryAlt3 { get; set; }
		public Color NeutralPrimaryContrast { get; set; }
		public Color NeutralSecondary { get; set; }
		public Color NeutralSecondaryAlt { get; set; }
		public Color NeutralSecondaryAlt2 { get; set; }
		public Color NeutralSecondaryAlt3 { get; set; }
		public Color NeutralSecondaryContrast { get; set; }
		public Color NeutralTertiary { get; set; }
		public Color NeutralTertiaryAlt { get; set; }
		public Color NeutralTertiaryAlt2 { get; set; }
		public Color NeutralTertiaryAlt3 { get; set; }
		public Color NeutralTertiaryContrast { get; set; }
		public Color Danger { get; set; }
		public Color Success { get; set; }
		public Color Warning { get; set; }
		public Color Info { get; set; }
		public Color DangerContrast { get; set; }
		public Color SuccessContrast { get; set; }
		public Color WarningContrast { get; set; }
		public Color InfoContrast { get; set; }
		public Color KpiGood { get; set; }
		public Color KpiBad { get; set; }
		public Color KpiNeutral { get; set; }
		public Color KpiNone { get; set; }
		public Color KpiGoodContrast { get; set; }
		public Color KpiBadContrast { get; set; }
		public Color KpiNeutralContrast { get; set; }
		public Color KpiNoneContrast { get; set; }
		public Color ItemTypeIconColor { get; set; }
		public Color ReportIconBackground { get; set; }
		public Color ExcelIconBackground { get; set; }
		public Color FolderIconBackground { get; set; }
		public Color DatasetIconBackground { get; set; }
		public Color OtherIconBackground { get; set; }
		public Color PrimaryButton { get; set; }
		public Color PrimaryButtonHover { get; set; }
		public Color PrimaryButtonPressed { get; set; }
		public Color Link { get; set; }
		public Color LinkHover { get; set; }
		public Color LinkVisited { get; set; }
		public Color RadioButtonCheckBox { get; set; }
		public Color RadioButtonCheckBoxHover { get; set; }
	}

	private sealed class ThemeColorsDto
	{
		public Color[]? DataPoints { get; set; }
		public Color Good { get; set; }
		public Color Bad { get; set; }
		public Color Neutral { get; set; }
		public Color None { get; set; }
		public Color Background { get; set; }
		public Color Foreground { get; set; }
		public Color MapBase { get; set; }
		public Color PanelBackground { get; set; }
		public Color PanelForeground { get; set; }
		public Color PanelAccent { get; set; }
		public Color TableAccent { get; set; }
		public Color AltBackground { get; set; }
		public Color AltForeground { get; set; }
		public Color AltMapBase { get; set; }
		public Color AltPanelBackground { get; set; }
		public Color AltPanelForeground { get; set; }
		public Color AltPanelAccent { get; set; }
		public Color AltTableAccent { get; set; }
	}

	#endregion
}
