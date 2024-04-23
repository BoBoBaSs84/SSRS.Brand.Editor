using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The meta date view model class.
/// </summary>
/// <param name="navService">The navigation service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class MetaDataViewModel(INavigationService navService, MetadataModel model) : ViewModelBase
{
	private IActionCommand? _toColorsCommand;

	/// <summary>
	/// The model instance to use.
	/// </summary>
	public MetadataModel Model { get; } = model;

	/// <summary>
	/// The command to navigate to the colors view model.
	/// </summary>
	public IActionCommand ToColorsCommand
		=> _toColorsCommand ??= new ActionCommand(navService.NavigateTo<MetaDataViewModel>);
}
