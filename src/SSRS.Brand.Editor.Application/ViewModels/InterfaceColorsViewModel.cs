using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The interface colors view model class.
/// </summary>
/// <param name="model">The interface colors model instance to use.</param>
public sealed class InterfaceColorsViewModel(InterfaceColorsModel model) : ViewModelBase
{
	/// <summary>
	/// The interface colors model instance.
	/// </summary>
	public InterfaceColorsModel Model => model;
}
