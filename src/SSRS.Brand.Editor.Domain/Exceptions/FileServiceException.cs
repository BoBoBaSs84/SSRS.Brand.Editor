namespace SSRS.Brand.Editor.Domain.Exceptions;

/// <summary>
/// The file service exception class.
/// </summary>
public sealed class FileServiceException : Exception
{
	/// <summary>
	/// Initilizes an instance of the file service exception class.
	/// </summary>
	public FileServiceException() : base()
	{ }

	/// <summary>
	/// Initilizes an instance of the file service exception class.
	/// </summary>
	/// <param name="message">The exception message.</param>
	public FileServiceException(string message) : base(message)
	{ }

	/// <summary>
	/// Initilizes an instance of the file service exception class.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception.</param>
	public FileServiceException(string message, Exception innerException) : base(message, innerException)
	{ }
}
