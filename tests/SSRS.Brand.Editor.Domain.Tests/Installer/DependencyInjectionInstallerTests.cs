// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Domain.Installers;

namespace SSRS.Brand.Editor.Domain.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterDomainServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterDomainServices();

		Assert.AreEqual(2, services.Count);
	}
}
