// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class AboutModelTests
{
	[TestMethod]
	public void AboutModelConstructorTest()
	{
		AboutModel? model;

		model = new AboutModel();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Title);
		Assert.IsNotNull(model.Version);
		Assert.IsNotNull(model.Comments);
		Assert.IsNotNull(model.Company);
		Assert.IsNotNull(model.Copyright);
		Assert.IsNotNull(model.FrameworkName);
		Assert.IsNotNull(model.Repository);
	}
}
