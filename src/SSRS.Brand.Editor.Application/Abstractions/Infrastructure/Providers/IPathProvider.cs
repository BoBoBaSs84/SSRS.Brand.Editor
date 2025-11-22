using System.Diagnostics.CodeAnalysis;

namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;

/// <summary>
/// This interface defines a contract for path provider.
/// </summary>
/// <remarks>
/// Serves as an abstraction for the <see cref="Path"/> operations.
/// </remarks>
public interface IPathProvider
{
	/// <inheritdoc cref="Path.Combine(string[])"/>
	string Combine(params string[] paths);

	/// <inheritdoc cref="Path.Exists(string?)"/>
	bool Exists([NotNullWhen(true)] string? path);

	/// <inheritdoc cref="Path.GetDirectoryName(string?)"/>
	string? GetDirectoryName(string? path);

	/// <inheritdoc cref="Path.GetExtension(string?)"/>
	string? GetExtension(string? path);

	/// <inheritdoc cref="Path.GetFileName(string?)"/>
	string? GetFileName(string? path);

	/// <inheritdoc cref="Path.GetFileNameWithoutExtension(string?)"/>
	string? GetFileNameWithoutExtension(string? path);

	/// <inheritdoc cref="Path.GetFullPath(string?)"/>
	string GetFullPath(string path);

	/// <inheritdoc cref="Path.GetFullPath(string, string)"/>
	string GetFullPath(string path, string basePath);

	/// <inheritdoc cref="Path.GetPathRoot(string?)"/>
	string? GetPathRoot(string? path);

	/// <inheritdoc cref="Path.GetRandomFileName()"/>
	string GetRandomFileName();

	/// <inheritdoc cref="Path.GetRelativePath(string, string)"/>
	string GetRelativePath(string relativeTo, string path);

	/// <inheritdoc cref="Path.GetTempFileName()"/>
	string GetTempFileName();

	/// <inheritdoc cref="Path.GetTempPath()"/>
	string GetTempPath();

	/// <inheritdoc cref="Path.HasExtension(string?)"/>
	bool HasExtension([NotNullWhen(true)] string? path);

	/// <inheritdoc cref="Path.IsPathFullyQualified(string?)"/>
	bool IsPathFullyQualified(string path);

	/// <inheritdoc cref="Path.IsPathRooted(string?)"/>
	bool IsPathRooted([NotNullWhen(true)] string? path);

	/// <inheritdoc cref="Path.TrimEndingDirectorySeparator(string)"/>
	string TrimEndingDirectorySeparator(string path);
}
