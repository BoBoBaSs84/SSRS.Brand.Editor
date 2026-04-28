// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.Providers;
using SSRS.Brand.Editor.Application.Services;

namespace SSRS.Brand.Editor.Application.Tests.Services;

[TestClass]
public sealed class ProviderServiceTests : ApplicationTestBase
{
	[TestMethod]
	public void ProviderServiceConstructorShouldSetUpAllProperties()
	{
		ProviderService? service;

		service = new ProviderService();

		Assert.IsNotNull(service, "ProviderService should not be null after construction.");
		Assert.IsInstanceOfType<DateTimeProvider>(service.DateTime, "DateTime provider should be of type DateTimeProvider.");
		Assert.IsInstanceOfType<DirectoryProvider>(service.Directory, "Directory provider should be of type DirectoryProvider.");
		Assert.IsInstanceOfType<EnvironmentProvider>(service.Environment, "Environment provider should be of type EnvironmentProvider.");
		Assert.IsInstanceOfType<FileProvider>(service.File, "File provider should be of type FileProvider.");
		Assert.IsInstanceOfType<PathProvider>(service.Path, "Path provider should be of type PathProvider.");
	}
}
