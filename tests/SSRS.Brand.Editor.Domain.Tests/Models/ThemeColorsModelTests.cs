// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class ThemeColorsModelTests
{
	[TestMethod]
	public void ConstructorShouldCreateInstanceWithEmptyDataPoints()
	{
		ThemeColorsModel model;

		model = new ThemeColorsModel();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.DataPoints);
		Assert.IsEmpty(model.DataPoints);
	}

	[TestMethod]
	public void DataPointsShouldSupportAddAndRemove()
	{
		ThemeColorsModel model = new();

		model.DataPoints.Add(Color.Blue);
		model.DataPoints.Add(Color.Orange);
		model.DataPoints.Add(Color.Green);

		Assert.HasCount(3, model.DataPoints);
		Assert.AreEqual(Color.Blue, model.DataPoints[0]);
		Assert.AreEqual(Color.Orange, model.DataPoints[1]);
		Assert.AreEqual(Color.Green, model.DataPoints[2]);

		model.DataPoints.RemoveAt(1);

		Assert.HasCount(2, model.DataPoints);
		Assert.AreEqual(Color.Green, model.DataPoints[1]);
	}

	[TestMethod]
	public void StatusPropertiesShouldRaisePropertyChanged()
	{
		ThemeColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Good = Color.Green;
		model.Bad = Color.Red;
		model.Neutral = Color.Gold;
		model.None = Color.DarkGray;

		Assert.HasCount(4, changedProperties);
		Assert.AreEqual(Color.Green, model.Good);
		Assert.AreEqual(Color.Red, model.Bad);
		Assert.AreEqual(Color.Gold, model.Neutral);
		Assert.AreEqual(Color.DarkGray, model.None);
	}

	[TestMethod]
	public void StandardPropertiesShouldRaisePropertyChanged()
	{
		ThemeColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Background = Color.White;
		model.Foreground = Color.Black;
		model.MapBase = Color.CornflowerBlue;
		model.PanelBackground = Color.WhiteSmoke;
		model.PanelForeground = Color.Black;
		model.PanelAccent = Color.CornflowerBlue;
		model.TableAccent = Color.CornflowerBlue;

		Assert.HasCount(7, changedProperties);
		Assert.AreEqual(Color.White, model.Background);
		Assert.AreEqual(Color.Black, model.Foreground);
		Assert.AreEqual(Color.CornflowerBlue, model.MapBase);
		Assert.AreEqual(Color.WhiteSmoke, model.PanelBackground);
		Assert.AreEqual(Color.Black, model.PanelForeground);
		Assert.AreEqual(Color.CornflowerBlue, model.PanelAccent);
		Assert.AreEqual(Color.CornflowerBlue, model.TableAccent);
	}

	[TestMethod]
	public void AltPropertiesShouldRaisePropertyChanged()
	{
		ThemeColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.AltBackground = Color.WhiteSmoke;
		model.AltForeground = Color.Black;
		model.AltMapBase = Color.Orange;
		model.AltPanelBackground = Color.DarkSlateBlue;
		model.AltPanelForeground = Color.White;
		model.AltPanelAccent = Color.Gold;
		model.AltTableAccent = Color.Gold;

		Assert.HasCount(7, changedProperties);
		Assert.AreEqual(Color.WhiteSmoke, model.AltBackground);
		Assert.AreEqual(Color.Black, model.AltForeground);
		Assert.AreEqual(Color.Orange, model.AltMapBase);
		Assert.AreEqual(Color.DarkSlateBlue, model.AltPanelBackground);
		Assert.AreEqual(Color.White, model.AltPanelForeground);
		Assert.AreEqual(Color.Gold, model.AltPanelAccent);
		Assert.AreEqual(Color.Gold, model.AltTableAccent);
	}
}
