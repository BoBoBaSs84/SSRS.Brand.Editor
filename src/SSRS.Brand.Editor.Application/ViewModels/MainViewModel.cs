using BB84.Notifications;
using BB84.Notifications.Interfaces;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
/// <param name="navService">The navigation service instance to use.</param>
public sealed class MainViewModel(INavigationService navService) : ViewModelBase
{
	private IRelayCommand? _aboutCommand;
	private IRelayCommand? _exitCommand;
	private IRelayCommand? _openCommand;
	private IRelayCommand? _newCommand;
	private IRelayCommand? _saveCommand;
	private string _status = string.Empty;

	/// <summary>
	/// The command to show the about window.
	/// </summary>
	public IRelayCommand AboutCommand
		=> _aboutCommand ??= new RelayCommand(() =>
		{
			SetStatusText("Abouting ..");
			NavService.NavigateTo<ColorsViewModel>();
		});

	/// <summary>
	/// The command to exit the application.
	/// </summary>
	public IRelayCommand ExitCommand
		=> _exitCommand ??= new RelayCommand(() => Environment.Exit(0));

	/// <summary>
	/// The command to open an existing brand.
	/// </summary>
	public IRelayCommand OpenCommand
		=> _openCommand ??= new RelayCommand(() => SetStatusText("Opening .."));

	/// <summary>
	/// The command to create a new brand.
	/// </summary>
	public IRelayCommand NewCommand
		=> _newCommand ??= new RelayCommand(() => SetStatusText("Creating .."));

	/// <summary>
	/// The command to save the current brand.
	/// </summary>
	public IRelayCommand SaveCommand
		=> _saveCommand ??= new RelayCommand(() => SetStatusText("Saving .."));

	/// <summary>
	/// The navigation service instance.
	/// </summary>
	public INavigationService NavService
	{
		get => navService;
		private set => SetProperty(ref navService, value);
	}

	/// <summary>
	/// The current status text of the view.
	/// </summary>
	public string StatusText
	{
		get => _status;
		private set => SetProperty(ref _status, value);
	}

	/// <summary>
	/// Sets the current status text.
	/// </summary>
	/// <param name="text">The status text to set.</param>
	private void SetStatusText(string text)
		=> StatusText = text;
}
