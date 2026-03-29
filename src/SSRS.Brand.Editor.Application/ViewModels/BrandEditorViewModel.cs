using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The brand editor view model class.
/// </summary>
/// <param name="brandPackageService">The brand package service instance to use.</param>
/// <param name="fileDialogService">The file dialog service instance to use.</param>
/// <param name="fileProvider">The file provider instance to use.</param>
/// <param name="notificationService">The notification service instance to use.</param>
/// <param name="loggerService">The logger service instance to use.</param>
public sealed class BrandEditorViewModel(IBrandPackageService brandPackageService, IFileDialogService fileDialogService, IFileProvider fileProvider, INotificationService notificationService, ILoggerService<BrandEditorViewModel> loggerService) : ViewModelBase
{
	private const string FileFilter = "Brand Package (*.zip)|*.zip|All Files (*.*)|*.*";

	private static readonly Action<ILogger, Exception?> LogException =
		LoggerMessage.Define(LogLevel.Error, 0, "An error occurred in the brand editor.");

	private BrandPackageModel? _model;
	private MetadataViewModel? _metadataViewModel;
	private InterfaceColorsViewModel? _interfaceColorsViewModel;
	private ThemeColorsViewModel? _themeColorsViewModel;
	private LogoViewModel? _logoViewModel;
	private string? _currentFilePath;
	private IActionCommand? _newCommand;
	private IAsyncActionCommand? _openCommand;
	private IAsyncActionCommand? _saveCommand;
	private IAsyncActionCommand? _saveAsCommand;
	private IActionCommand? _closeCommand;

	/// <summary>
	/// The current brand package model.
	/// </summary>
	public BrandPackageModel? Model
	{
		get => _model;
		private set
		{
			SetProperty(ref _model, value);
			RaisePropertyChanged(nameof(HasPackage));
		}
	}

	/// <summary>
	/// Indicates whether a brand package is currently loaded.
	/// </summary>
	public bool HasPackage => _model is not null;

	/// <summary>
	/// The file path of the currently loaded brand package.
	/// </summary>
	public string? CurrentFilePath
	{
		get => _currentFilePath;
		private set => SetProperty(ref _currentFilePath, value);
	}

	/// <summary>
	/// The metadata view model for the current brand package.
	/// </summary>
	public MetadataViewModel? MetadataViewModel
	{
		get => _metadataViewModel;
		private set => SetProperty(ref _metadataViewModel, value);
	}

	/// <summary>
	/// The interface colors view model for the current brand package.
	/// </summary>
	public InterfaceColorsViewModel? InterfaceColorsViewModel
	{
		get => _interfaceColorsViewModel;
		private set => SetProperty(ref _interfaceColorsViewModel, value);
	}

	/// <summary>
	/// The theme colors view model for the current brand package.
	/// </summary>
	public ThemeColorsViewModel? ThemeColorsViewModel
	{
		get => _themeColorsViewModel;
		private set => SetProperty(ref _themeColorsViewModel, value);
	}

	/// <summary>
	/// The logo view model for the current brand package.
	/// </summary>
	public LogoViewModel? LogoViewModel
	{
		get => _logoViewModel;
		private set => SetProperty(ref _logoViewModel, value);
	}

	/// <summary>
	/// The command to create a new brand package.
	/// </summary>
	public IActionCommand NewCommand
		=> _newCommand ??= new ActionCommand(NewPackage);

	/// <summary>
	/// The command to open an existing brand package.
	/// </summary>
	public IAsyncActionCommand OpenCommand
		=> _openCommand ??= new AsyncActionCommand(OpenPackageAsync, null, OnError);

	/// <summary>
	/// The command to save the current brand package.
	/// </summary>
	public IAsyncActionCommand SaveCommand
		=> _saveCommand ??= new AsyncActionCommand(SavePackageAsync, () => HasPackage, OnError);

	/// <summary>
	/// The command to save the current brand package to a new file.
	/// </summary>
	public IAsyncActionCommand SaveAsCommand
		=> _saveAsCommand ??= new AsyncActionCommand(SavePackageAsAsync, () => HasPackage, OnError);

	/// <summary>
	/// The command to close the current brand package.
	/// </summary>
	public IActionCommand CloseCommand
		=> _closeCommand ??= new ActionCommand(ClosePackage, () => HasPackage);

	private void NewPackage()
	{
		BrandPackageModel model = new();
		model.Metadata.Name = "New Brand";
		model.Metadata.Version = MetadataModel.DefaultVersion;
		model.ColorScheme.Name = "New Brand";
		model.ColorScheme.Version = "1.0";
		SetModel(model);
		CurrentFilePath = null;
	}

	private async Task OpenPackageAsync()
	{
		string? filePath = fileDialogService.ShowOpenFileDialog(FileFilter, "Open Brand Package");
		if (filePath is null)
			return;

		BrandPackageModel model = await brandPackageService.ReadAsync(filePath)
			.ConfigureAwait(false);

		SetModel(model);
		CurrentFilePath = filePath;
	}

	private async Task SavePackageAsync()
	{
		if (_model is null)
			return;

		if (string.IsNullOrEmpty(_currentFilePath))
		{
			await SavePackageAsAsync().ConfigureAwait(false);
			return;
		}

		await brandPackageService.WriteAsync(_currentFilePath, _model)
			.ConfigureAwait(false);
	}

	private async Task SavePackageAsAsync()
	{
		if (_model is null)
			return;

		string? filePath = fileDialogService.ShowSaveFileDialog(FileFilter, "Save Brand Package", _model.Metadata.Name);
		if (filePath is null)
			return;

		await brandPackageService.WriteAsync(filePath, _model)
			.ConfigureAwait(false);

		CurrentFilePath = filePath;
	}

	private void ClosePackage()
	{
		SetModel(null);
		CurrentFilePath = null;
	}

	private void SetModel(BrandPackageModel? model)
	{
		Model = model;

		if (model is not null)
		{
			MetadataViewModel = new MetadataViewModel(model.Metadata);
			InterfaceColorsViewModel = new InterfaceColorsViewModel(model.ColorScheme.Interface);
			ThemeColorsViewModel = new ThemeColorsViewModel(model.ColorScheme.Theme);
			LogoViewModel = new LogoViewModel(model, fileDialogService, fileProvider, notificationService);
		}
		else
		{
			MetadataViewModel = null;
			InterfaceColorsViewModel = null;
			ThemeColorsViewModel = null;
			LogoViewModel = null;
		}
	}

	private void OnError(Exception exception)
	{
		loggerService.Log(LogException, exception);
		notificationService.ShowError(exception.Message);
	}
}
