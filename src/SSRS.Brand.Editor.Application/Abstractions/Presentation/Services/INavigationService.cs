using BB84.Notifications.Interfaces;

namespace SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
/// <summary>
/// The interface for the navigation service.
/// </summary>
public interface INavigationService : INotifiableObject
{
	/// <summary>
	/// The currently form that has been navigated to.
	/// </summary>
	public Form? CurrentForm { get; }

	/// <summary>
	/// Navigates to the provided form.
	/// </summary>
	/// <typeparam name="T">The form type to work with.</typeparam>
	void NavigateTo<T>() where T : Form;
}
