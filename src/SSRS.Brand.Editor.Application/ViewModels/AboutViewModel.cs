using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;
/// <summary>
/// The view model for the about page.
/// </summary>
/// <param name="model">The about model instance to use.</param>
public sealed class AboutViewModel(AboutModel model) : ViewModelBase
{
	/// <summary>
	/// The model instance to use for the about page.
	/// </summary>
	public AboutModel Model => model;
}
