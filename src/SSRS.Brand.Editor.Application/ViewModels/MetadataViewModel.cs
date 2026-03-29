using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The metadata view model class.
/// </summary>
/// <param name="model">The metadata model instance to use.</param>
public sealed class MetadataViewModel(MetadataModel model) : ViewModelBase
{
	/// <summary>
	/// The metadata model instance.
	/// </summary>
	public MetadataModel Model => model;
}
