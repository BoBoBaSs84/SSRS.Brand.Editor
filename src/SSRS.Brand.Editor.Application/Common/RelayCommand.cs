namespace SSRS.Brand.Editor.Application.Common;

/// <summary>
/// The <see cref="RelayCommand"/> class.
/// </summary>
/// <remarks>
/// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
/// The default return value for the CanExecute method is <see langword="true"/>.
/// </remarks>
internal sealed class RelayCommand : IRelayCommand
{
	private readonly Action _execute;
	private readonly Func<bool>? _canExecute;

	/// <summary>
	/// Initializes a new instance of the <see cref="RelayCommand"/> class that can always execute.
	/// </summary>
	/// <param name="execute">The action to execute.</param>
	public RelayCommand(Action execute) : this(execute, null)
	{ }

	/// <summary>
	/// Initializes a new instance of the <see cref="RelayCommand"/> class.
	/// </summary>
	/// <param name="execute">The action to execute.</param>
	/// <param name="canExecute">The condition to execute.</param>
	public RelayCommand(Action execute, Func<bool>? canExecute)
	{
		_execute = execute;
		_canExecute = canExecute;
	}

	/// <inheritdoc/>
	public event EventHandler? CanExecuteChanged;

	/// <inheritdoc/>
	public bool CanExecute(object? parameter)
		=> _canExecute is null || _canExecute.Invoke();

	/// <inheritdoc/>
	public void Execute(object? parameter)
		=> _execute.Invoke();

	/// <inheritdoc/>
	public void NotifyCanExecuteChanged()
		=> CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

/// <summary>
/// The <see cref="RelayCommand{T}"/> class.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks>
/// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
/// The default return value for the CanExecute method is <see langword="true"/>.
/// </remarks>
internal sealed class RelayCommand<T> : IRelayCommand
{
	private readonly Action<T> _execute;
	private readonly Func<T, bool>? _canExecute;

	/// <summary>
	/// Initializes a new instance of <see cref="RelayCommand{T}"/> class that can always execute.
	/// </summary>
	/// <param name="execute">Delegate to execute when Execute is called on the command.
	/// This can be null to just hook up a CanExecute delegate.</param>
	public RelayCommand(Action<T> execute) : this(execute, null)
	{ }

	/// <summary>
	/// Initializes a new instance of <see cref="RelayCommand{T}"/> class.
	/// </summary>
	/// <param name="execute">The action to execute.</param>
	/// <param name="canExecute">The condition to execute.</param>
	public RelayCommand(Action<T> execute, Func<T, bool>? canExecute)
	{
		_execute = execute;
		_canExecute = canExecute;
	}

	/// <inheritdoc/>
	public event EventHandler? CanExecuteChanged;

	/// <inheritdoc/>
	public bool CanExecute(object? parameter)
		=> _canExecute is null || _canExecute((T)parameter!);

	/// <inheritdoc/>
	public void Execute(object? parameter)
		=> _execute((T)parameter!);

	/// <inheritdoc/>
	public void NotifyCanExecuteChanged()
		=> CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
