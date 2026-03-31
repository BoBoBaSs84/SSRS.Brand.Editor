// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class MetadataModelTests
{
	[TestMethod]
	public void ConstructorShouldSetDefaults()
	{
		MetadataModel model;

		model = new MetadataModel();

		Assert.IsNotNull(model);
		Assert.AreEqual(string.Empty, model.Name);
		Assert.AreEqual(MetadataModel.DefaultVersion, model.Version);
		Assert.IsFalse(model.HasLogo);
	}

	[TestMethod]
	public void NamePropertyShouldRaisePropertyChanged()
	{
		MetadataModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(MetadataModel.Name))
				raised = true;
		};

		model.Name = "Test Brand";

		Assert.IsTrue(raised);
		Assert.AreEqual("Test Brand", model.Name);
	}

	[TestMethod]
	public void VersionPropertyShouldRaisePropertyChanged()
	{
		MetadataModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(MetadataModel.Version))
				raised = true;
		};

		model.Version = "3.0.0";

		Assert.IsTrue(raised);
		Assert.AreEqual("3.0.0", model.Version);
	}

	[TestMethod]
	public void HasLogoPropertyShouldRaisePropertyChanged()
	{
		MetadataModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(MetadataModel.HasLogo))
				raised = true;
		};

		model.HasLogo = true;

		Assert.IsTrue(raised);
		Assert.IsTrue(model.HasLogo);
	}

	[TestMethod]
	public void ConstantsShouldHaveExpectedValues()
	{
		Assert.IsFalse(string.IsNullOrWhiteSpace(MetadataModel.XmlNamespace));
		Assert.IsFalse(string.IsNullOrWhiteSpace(MetadataModel.PackageType));
		Assert.IsFalse(string.IsNullOrWhiteSpace(MetadataModel.DefaultVersion));
		Assert.IsFalse(string.IsNullOrWhiteSpace(MetadataModel.ColorsPath));
		Assert.IsFalse(string.IsNullOrWhiteSpace(MetadataModel.LogoPath));
	}

	[TestMethod]
	public void NameShouldHaveValidationErrorWhenEmpty()
	{
		MetadataModel model = new() { Name = "Valid Brand" };

		model.Name = string.Empty;

		Assert.IsTrue(model.HasErrors);
		Assert.IsFalse(model.IsValid);
	}

	[TestMethod]
	public void NameShouldNotHaveValidationErrorWhenSet()
	{
		MetadataModel model = new()
		{
			Name = "Valid Brand"
		};

		Assert.IsFalse(model.HasErrors);
		Assert.IsTrue(model.IsValid);
	}
}
