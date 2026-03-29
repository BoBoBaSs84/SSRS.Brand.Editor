using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class ColorSchemeModelTests
{
	[TestMethod]
	public void ConstructorShouldCreateInstanceWithChildren()
	{
		ColorSchemeModel model;

		model = new ColorSchemeModel();

		Assert.IsNotNull(model);
		Assert.AreEqual(string.Empty, model.Name);
		Assert.AreEqual("1.0", model.Version);
		Assert.IsNotNull(model.Interface);
		Assert.IsNotNull(model.Theme);
	}

	[TestMethod]
	public void NamePropertyShouldRaisePropertyChanged()
	{
		ColorSchemeModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(ColorSchemeModel.Name))
				raised = true;
		};

		model.Name = "My Brand";

		Assert.IsTrue(raised);
		Assert.AreEqual("My Brand", model.Name);
	}

	[TestMethod]
	public void VersionPropertyShouldRaisePropertyChanged()
	{
		ColorSchemeModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(ColorSchemeModel.Version))
				raised = true;
		};

		model.Version = "2.0";

		Assert.IsTrue(raised);
		Assert.AreEqual("2.0", model.Version);
	}
}
