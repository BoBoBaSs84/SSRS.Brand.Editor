// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using Microsoft.Extensions.Hosting;

using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
/// <param name="hostEnvironment">The host environment instance to use.</param>
/// <param name="navigationService">The navigation service instance to use.</param>
/// <param name="userService">The user service instance to use.</param>
/// <param name="brandEditorViewModel">The brand editor view model instance to use.</param>
public sealed class MainViewModel(IHostEnvironment hostEnvironment, INavigationService navigationService, IUserService userService, BrandEditorViewModel brandEditorViewModel) : ViewModelBase
{
	private IActionCommand? _aboutCommand;
	private IActionCommand? _exitCommand;

	/// <summary>
	/// The name of the application.
	/// </summary>
	public string ApplicationName => hostEnvironment.ApplicationName;

	/// <summary>
	/// The name of the host environment.
	/// </summary>
	public string EnvironmentName => hostEnvironment.EnvironmentName;

	/// <summary>
	/// The navigation service instance.
	/// </summary>
	public INavigationService NavigationService => navigationService;

	/// <summary>
	/// The brand editor view model instance.
	/// </summary>
	public BrandEditorViewModel BrandEditor => brandEditorViewModel;

	/// <summary>
	/// The current user.
	/// </summary>
	public string CurrentUser => $"{userService.Domain}\\{userService.Name}@{userService.Machine}";

	/// <summary>
	/// The command to show the about control.
	/// </summary>
	public IActionCommand AboutCommand
		=> _aboutCommand ??= new ActionCommand(NavigationService.NavigateTo<AboutViewModel>);

	/// <summary>
	/// The command to exit the application.
	/// </summary>
	public IActionCommand ExitCommand
		=> _exitCommand ??= new ActionCommand(() => Environment.Exit(0));
}
