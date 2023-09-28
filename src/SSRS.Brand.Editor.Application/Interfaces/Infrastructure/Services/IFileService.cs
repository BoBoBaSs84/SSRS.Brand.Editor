using SSRS.Brand.Editor.Domain.Exceptions;

namespace SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The file service interface.
/// </summary>
public interface IFileService
{
	/// <summary>
	/// Loads the file and returns its content.
	/// </summary>
	/// <param name="filePath">The full file path of the file to load.</param>
	/// <returns>The file content as byte array.</returns>
	/// <exception cref="FileServiceException"></exception>
	byte[] Load(string filePath);

	/// <summary>
	/// Loads the file and returns its content.
	/// </summary>
	/// <param name="path">The path of the file to load.</param>
	/// <param name="fileName">The file name of the file to load.</param>
	/// <returns>The file content as byte array.</returns>
	byte[] Load(string path, string fileName);

	/// <summary>
	/// Saves the content to the provided file path.
	/// </summary>
	/// <param name="filePath">The full file path where the file should be saved.</param>
	/// <param name="content">The file content as byte array.</param>
	/// <returns><see langword="true"/> if the file could be saved, otherwise <see langword="false"/></returns>
	/// <exception cref="FileServiceException"></exception>
	bool Save(string filePath, byte[] content);

	/// <summary>
	/// Saves the content to the provided path and file name.
	/// </summary>
	/// <param name="path">The path where the file should be saved.</param>
	/// <param name="fileName">The file name of the file to be saved.</param>
	/// <param name="content">The file content as byte array.</param>
	/// <returns><see langword="true"/> if the file could be saved, otherwise <see langword="false"/></returns>
	bool Save(string path, string fileName, byte[] content);
}
