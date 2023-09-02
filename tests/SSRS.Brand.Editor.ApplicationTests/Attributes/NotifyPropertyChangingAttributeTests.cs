using SSRS.Brand.Editor.Application.Attributes;

namespace SSRS.Brand.Editor.ApplicationTests.Attributes;

[TestClass, ExcludeFromCodeCoverage]
public class NotifyPropertyChangingAttributeTests
{
	[TestMethod]
	public void NotifyPropertyChangingAttributeTest()
	{
		NotifyPropertyChangingAttribute attribute = new("Hello", "Hello2");

		Assert.IsTrue(attribute.PropertyNames.Length.Equals(2));
	}
}
