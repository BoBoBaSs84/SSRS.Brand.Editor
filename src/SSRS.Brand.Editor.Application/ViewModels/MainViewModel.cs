using System.Windows.Input;

using SSRS.Brand.Editor.Application.Common;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
public sealed class MainViewModel : ViewModelBase
{
	private string _text;
	private ICommand? _getTextCommand;
	private ICommand? _setTextCommand;

	/// <summary>
	/// 
	/// </summary>
	public MainViewModel()
	{
		_text = string.Empty;
	}

	/// <summary>
	/// The text property.
	/// </summary>
	public string Text { get => _text; set => SetProperty(ref _text, value); }

	/// <summary>
	/// Gets the text.
	/// </summary>
	public ICommand GetTextCommand
		=> _getTextCommand ??= new RelayCommand(GetText);

	/// <summary>
	/// Sets the text.
	/// </summary>
	public ICommand SetTextCommand
		=> _setTextCommand ??= new RelayCommand(SetText);

	private void SetText()
		=> Text = "This is the set text.";

	private void GetText()
		=> Text = "This is the get text.";
}
