using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

using SSRS.Brand.Editor.Application.Attributes;

namespace SSRS.Brand.Editor.Application.ViewModels.Base;

/// <summary>
/// The <see langword="abstract"/> view model base class.
/// </summary>
/// <remarks>
/// The view model base class implements the following interfaces:
/// <list type="bullet">
///		<item>The members of the <see cref="INotifyPropertyChanged"/> interface.</item>
///		<item>The members of the <see cref="INotifyPropertyChanging"/> interface.</item>
/// </list>
/// </remarks>
public abstract class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
{
	#region private members
	private static readonly Dictionary<string, string[]> PropertyChangingSubscribers = new();
	private static readonly Dictionary<string, string[]> PropertyChangedSubscribers = new();
	#endregion

	#region property access methods
	/// <summary>
	/// Sets a new value for a property and notifies about the change.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="field">The referenced field.</param>
	/// <param name="newValue">The new value for the property.</param>
	/// <param name="propertyName">The property name.</param>
	protected void SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(field, newValue))
			return;

		NotifyPropertyChanging(propertyName);
		NotifyPropertyChangingAttribute(propertyName);
		field = newValue;
		NotifyPropertyChanged(propertyName);
		NotifyPropertyChangedAttribute(propertyName);
	}

	#endregion

	#region INotifyPropertyChanged members

	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// The <see cref="NotifyPropertyChanged(string?)"/> method to raise the changed event.
	/// </summary>
	/// <remarks>
	/// The calling member's name will be used as the parameter.
	/// </remarks>
	/// <param name="propertyName">The name of the property, can be <see langword="null"/>.</param>
	protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	#endregion

	#region INotifyPropertyChanging members

	/// <inheritdoc/>
	public event PropertyChangingEventHandler? PropertyChanging;

	/// <summary>
	/// The <see cref="NotifyPropertyChanging(string?)"/> method to raise the changing event.
	/// </summary>
	/// <remarks>
	/// The calling member's name will be used as the parameter.
	/// </remarks>
	/// <param name="propertyName">The name of the property, can be <see langword="null"/>.</param>
	protected virtual void NotifyPropertyChanging([CallerMemberName] string? propertyName = null) =>
		PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

	#endregion

	#region Notify property changing attribute methods

	/// <summary>
	/// The <see cref="NotifyPropertyChangingAttribute(string)"/> method will notify all properties
	/// which have been defined by the <see cref="Attributes.NotifyPropertyChangingAttribute"/> as to be informed.
	/// </summary>
	/// <remarks>
	/// To avoid to much reflection, the properties and their subscribers are stored in a static dictionary
	/// when they are accessed for the first time.
	/// </remarks>
	/// <param name="propertyName">The property name.</param>
	private void NotifyPropertyChangingAttribute(string propertyName)
	{
		if (!PropertyChangingSubscribers.ContainsKey(propertyName))
		{
			PropertyInfo? propertyInfo = GetType().GetProperty(propertyName);

			NotifyPropertyChangingAttribute? attribute =
				propertyInfo?.GetCustomAttribute<NotifyPropertyChangingAttribute>();

			if (attribute is not null && attribute.PropertyNames.Length > 0)
				PropertyChangingSubscribers.Add(propertyName, attribute.PropertyNames);
			else
				PropertyChangingSubscribers.Add(propertyName, Array.Empty<string>());
		}

		string[] subscribers = PropertyChangingSubscribers[propertyName];

		foreach (string subscriber in subscribers)
			NotifyPropertyChanging(subscriber);
	}

	/// <summary>
	/// The <see cref="NotifyPropertyChangedAttribute(string)"/> method will notify all properties
	/// which have been defined by the <see cref="Attributes.NotifyPropertyChangedAttribute"/> as to be informed.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	private void NotifyPropertyChangedAttribute(string propertyName)
	{
		if (!PropertyChangedSubscribers.ContainsKey(propertyName))
		{
			PropertyInfo? propertyInfo = GetType().GetProperty(propertyName);

			NotifyPropertyChangedAttribute? attribute =
				propertyInfo?.GetCustomAttribute<NotifyPropertyChangedAttribute>();

			if (attribute is not null && attribute.PropertyNames.Length > 0)
				PropertyChangedSubscribers.Add(propertyName, attribute.PropertyNames);
			else
				PropertyChangedSubscribers.Add(propertyName, Array.Empty<string>());
		}

		string[] subscribers = PropertyChangedSubscribers[propertyName];

		foreach (string subscriber in subscribers)
			NotifyPropertyChanged(subscriber);
	}

	#endregion
}

/// <summary>
/// The <see langword="abstract"/> view model base class of <typeparamref name="TModel"/>
/// </summary>
/// <remarks>
/// The view model base class of <typeparamref name="TModel"/> inherits from the <see cref="ViewModelBase"/>
/// class and implements the <see cref="INotifyDataErrorInfo"/> interface.
/// </remarks>
/// <typeparam name="TModel">The model class to validate against.</typeparam>
public abstract class ViewModelBase<TModel> : ViewModelBase, INotifyDataErrorInfo where TModel : class
{
	private TModel _model;

