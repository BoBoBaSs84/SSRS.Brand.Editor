using System.ComponentModel;
using System.Drawing;
using System.Windows;

using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
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
/// <param name="providerService">The provider service instance to use.</param>
/// <param name="navigationService">The navigation service instance to use.</param>
/// <param name="notificationService">The notification service instance to use.</param>
/// <param name="loggerService">The logger service instance to use.</param>
public sealed class BrandEditorViewModel(IBrandPackageService brandPackageService, IFileDialogService fileDialogService, IProviderService providerService, INavigationService navigationService, INotificationService notificationService, ILoggerService<BrandEditorViewModel> loggerService) : ViewModelBase
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
	private bool _isDirty;
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
	/// Indicates whether the current brand package has unsaved changes.
	/// </summary>
	public bool IsDirty
	{
		get => _isDirty;
		private set => SetProperty(ref _isDirty, value);
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
		if (!ConfirmDiscardChanges())
			return;

		BrandPackageModel model = new();
		model.Metadata.Name = "New Brand";
		model.Metadata.Version = MetadataModel.DefaultVersion;
		model.ColorScheme.Name = "New Brand";
		model.ColorScheme.Version = "1.0";
		ApplyDefaultColors(model);
		SetModel(model);
		CurrentFilePath = null;
		IsDirty = false;
		navigationService.NavigateTo<BrandEditorViewModel>();
	}

	private async Task OpenPackageAsync()
	{
		if (!ConfirmDiscardChanges())
			return;

		string? filePath = fileDialogService.ShowOpenFileDialog(FileFilter, "Open Brand Package");
		if (filePath is null)
			return;

		BrandPackageModel model = await brandPackageService.ReadAsync(filePath)
			.ConfigureAwait(false);

		SetModel(model);
		CurrentFilePath = filePath;
		IsDirty = false;
		navigationService.NavigateTo<BrandEditorViewModel>();
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

		IsDirty = false;
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
		IsDirty = false;
	}

	private void ClosePackage()
	{
		if (!ConfirmDiscardChanges())
			return;

		SetModel(null);
		CurrentFilePath = null;
		IsDirty = false;
	}

	private bool ConfirmDiscardChanges()
	{
		if (!_isDirty)
			return true;

		MessageBoxResult result = notificationService.ShowQuestion("You have unsaved changes. Do you want to continue and discard them?");
		return result is MessageBoxResult.Yes;
	}

	private void SetModel(BrandPackageModel? model)
	{
		UnsubscribeModelEvents();

		Model = model;

		if (model is not null)
		{
			SubscribeModelEvents(model);
			MetadataViewModel = new MetadataViewModel(model.Metadata);
			InterfaceColorsViewModel = new InterfaceColorsViewModel(model.ColorScheme.Interface);
			ThemeColorsViewModel = new ThemeColorsViewModel(model.ColorScheme.Theme);
			LogoViewModel = new LogoViewModel(model, fileDialogService, providerService.File, notificationService);
		}
		else
		{
			MetadataViewModel = null;
			InterfaceColorsViewModel = null;
			ThemeColorsViewModel = null;
			LogoViewModel = null;
		}
	}

	private void SubscribeModelEvents(BrandPackageModel model)
	{
		model.PropertyChanged += OnModelPropertyChanged;
		model.Metadata.PropertyChanged += OnModelPropertyChanged;
		model.ColorScheme.Interface.PropertyChanged += OnModelPropertyChanged;
		model.ColorScheme.Theme.PropertyChanged += OnModelPropertyChanged;
	}

	private void UnsubscribeModelEvents()
	{
		if (_model is null)
			return;

		_model.PropertyChanged -= OnModelPropertyChanged;
		_model.Metadata.PropertyChanged -= OnModelPropertyChanged;
		_model.ColorScheme.Interface.PropertyChanged -= OnModelPropertyChanged;
		_model.ColorScheme.Theme.PropertyChanged -= OnModelPropertyChanged;
	}

	private void OnModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		=> IsDirty = true;

	private static void ApplyDefaultColors(BrandPackageModel model)
	{
		var i = model.ColorScheme.Interface;
		i.Primary = Color.FromArgb(187, 33, 36);
		i.PrimaryAlt = Color.FromArgb(211, 17, 21);
		i.PrimaryAlt2 = Color.FromArgb(103, 18, 21);
		i.PrimaryAlt3 = Color.FromArgb(187, 33, 36);
		i.PrimaryAlt4 = Color.FromArgb(0, 171, 238);
		i.PrimaryContrast = Color.FromArgb(255, 255, 255);
		i.Secondary = Color.FromArgb(0, 0, 0);
		i.SecondaryAlt = Color.FromArgb(68, 68, 68);
		i.SecondaryAlt2 = Color.FromArgb(85, 85, 85);
		i.SecondaryAlt3 = Color.FromArgb(119, 119, 119);
		i.SecondaryContrast = Color.FromArgb(255, 255, 255);
		i.NeutralPrimary = Color.FromArgb(255, 255, 255);
		i.NeutralPrimaryAlt = Color.FromArgb(244, 244, 244);
		i.NeutralPrimaryAlt2 = Color.FromArgb(227, 227, 227);
		i.NeutralPrimaryAlt3 = Color.FromArgb(200, 200, 200);
		i.NeutralPrimaryContrast = Color.FromArgb(0, 0, 0);
		i.NeutralSecondary = Color.FromArgb(255, 255, 255);
		i.NeutralSecondaryAlt = Color.FromArgb(234, 234, 234);
		i.NeutralSecondaryAlt2 = Color.FromArgb(183, 183, 183);
		i.NeutralSecondaryAlt3 = Color.FromArgb(172, 172, 172);
		i.NeutralSecondaryContrast = Color.FromArgb(0, 0, 0);
		i.NeutralTertiary = Color.FromArgb(183, 183, 183);
		i.NeutralTertiaryAlt = Color.FromArgb(200, 200, 200);
		i.NeutralTertiaryAlt2 = Color.FromArgb(234, 234, 234);
		i.NeutralTertiaryAlt3 = Color.FromArgb(255, 255, 255);
		i.NeutralTertiaryContrast = Color.FromArgb(34, 34, 34);
		i.Danger = Color.FromArgb(187, 33, 36);
		i.Success = Color.FromArgb(34, 187, 51);
		i.Warning = Color.FromArgb(240, 173, 78);
		i.Info = Color.FromArgb(91, 192, 222);
		i.DangerContrast = Color.FromArgb(255, 255, 255);
		i.SuccessContrast = Color.FromArgb(255, 255, 255);
		i.WarningContrast = Color.FromArgb(255, 255, 255);
		i.InfoContrast = Color.FromArgb(255, 255, 255);
		i.KpiGood = Color.FromArgb(79, 180, 67);
		i.KpiBad = Color.FromArgb(222, 6, 26);
		i.KpiNeutral = Color.FromArgb(217, 180, 44);
		i.KpiNone = Color.FromArgb(51, 51, 51);
		i.KpiGoodContrast = Color.FromArgb(255, 255, 255);
		i.KpiBadContrast = Color.FromArgb(255, 255, 255);
		i.KpiNeutralContrast = Color.FromArgb(255, 255, 255);
		i.KpiNoneContrast = Color.FromArgb(255, 255, 255);
		i.ItemTypeIconColor = Color.FromArgb(255, 255, 255);
		i.ReportIconBackground = Color.FromArgb(18, 35, 158);
		i.ExcelIconBackground = Color.FromArgb(33, 115, 70);
		i.FolderIconBackground = Color.FromArgb(70, 104, 197);
		i.DatasetIconBackground = Color.FromArgb(201, 79, 15);
		i.OtherIconBackground = Color.FromArgb(0, 0, 0);
		i.PrimaryButton = Color.FromArgb(187, 33, 36);
		i.PrimaryButtonHover = Color.FromArgb(211, 17, 21);
		i.PrimaryButtonPressed = Color.FromArgb(61, 0, 0);
		i.Link = Color.FromArgb(211, 17, 21);
		i.LinkHover = Color.FromArgb(103, 18, 21);
		i.LinkVisited = Color.FromArgb(61, 0, 0);
		i.RadioButtonCheckBox = Color.FromArgb(187, 33, 36);
		i.RadioButtonCheckBoxHover = Color.FromArgb(211, 17, 21);

		var t = model.ColorScheme.Theme;
		t.DataPoints.Add(Color.FromArgb(0, 114, 198));
		t.DataPoints.Add(Color.FromArgb(246, 140, 31));
		t.DataPoints.Add(Color.FromArgb(38, 150, 87));
		t.DataPoints.Add(Color.FromArgb(221, 89, 0));
		t.DataPoints.Add(Color.FromArgb(91, 53, 115));
		t.DataPoints.Add(Color.FromArgb(34, 189, 239));
		t.DataPoints.Add(Color.FromArgb(180, 0, 158));
		t.DataPoints.Add(Color.FromArgb(0, 130, 116));
		t.DataPoints.Add(Color.FromArgb(253, 195, 54));
		t.DataPoints.Add(Color.FromArgb(234, 60, 0));
		t.DataPoints.Add(Color.FromArgb(0, 24, 143));
		t.DataPoints.Add(Color.FromArgb(159, 159, 159));
		t.Good = Color.FromArgb(133, 186, 0);
		t.Bad = Color.FromArgb(233, 0, 0);
		t.Neutral = Color.FromArgb(237, 179, 39);
		t.None = Color.FromArgb(51, 51, 51);
		t.Background = Color.FromArgb(255, 255, 255);
		t.Foreground = Color.FromArgb(34, 34, 34);
		t.MapBase = Color.FromArgb(0, 174, 239);
		t.PanelBackground = Color.FromArgb(246, 246, 246);
		t.PanelForeground = Color.FromArgb(34, 34, 34);
		t.PanelAccent = Color.FromArgb(0, 174, 239);
		t.TableAccent = Color.FromArgb(0, 174, 239);
		t.AltBackground = Color.FromArgb(246, 246, 246);
		t.AltForeground = Color.FromArgb(0, 0, 0);
		t.AltMapBase = Color.FromArgb(246, 140, 31);
		t.AltPanelBackground = Color.FromArgb(35, 83, 120);
		t.AltPanelForeground = Color.FromArgb(255, 255, 255);
		t.AltPanelAccent = Color.FromArgb(253, 195, 54);
		t.AltTableAccent = Color.FromArgb(253, 195, 54);
	}

	private void OnError(Exception exception)
	{
		loggerService.Log(LogException, exception);
		notificationService.ShowError(exception.Message);
	}
}
