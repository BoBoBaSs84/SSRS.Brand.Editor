// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;
using System.Text.Json;

using SSRS.Brand.Editor.Application.Converters;

namespace SSRS.Brand.Editor.Application.Tests.Converters;

[TestClass]
public sealed class JsonDrawingColorConverterTests : ApplicationTestBase
{
	private static readonly JsonSerializerOptions Options = new()
	{
		Converters = { new JsonDrawingColorConverter() }
	};

	[TestMethod]
	public void ReadShouldDeserializeHexColorString()
	{
		string json = "\"#FF0000\"";

		Color result = JsonSerializer.Deserialize<Color>(json, Options);

		Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), result);
	}

	[TestMethod]
	public void ReadShouldReturnTransparentForEmptyString()
	{
		string json = "\"\"";

		Color result = JsonSerializer.Deserialize<Color>(json, Options);

		Assert.AreEqual(Color.Transparent, result);
	}

	[TestMethod]
	public void ReadShouldReturnTransparentForNullValue()
	{
		string json = "null";

		Color result = JsonSerializer.Deserialize<Color>(json, Options);

		Assert.AreEqual(Color.Transparent, result);
	}

	[TestMethod]
	public void WriteShouldSerializeColorToHexString()
	{
		Color color = Color.FromArgb(255, 0, 0);

		string json = JsonSerializer.Serialize(color, Options);

		Assert.AreEqual("\"#FF0000\"", json);
	}

	[TestMethod]
	public void RoundTripShouldPreserveColor()
	{
		Color original = Color.FromArgb(18, 35, 158);

		string json = JsonSerializer.Serialize(original, Options);
		Color deserialized = JsonSerializer.Deserialize<Color>(json, Options);

		Assert.AreEqual(original.R, deserialized.R);
		Assert.AreEqual(original.G, deserialized.G);
		Assert.AreEqual(original.B, deserialized.B);
	}
}