	/// <summary>
	/// Initializes a new instance of the <see cref="ViewModelBase{TModel}"/> class.
	/// </summary>
	/// <param name="model">The domain model class.</param>
	protected ViewModelBase(TModel model)
		=> _model = model;

	/// <summary>
	/// The <see cref="Model"/> property.
	/// </summary>
	/// <remarks>
	/// Immutable types are those whose data members can not be changed after the instance is created.
	/// At the first choice of design, for now the property is mutable.
	/// </remarks>
	public TModel Model
	{
		get => _model;
		private set => SetProperty(ref _model, value);
	}

	/// <summary>
	/// The <see cref="OnPropertyChangedPropagate(object?, PropertyChangedEventArgs)"/> method
	/// propagates the changes in the view model through to the domain model.
	/// </summary>
	/// <remarks>
	/// The method can only / should be called from the derived class.
	/// </remarks>
	/// <param name="sender">The sender will/should be <see cref="ViewModelBase{TModel}"/>.</param>
	/// <param name="args"></param>
	protected virtual void OnPropertyChangedPropagate(object? sender, PropertyChangedEventArgs args)
	{
		if (sender is not ViewModelBase<TModel> viewModelBase)
			return;

		if (args.PropertyName is not null)
		{
			object? propertyValue = viewModelBase.GetType().GetProperty(args.PropertyName)!.GetValue(viewModelBase, null);
			viewModelBase.Model.GetType().GetProperty(args.PropertyName)!.SetValue(viewModelBase.Model, propertyValue, null);
		}
	}

	#region Property access methods

	/// <summary>
	/// Sets a new value for a property, notifies about the change and tries to
	/// validate the property against the domain model class.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="field">The referenced field.</param>
	/// <param name="newValue">The new value for the property.</param>
	/// <param name="propertyName">The property name.</param>
	protected void SetPropertyAndValidate<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(field, newValue))
			return;

		SetProperty(ref field, newValue, propertyName);
		Validate(newValue, propertyName);
	}

	/// <summary>
	/// Sets a new value for a property, does not notify about the changeand tries to
	/// validate the property against the domain model class.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="field">The referenced field.</param>
	/// <param name="newValue">The new value for the property.</param>
	/// <param name="propertyName">The property name.</param>
	/// <returns><see langword="true"/> or <see langword="false"/> if the property has been set.</returns>
	protected void SetPropertyNoNotifyAndValidate<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(field, newValue))
			return;

		field = newValue;
		Validate(newValue, propertyName);
	}

	#endregion

	#region INotifyDataErrorInfo members

	/// <summary>
	/// The dictonary contains the errors for each property.
	/// </summary>
	private readonly Dictionary<string, List<string>> _propertyErrors = new();

	/// <inheritdoc/>
	public bool HasErrors => _propertyErrors.Any();

	/// <inheritdoc/>
	public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

	/// <inheritdoc/>
	public IEnumerable GetErrors(string? propertyName) =>
		_propertyErrors.ContainsKey(propertyName!) ? _propertyErrors[propertyName!] : null!;

	/// <summary>
	/// The <see cref="RaiseErrorsChanged(string?)"/> method to raise the erros changed event.
	/// </summary>
	/// <remarks>
	/// The calling member's name will be used as the parameter.
	/// </remarks>
	/// <param name="propertyName">The property name.</param>
	protected virtual void RaiseErrorsChanged([CallerMemberName] string propertyName = "") =>
		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

	/// <summary>
	/// The <see cref="Validate{T}(T, string)"/> method will try to validate the property value.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="value">The value of the property.</param>
	/// <param name="propertyName">The property name.</param>
	protected void Validate<T>(T value, string propertyName)
	{
		ValidationContext context = new(Model) { MemberName = propertyName };
		List<ValidationResult> results = new();

		ClearErrors(propertyName);

		if (!Validator.TryValidateProperty(value, context, results))
		{
			foreach (ValidationResult error in results)
				AddError(propertyName, error.ErrorMessage!);
		}
	}

	/// <summary>
	/// The <see cref="AddError(string, string)"/> method will add an error message for the property.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	/// <param name="errorMessage">The error message.</param>
	private void AddError(string propertyName, string errorMessage)
	{
		if (!_propertyErrors.ContainsKey(propertyName))
			_propertyErrors[propertyName] = new List<string>();

		if (!_propertyErrors[propertyName].Contains(errorMessage))
		{
			_propertyErrors[propertyName].Add(errorMessage);
			RaiseErrorsChanged(propertyName);
		}
	}

	/// <summary>
	/// The <see cref="ClearErrors(string)"/> method will clear all errors for the property.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	private void ClearErrors(string propertyName)
	{
		if (_propertyErrors.ContainsKey(propertyName))
		{
			_ = _propertyErrors.Remove(propertyName);
			RaiseErrorsChanged(propertyName);
		}
	}

	#endregion
}
