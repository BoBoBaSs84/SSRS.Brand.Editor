using BB84.Notifications;

using SSRS.Brand.Editor.Application.Common;
using SSRS.Brand.Editor.Application.Interfaces.Application.Common;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
public sealed class MainViewModel : NotifyPropertyBase
{
	private IRelayCommand _aboutCommand;
	private IRelayCommand _exitCommand;
	private IRelayCommand _newCommand;
	private IRelayCommand _saveCommand;

	/// <summary>
	/// Initilizes an instance of the <see cref="MainViewModel"/> class.
	/// </summary>
	public MainViewModel()
	{ }

	/// <summary>
	/// The command to show the about window.
	/// </summary>
	public IRelayCommand AboutCommand
		=> _aboutCommand ??= new RelayCommand(() => { });

	/// <summary>
	/// The command to exit the application.
	/// </summary>
	public IRelayCommand ExitCommand
		=> _exitCommand ??= new RelayCommand(() => Environment.Exit(0));

	/// <summary>
	/// The command to create a new brand.
	/// </summary>
	public IRelayCommand NewCommand
		=> _newCommand ??= new RelayCommand(() => { });

	/// <summary>
	/// The command to save the current brand.
	/// </summary>
	public IRelayCommand SaveCommand
		=> _saveCommand ??= new RelayCommand(() => { });
}
