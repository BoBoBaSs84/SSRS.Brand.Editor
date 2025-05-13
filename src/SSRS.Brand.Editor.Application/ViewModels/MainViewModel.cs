using Microsoft.Extensions.Hosting;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.ViewModels;
/// <summary>
/// Represents the main view model of the application.
/// </summary>
/// <param name="hostEnvironment">The host environment instance to use.</param>
/// <param name="userService">The user service instance to use.</param>
public sealed class MainViewModel(IHostEnvironment hostEnvironment, IUserService userService) : ViewModelBase
{
	/// <summary>
	/// The name of the application.
	/// </summary>
	public string ApplicationName => hostEnvironment.ApplicationName;

	/// <summary>
	/// The name of the host environment.
	/// </summary>
	public string EnvironmentName => hostEnvironment.EnvironmentName;

	/// <summary>
	/// The current user.
	/// </summary>
	public string CurrentUser => $"{userService.Domain}\\{userService.Name}@{userService.Machine}";
}
