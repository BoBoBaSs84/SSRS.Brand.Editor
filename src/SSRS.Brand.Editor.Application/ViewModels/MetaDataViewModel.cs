using BB84.Notifications;
using BB84.Notifications.Interfaces;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The meta date view model class.
/// </summary>
public sealed class MetaDataViewModel : ViewModelBase
{
	private readonly INavigationService _navService;
	private IRelayCommand? _toColorsCommand;

	/// <summary>
	/// Initializes an instance of <see cref="MetaDataViewModel"/> class.
	/// </summary>
	/// <param name="navService">The navigation service instance to use.</param>
	/// <param name="model">The model instance to use.</param>
	public MetaDataViewModel(INavigationService navService, MetadataModel model)
	{
		_navService = navService;
		Model = model;
	}

	/// <summary>
	/// The model instance to use.
	/// </summary>
	public MetadataModel Model { get; }

	/// <summary>
	/// The command to navigate to the colors view model.
	/// </summary>
	public IRelayCommand ToColorsCommand
		=> _toColorsCommand ??= new RelayCommand(() => _navService.NavigateTo<MetaDataViewModel>());
}
