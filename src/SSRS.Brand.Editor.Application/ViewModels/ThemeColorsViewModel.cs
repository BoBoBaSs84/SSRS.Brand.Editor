// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections.ObjectModel;
using System.Drawing;

using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using SSRS.Brand.Editor.Application.ViewModels.Base;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The theme colors view model class.
/// </summary>
/// <param name="model">The theme colors model instance to use.</param>
public sealed class ThemeColorsViewModel(ThemeColorsModel model) : ViewModelBase
{
	private IActionCommand? _addDataPointCommand;
	private IActionCommand? _removeDataPointCommand;
	private Color _selectedDataPoint;
	private int _selectedDataPointIndex = -1;

	/// <summary>
	/// The theme colors model instance.
	/// </summary>
	public ThemeColorsModel Model => model;

	/// <summary>
	/// The data points collection.
	/// </summary>
	public ObservableCollection<Color> DataPoints => model.DataPoints;

	/// <summary>
	/// The currently selected data point color for editing.
	/// </summary>
	public Color SelectedDataPoint
	{
		get => _selectedDataPoint;
		set
		{
			SetProperty(ref _selectedDataPoint, value);

			if (_selectedDataPointIndex >= 0 && _selectedDataPointIndex < model.DataPoints.Count)
				model.DataPoints[_selectedDataPointIndex] = value;
		}
	}

	/// <summary>
	/// The index of the currently selected data point.
	/// </summary>
	public int SelectedDataPointIndex
	{
		get => _selectedDataPointIndex;
		set
		{
			SetProperty(ref _selectedDataPointIndex, value);
			_removeDataPointCommand?.RaiseCanExecuteChanged();

			if (value >= 0 && value < model.DataPoints.Count)
			{
				_selectedDataPoint = model.DataPoints[value];
				RaisePropertyChanged(nameof(SelectedDataPoint));
			}
		}
	}

	/// <summary>
	/// The command to add a new data point color.
	/// </summary>
	public IActionCommand AddDataPointCommand
		=> _addDataPointCommand ??= new ActionCommand(AddDataPoint);

	/// <summary>
	/// The command to remove the selected data point color.
	/// </summary>
	public IActionCommand RemoveDataPointCommand
		=> _removeDataPointCommand ??= new ActionCommand(RemoveDataPoint, CanRemoveDataPoint);

	private void AddDataPoint()
	{
		model.DataPoints.Add(Color.FromArgb(0, 114, 198));
		SelectedDataPointIndex = model.DataPoints.Count - 1;
	}

	private void RemoveDataPoint()
	{
		if (_selectedDataPointIndex >= 0 && _selectedDataPointIndex < model.DataPoints.Count)
		{
			model.DataPoints.RemoveAt(_selectedDataPointIndex);

			SelectedDataPointIndex = model.DataPoints.Count > 0 ? Math.Min(_selectedDataPointIndex, model.DataPoints.Count - 1) : -1;
		}
	}

	private bool CanRemoveDataPoint()
		=> _selectedDataPointIndex >= 0 && _selectedDataPointIndex < model.DataPoints.Count;
}
