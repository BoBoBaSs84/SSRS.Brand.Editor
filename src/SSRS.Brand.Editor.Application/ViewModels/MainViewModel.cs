using BB84.Notifications;

using SSRS.Brand.Editor.Application.Common;
using SSRS.Brand.Editor.Application.Interfaces.Application.Common;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
public sealed class MainViewModel : NotifyPropertyBase
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
		=> _aboutCommand ??= new RelayCommand(() => { StatusText = "Abouting .."; });

	/// <summary>
	/// The command to exit the application.
	/// </summary>
	public IRelayCommand ExitCommand
		=> _exitCommand ??= new RelayCommand(() => Environment.Exit(0));

	/// <summary>
	/// The command to open an existing brand.
	/// </summary>
	public IRelayCommand OpenCommand
		=> _openCommand ??= new RelayCommand(() => { StatusText = "Opening .."; });

	/// <summary>
	/// The command to create a new brand.
	/// </summary>
	public IRelayCommand NewCommand
		=> _newCommand ??= new RelayCommand(() => { StatusText = "Creating .."; });

	/// <summary>
	/// The command to save the current brand.
	/// </summary>
	public IRelayCommand SaveCommand
		=> _saveCommand ??= new RelayCommand(() => { StatusText = "Saving .."; });

	/// <summary>
	/// The current status text of the view.
	/// </summary>
	public string StatusText { get => _status; private set => SetProperty(ref _status, value); }
}
