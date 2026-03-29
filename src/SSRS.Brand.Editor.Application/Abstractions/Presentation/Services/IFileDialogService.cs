namespace SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

/// <summary>
/// The interface for the file dialog service.
/// </summary>
public interface IFileDialogService
{
  /// <summary>
  /// Shows an open file dialog and returns the selected file path.
  /// </summary>
  /// <param name="filter">The file type filter string.</param>
  /// <param name="title">The dialog title.</param>
  /// <returns>The selected file path, or <see langword="null"/> if cancelled.</returns>
  string? ShowOpenFileDialog(string filter, string title);

  /// <summary>
  /// Shows a save file dialog and returns the selected file path.
  /// </summary>
  /// <param name="filter">The file type filter string.</param>
  /// <param name="title">The dialog title.</param>
  /// <param name="defaultFileName">The default file name.</param>
  /// <returns>The selected file path, or <see langword="null"/> if cancelled.</returns>
  string? ShowSaveFileDialog(string filter, string title, string? defaultFileName = null);

  /// <summary>
  /// Shows an open file dialog for selecting image files.
  /// </summary>
  /// <returns>The selected image file path, or <see langword="null"/> if cancelled.</returns>
  string? ShowOpenImageDialog();
}
