// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Presentation.Installers;

namespace SSRS.Brand.Editor.Presentation.Tests.Installers;

[TestClass]
public sealed class DependencyInjectionInstallerTests : PresentationTestBase
{
	[TestMethod]
	public void RegisterPresentationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterPresentationServices();

		Assert.AreEqual(5, services.Count);
	}
}
