using System.Windows;

namespace SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

/// <summary>
/// The interface for the notification service.
/// </summary>
public interface INotificationService
{
	/// <summary>
	/// Shows a error message.
	/// </summary>
	/// <param name="message">The message to show.</param>
	void ShowError(string message);

	/// <summary>
	/// Shows a informational message.
	/// </summary>
	/// <param name="message">The message to show.</param>
	void ShowInformation(string message);

	/// <summary>
	/// Shows a warning message.
	/// </summary>
	/// <param name="message">The message to show.</param>
	void ShowWarning(string message);

	/// <summary>
	/// Shows a retry message and return the result.
	/// </summary>
	/// <param name="message">The message to show.</param>
	/// <returns>The result of the retry message.</returns>
	MessageBoxResult ShowRetry(string message);

	/// <summary>
	/// Shows a question message and return the result.
	/// </summary>
	/// <param name="message">The question to show.</param>
	/// <returns>The result of the question.</returns>
	MessageBoxResult ShowQuestion(string message);
}
