using System.Drawing;

using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class ThemeColorsViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void ConstructorShouldSetModel()
	{
		ThemeColorsModel model = new();

		ThemeColorsViewModel viewModel = new(model);

		Assert.AreEqual(model, viewModel.Model);
		Assert.AreEqual(model.DataPoints, viewModel.DataPoints);
		Assert.AreEqual(-1, viewModel.SelectedDataPointIndex);
	}

	[TestMethod]
	public void AddDataPointCommandShouldAddColor()
	{
		ThemeColorsModel model = new();
		ThemeColorsViewModel viewModel = new(model);

		viewModel.AddDataPointCommand.Execute(null);

		Assert.AreEqual(1, model.DataPoints.Count);
		Assert.AreEqual(0, viewModel.SelectedDataPointIndex);
	}

	[TestMethod]
	public void AddDataPointCommandShouldSelectLastAdded()
	{
		ThemeColorsModel model = new();
		ThemeColorsViewModel viewModel = new(model);

		viewModel.AddDataPointCommand.Execute(null);
		viewModel.AddDataPointCommand.Execute(null);
		viewModel.AddDataPointCommand.Execute(null);

		Assert.AreEqual(3, model.DataPoints.Count);
		Assert.AreEqual(2, viewModel.SelectedDataPointIndex);
	}

	[TestMethod]
	public void RemoveDataPointCommandShouldRemoveSelected()
	{
		ThemeColorsModel model = new();
		model.DataPoints.Add(Color.Red);
		model.DataPoints.Add(Color.Green);
		model.DataPoints.Add(Color.Blue);
		ThemeColorsViewModel viewModel = new(model) { SelectedDataPointIndex = 1 };

		viewModel.RemoveDataPointCommand.Execute(null);

		Assert.AreEqual(2, model.DataPoints.Count);
		Assert.AreEqual(Color.Red, model.DataPoints[0]);
		Assert.AreEqual(Color.Blue, model.DataPoints[1]);
	}

	[TestMethod]
	public void RemoveDataPointCommandShouldAdjustIndexWhenRemovingLast()
	{
		ThemeColorsModel model = new();
		model.DataPoints.Add(Color.Red);
		model.DataPoints.Add(Color.Green);
		ThemeColorsViewModel viewModel = new(model) { SelectedDataPointIndex = 1 };

		viewModel.RemoveDataPointCommand.Execute(null);

		Assert.AreEqual(1, model.DataPoints.Count);
		Assert.AreEqual(0, viewModel.SelectedDataPointIndex);
	}

	[TestMethod]
	public void RemoveDataPointCommandShouldSetIndexToNegativeWhenEmpty()
	{
		ThemeColorsModel model = new();
		model.DataPoints.Add(Color.Red);
		ThemeColorsViewModel viewModel = new(model) { SelectedDataPointIndex = 0 };

		viewModel.RemoveDataPointCommand.Execute(null);

		Assert.AreEqual(0, model.DataPoints.Count);
		Assert.AreEqual(-1, viewModel.SelectedDataPointIndex);
	}

	[TestMethod]
	public void SelectedDataPointPropertyShouldRaisePropertyChanged()
	{
		ThemeColorsModel model = new();
		ThemeColorsViewModel viewModel = new(model);
		bool raised = false;
		viewModel.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(ThemeColorsViewModel.SelectedDataPoint))
				raised = true;
		};

		viewModel.SelectedDataPoint = Color.Red;

		Assert.IsTrue(raised);
		Assert.AreEqual(Color.Red, viewModel.SelectedDataPoint);
	}
}
