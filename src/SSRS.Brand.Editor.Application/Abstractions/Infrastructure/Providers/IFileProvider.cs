namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;

/// <summary>
/// This interface defines a contract for file provider.
/// </summary>
/// <remarks>
/// Serves as an abstraction for the <see cref="File"/> operations.
/// </remarks>
public interface IFileProvider
{
	/// <inheritdoc cref="File.Copy(string, string, bool)"/>
	void Copy(string sourcePath, string destinationPath, bool overwrite = false);

	/// <inheritdoc cref="File.Delete(string)"/>
	void Delete(string path);

	/// <inheritdoc cref="File.Exists(string)"/>
	bool Exists(string path);

	/// <inheritdoc cref="File.Move(string, string, bool)"/>
	void Move(string sourcePath, string destinationPath, bool overwrite = false);

	/// <inheritdoc cref="File.ReadAllBytes(string)"/>
	byte[] ReadAllBytes(string path);

	/// <inheritdoc cref="File.ReadAllBytesAsync(string, CancellationToken)"/>
	Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);

	/// <inheritdoc cref="File.ReadAllLines(string)"/>
	string[] ReadAllLines(string path);

	/// <inheritdoc cref="File.ReadAllLinesAsync(string, CancellationToken)"/>
	Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);

	/// <inheritdoc cref="File.ReadAllText(string)"/>
	string ReadAllText(string path);

	/// <inheritdoc cref="File.ReadAllTextAsync(string, CancellationToken)"/>
	Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);

	/// <inheritdoc cref="File.WriteAllBytes(string, byte[])"/>
	void WriteAllBytes(string path, byte[] bytes);

	/// <inheritdoc cref="File.WriteAllBytesAsync(string, byte[], CancellationToken)"/>
	Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);

	/// <inheritdoc cref="File.WriteAllLines(string, string[])"/>
	void WriteAllLines(string path, string[] contents);

	/// <inheritdoc cref="File.WriteAllLinesAsync(string, IEnumerable{string}, CancellationToken)"/>
	Task WriteAllLinesAsync(string path, string[] contents, CancellationToken cancellationToken = default);

	/// <inheritdoc cref="File.WriteAllText(string, string?)"/>
	void WriteAllText(string path, string? contents);
	/// <inheritdoc cref="File.WriteAllTextAsync(string, string?, CancellationToken)"/>
	Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
}
