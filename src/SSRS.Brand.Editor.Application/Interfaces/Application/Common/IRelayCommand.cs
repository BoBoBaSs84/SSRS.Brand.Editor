using System.Windows.Input;

namespace SSRS.Brand.Editor.Application.Interfaces.Application.Common;

/// <summary>
/// An interface expanding <see cref="ICommand"/> with the ability
/// to raise the <see cref="ICommand.CanExecuteChanged"/> event externally.
/// </summary>
public interface IRelayCommand : ICommand
{
	/// <summary>
	/// Notifies that the <see cref="ICommand.CanExecute(object?)"/>
	/// property has changed.
	/// </summary>
	void NotifyCanExecuteChanged();
}
