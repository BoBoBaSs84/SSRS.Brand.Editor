using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Domain.Exceptions;

namespace SSRS.Brand.Editor.Infrastructure.Services;

/// <summary>
/// The file service class.
/// </summary>
/// <remarks>
/// Initilizes an instance of the file service class.
/// </remarks>
/// <param name="loggerService">The logger service to use.</param>
internal sealed class FileService(ILoggerService<FileService> loggerService) : IFileService
{
	private static readonly Action<ILogger, Exception?> LogException =
		LoggerMessage.Define(LogLevel.Error, 0, "Exception occured.");

	public byte[] Load(string filePath)
	{
		try
		{
			byte[] content = File.ReadAllBytes(filePath);

			return content;
		}
		catch (Exception ex)
		{
			loggerService.Log(LogException, ex);
			throw new FileServiceException($"Could not load file: '{filePath}'", ex);
		}
	}

	public byte[] Load(string path, string fileName)
	{
		string filePath = Path.Combine(path, fileName);

		return Load(filePath);
	}

	public bool Save(string filePath, byte[] content)
	{
		try
		{
			File.WriteAllBytes(filePath, content);

			return File.Exists(filePath);
		}
		catch (Exception ex)
		{
			loggerService.Log(LogException, ex);
			throw new FileServiceException($"Could not save file: '{filePath}'", ex);
		}
	}

	public bool Save(string path, string fileName, byte[] content)
	{
		string filePath = Path.Combine(path, fileName);

		return Save(filePath, content);
	}
}
