// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Infrastructure.Services;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Services;

[TestClass]
public sealed partial class BrandPackageServiceTests : InfrastructureTestBase
{
	private readonly BrandPackageService _sut = new();
	private readonly string _tempDirectory = Path.Combine(Path.GetTempPath(), $"BrandPackageTests_{Guid.NewGuid():N}");

	[TestInitialize]
	public void TestInitialize()
		=> Directory.CreateDirectory(_tempDirectory);

	[TestCleanup]
	public void TestCleanup()
	{
		if (Directory.Exists(_tempDirectory))
			Directory.Delete(_tempDirectory, recursive: true);
	}

	private string GetTempFilePath(string fileName = "test-brand.zip")
		=> Path.Combine(_tempDirectory, fileName);
}
