using BB84.Notifications;
using BB84.Notifications.Interfaces;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The colors view model class.
/// </summary>
public sealed class ColorsViewModel : ViewModelBase
{
	private readonly INavigationService _navService;
	private IRelayCommand? _toMetaDataCommand;

	/// <summary>
	/// Initializes an instance of <see cref="ColorsViewModel"/> class.
	/// </summary>
	/// <param name="navService">The navigation service instance to use.</param>
	/// <param name="model">The model instance to use.</param>
	public ColorsViewModel(INavigationService navService, ColorsModel model)
	{
		_navService = navService;
		Model = model;
	}

	/// <summary>
	/// The model instance to use.
	/// </summary>
	public ColorsModel Model { get; }

	/// <summary>
	/// The command to navigate to the meta data view model.
	/// </summary>
	public IRelayCommand ToMetaDataCommand
		=> _toMetaDataCommand ??= new RelayCommand(() => _navService.NavigateTo<MetaDataViewModel>());
}
