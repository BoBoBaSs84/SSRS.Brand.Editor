namespace SSRS.Brand.Editor.Presentation.Attributes;

/// <summary>
/// The notify property changing attribute class.
/// </summary>
/// <remarks>
/// A property decorated with this attribute propagates its pending change
/// to the properties defined in the attribute.
/// </remarks>
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public sealed class NotifyPropertyChangingAttribute : Attribute
{
	/// <summary>
	/// Initializes a new instance of the notify property changing attribute class.
	/// </summary>
	/// <param name="propertyName">The name of the property to notify.</param>
	public NotifyPropertyChangingAttribute(string propertyName)
		=> PropertyNames = new[] { propertyName };

	/// <summary>
	/// Initializes a new instance of the notify property changing attribute class.
	/// </summary>
	/// <param name="propertyNames">The names of the properties to notify.</param>
	public NotifyPropertyChangingAttribute(string[] propertyNames)
		=> PropertyNames = propertyNames;

	/// <summary>
	/// The names of the properties to notify.
	/// </summary>
	public string[] PropertyNames { get; }
}
