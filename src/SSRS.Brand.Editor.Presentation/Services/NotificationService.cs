// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

namespace SSRS.Brand.Editor.Presentation.Services;

/// <summary>
/// The notification service class.
/// </summary>
internal sealed class NotificationService : INotificationService
{
	public void ShowError(string message)
		=> ShowMessage(message, "Error", MessageBoxImage.Error);

	public void ShowInformation(string message)
		=> ShowMessage(message, "Information", MessageBoxImage.Information);

	public void ShowWarning(string message)
		=> ShowMessage(message, "Warning", MessageBoxImage.Warning);

	public MessageBoxResult ShowRetry(string message)
		=> ShowQuestion(message, "Retry", MessageBoxImage.Question);

	public MessageBoxResult ShowQuestion(string message)
	 => ShowQuestion(message, "Question", MessageBoxImage.Question);

	private static void ShowMessage(string message, string captition, MessageBoxImage icon)
		=> MessageBox.Show(message, captition, MessageBoxButton.OK, icon);

	private static MessageBoxResult ShowQuestion(string message, string captition, MessageBoxImage icon)
		=> MessageBox.Show(message, captition, MessageBoxButton.YesNo, icon);
}
