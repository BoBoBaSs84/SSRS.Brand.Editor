using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSRS.Brand.Editor.Application.ViewModels.Base;

/// <summary>
/// The view model base class.
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
{
	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <inheritdoc/>
	public event PropertyChangingEventHandler? PropertyChanging;

	/// <summary>
	/// Sets a new value for a property and notifies about the change.
	/// </summary>
	/// <typeparam name="T">The value type to work with.</typeparam>
	/// <param name="fieldValue">The referenced field value.</param>
	/// <param name="value">The new value for the property.</param>
	/// <param name="propertyName">The name of the calling property.</param>
	protected void SetProperty<T>(ref T fieldValue, T value, [CallerMemberName] string propertyName = "")
	{
		if (!EqualityComparer<T>.Default.Equals(fieldValue, value))
		{
			PropertyChanging?.Invoke(this, new(propertyName));
			fieldValue = value;
			PropertyChanged?.Invoke(this, new(propertyName));
		}
	}
}
