namespace SSRS.Brand.Editor.Application.Attributes;

/// <summary>
/// The notify property changed attribute class.
/// </summary>
/// <remarks>
/// A property decorated with this attribute propagates its change to the
/// properties defined in this attribute.
/// </remarks>
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public sealed class NotifyPropertyChangedAttribute : Attribute
{
	/// <summary>
	/// Initializes a new instance of the notify property changed attribute class.
	/// </summary>
	/// <param name="propertyName">The name of the property to notify.</param>
	public NotifyPropertyChangedAttribute(string propertyName)
		=> PropertyNames = new[] { propertyName };

	/// <summary>
	/// Initializes a new instance of the notify property changed attribute class.
	/// </summary>
	/// <param name="propertyNames">The names of the properties to notify.</param>
	public NotifyPropertyChangedAttribute(params string[] propertyNames)
		=> PropertyNames = propertyNames;

	/// <summary>
	/// The names of the properties to notify.
	/// </summary>
	public string[] PropertyNames { get; }
}
