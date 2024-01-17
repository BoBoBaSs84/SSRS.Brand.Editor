using BB84.Notifications;
using BB84.Notifications.Interfaces;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The colors view model class.
/// </summary>
/// <param name="navService">The navigation service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class ColorsViewModel(INavigationService navService, ColorsModel model) : ViewModelBase
{
	private IRelayCommand? _toMetaDataCommand;

	/// <summary>
	/// The model instance to use.
	/// </summary>
	public ColorsModel Model { get; } = model;

	/// <summary>
	/// The command to navigate to the meta data view model.
	/// </summary>
	public IRelayCommand ToMetaDataCommand
		=> _toMetaDataCommand ??= new RelayCommand(() => navService.NavigateTo<MetaDataViewModel>());
}
