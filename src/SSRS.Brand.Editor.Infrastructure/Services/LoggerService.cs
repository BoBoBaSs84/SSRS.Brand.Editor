using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;

namespace SSRS.Brand.Editor.Infrastructure.Services;
/// <summary>
/// The logger service implementation.
/// </summary>
/// <param name="logger">The logger instance to use.</param>
/// <typeparam name="T">The type of the logger service.</typeparam>
[ExcludeFromCodeCoverage(Justification = "This is a wrapper class.")]
internal sealed class LoggerService<T>(ILogger<T> logger) : ILoggerService<T> where T : class
{
	/// <inheritdoc/>
	public void Log(Action<ILogger, Exception?> loggingDelegate, Exception? exception = null)
		=> loggingDelegate?.Invoke(logger, exception);

	/// <inheritdoc/>
	public void Log<T1>(Action<ILogger, T1, Exception?> loggingDelegate, T1 param, Exception? exception = null)
		=> loggingDelegate?.Invoke(logger, param, exception);

	/// <inheritdoc/>
	public void Log<T1, T2>(Action<ILogger, T1, T2, Exception?> loggingDelegate, T1 param1, T2 param2, Exception? exception = null)
		=> loggingDelegate?.Invoke(logger, param1, param2, exception);

	/// <inheritdoc/>
	public void Log<T1, T2, T3>(Action<ILogger, T1, T2, T3, Exception?> loggingDelegate,
		T1 param1, T2 param2, T3 param3, Exception? exception = null)
		=> loggingDelegate?.Invoke(logger, param1, param2, param3, exception);

	/// <inheritdoc/>
	public void Log<T1, T2, T3, T4>(Action<ILogger, T1, T2, T3, T4, Exception?> loggingDelegate,
		T1 param1, T2 param2, T3 param3, T4 param4)
		=> loggingDelegate?.Invoke(logger, param1, param2, param3, param4, null);

	/// <inheritdoc/>
	public void Log<T1, T2, T3, T4, T5>(Action<ILogger, T1, T2, T3, T4, T5, Exception?> loggingDelegate,
		T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
		=> loggingDelegate?.Invoke(logger, param1, param2, param3, param4, param5, null);

	/// <inheritdoc/>
	public void Log<T1, T2, T3, T4, T5, T6>(Action<ILogger, T1, T2, T3, T4, T5, T6, Exception?> loggingDelegate,
		T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
		=> loggingDelegate?.Invoke(logger, param1, param2, param3, param4, param5, param6, null);
}
