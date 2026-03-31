// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Tests.Services;

[TestClass]
public sealed class NavigationServiceTests : ApplicationTestBase
{
	[TestMethod]
	[TestCategory("Constructor")]
	public void NavigationServiceTest()
	{
		NavigationService? service;
		AboutViewModel viewModel = new(new());

		service = new(t => viewModel);

		Assert.IsNotNull(service);
	}

	[TestMethod]
	[TestCategory("Method")]
	public void NavigateToTest()
	{
		AboutViewModel viewModel = new(new());
		NavigationService service = new(t => viewModel);

		service.NavigateTo<AboutViewModel>();

		Assert.IsInstanceOfType<AboutViewModel>(service.CurrentView);
	}
}
