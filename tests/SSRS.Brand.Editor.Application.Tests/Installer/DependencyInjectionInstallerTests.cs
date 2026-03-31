// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Installers;

namespace SSRS.Brand.Editor.Application.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests : ApplicationTestBase
{
	[TestMethod]
	public void RegisterApplicationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterApplicationServices();

		Assert.AreEqual(6, services.Count);
	}
}
