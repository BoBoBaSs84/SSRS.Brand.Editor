using System.Diagnostics.CodeAnalysis;

using Microsoft.Win32;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

namespace SSRS.Brand.Editor.Presentation.Services;

/// <summary>
/// The file dialog service class.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "This class wraps WPF file dialogs which require a UI thread.")]
internal sealed class FileDialogService : IFileDialogService
{
	/// <inheritdoc/>
	public string? ShowOpenFileDialog(string filter, string title)
	{
		OpenFileDialog dialog = new()
		{
			Filter = filter,
			Title = title
		};

		return dialog.ShowDialog() == true ? dialog.FileName : null;
	}

	/// <inheritdoc/>
	public string? ShowSaveFileDialog(string filter, string title, string? defaultFileName = null)
	{
		SaveFileDialog dialog = new()
		{
			Filter = filter,
			Title = title,
			FileName = defaultFileName ?? string.Empty
		};

		return dialog.ShowDialog() == true ? dialog.FileName : null;
	}

	/// <inheritdoc/>
	public string? ShowOpenImageDialog()
	{
		OpenFileDialog dialog = new()
		{
			Filter = "PNG Images (*.png)|*.png",
			Title = "Select Logo Image"
		};

		return dialog.ShowDialog() == true ? dialog.FileName : null;
	}
}
