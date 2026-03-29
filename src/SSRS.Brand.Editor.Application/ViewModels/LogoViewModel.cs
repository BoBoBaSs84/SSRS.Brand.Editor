using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The logo view model class.
/// </summary>
/// <param name="model">The brand package model instance to use.</param>
/// <param name="fileDialogService">The file dialog service instance to use.</param>
/// <param name="fileProvider">The file provider instance to use.</param>
/// <param name="notificationService">The notification service instance to use.</param>
public sealed class LogoViewModel(BrandPackageModel model, IFileDialogService fileDialogService, IFileProvider fileProvider, INotificationService notificationService) : ViewModelBase
{
	private static readonly byte[] PngSignature = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];

	private IActionCommand? _browseCommand;
	private IActionCommand? _removeCommand;

	/// <summary>
	/// The brand package model instance.
	/// </summary>
	public BrandPackageModel Model => model;

	/// <summary>
	/// Indicates whether a logo is currently loaded.
	/// </summary>
	public bool HasLogo => model.Logo is not null && model.Logo.Length > 0;

	/// <summary>
	/// The raw bytes of the logo image.
	/// </summary>
	public byte[]? LogoBytes => model.Logo;

	/// <summary>
	/// The command to browse and select a logo file.
	/// </summary>
	public IActionCommand BrowseCommand
		=> _browseCommand ??= new ActionCommand(BrowseLogo);

	/// <summary>
	/// The command to remove the current logo.
	/// </summary>
	public IActionCommand RemoveCommand
		=> _removeCommand ??= new ActionCommand(RemoveLogo, () => HasLogo);

	/// <summary>
	/// Browses for a PNG logo file and loads it.
	/// </summary>
	private void BrowseLogo()
	{
		string? filePath = fileDialogService.ShowOpenImageDialog();
		if (filePath is null)
			return;

		byte[] bytes = fileProvider.ReadAllBytes(filePath);

		if (!IsValidPng(bytes))
		{
			notificationService.ShowError("The selected file is not a valid PNG image.");
			return;
		}

		model.Logo = bytes;
		RaiseLogoChanged();
	}

	/// <summary>
	/// Removes the current logo from the brand package.
	/// </summary>
	private void RemoveLogo()
	{
		model.Logo = null;
		RaiseLogoChanged();
	}

	private void RaiseLogoChanged()
	{
		RaisePropertyChanged(nameof(HasLogo));
		RaisePropertyChanged(nameof(LogoBytes));
	}

	private static bool IsValidPng(byte[] bytes)
	{
		if (bytes.Length < PngSignature.Length)
			return false;

		for (int i = 0; i < PngSignature.Length; i++)
		{
			if (bytes[i] != PngSignature[i])
				return false;
		}

		return true;
	}
}
