namespace SSRS.Brand.Editor.Domain.Exceptions;

/// <summary>
/// The file service exception class.
/// </summary>
/// <param name="message">The exception message.</param>
/// <param name="innerException">The inner exception.</param>
[Serializable]
public sealed class FileServiceException(string message, Exception? innerException) : Exception(message, innerException)
{
	/// <summary>
	/// Throws the file service exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <exception cref="FileServiceException"></exception>
	public static void Throw(string message)
		=> Throw(message, null);

	/// <summary>
	/// Throws the file service exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception.</param>
	/// <exception cref="FileServiceException"></exception>
	public static void Throw(string message, Exception? innerException)
		=> throw new FileServiceException(message, innerException);
}
