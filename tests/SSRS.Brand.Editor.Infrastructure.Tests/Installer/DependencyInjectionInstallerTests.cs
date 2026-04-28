// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Infrastructure.Installers;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests : InfrastructureTestBase
{
	private readonly Mock<IHostEnvironment> _hostEnvironmentMock;
	private readonly ServiceCollection _sut;

	public DependencyInjectionInstallerTests()
	{
		_hostEnvironmentMock = new();
		_sut = new();
	}

	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterInfrastructureServicesForDevelopmentTest()
	{
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Development");

		_sut.RegisterInfrastructureServices(_hostEnvironmentMock.Object);

		Assert.HasCount(44, _sut);
	}

	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterInfrastructureServicesForProductionTest()
	{
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Production");

		_sut.RegisterInfrastructureServices(_hostEnvironmentMock.Object);

		Assert.HasCount(32, _sut);
	}
}
