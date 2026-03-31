// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class InterfaceColorsViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void ConstructorShouldSetModel()
	{
		InterfaceColorsModel model = new();

		InterfaceColorsViewModel viewModel = new(model);

		Assert.AreEqual(model, viewModel.Model);
	}
}
