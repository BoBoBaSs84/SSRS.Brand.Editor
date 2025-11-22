using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;

namespace SSRS.Brand.Editor.Infrastructure.Providers;

/// <summary>
/// The implementation for the path provider contract.
/// </summary>
/// <inheritdoc cref="IPathProvider"/>
[ExcludeFromCodeCoverage(Justification = "This class is a simple wrapper around the System.IO.Path class.")]
internal sealed class PathProvider : IPathProvider
{
	public string Combine(params string[] paths)
		=> Path.Combine(paths);

	public bool Exists([NotNullWhen(true)] string? path)
		=> Path.Exists(path);

	public string? GetDirectoryName(string? path)
		=> Path.GetDirectoryName(path);

	public string? GetExtension(string? path)
		=> Path.GetExtension(path);

	public string? GetFileName(string? path)
		=> Path.GetFileName(path);

	public string? GetFileNameWithoutExtension(string? path)
		=> Path.GetFileNameWithoutExtension(path);

	public string GetFullPath(string path)
		=> Path.GetFullPath(path);

	public string GetFullPath(string path, string basePath)
		=> Path.GetFullPath(path, basePath);

	public string? GetPathRoot(string? path)
		=> Path.GetPathRoot(path);

	public string GetRandomFileName()
		=> Path.GetRandomFileName();

	public string GetRelativePath(string relativeTo, string path)
		=> Path.GetRelativePath(relativeTo, path);

	public string GetTempFileName()
		=> Path.GetTempFileName();

	public string GetTempPath()
		=> Path.GetTempPath();

	public bool HasExtension([NotNullWhen(true)] string? path)
		=> Path.HasExtension(path);

	public bool IsPathFullyQualified(string path)
		=> Path.IsPathFullyQualified(path);

	public bool IsPathRooted([NotNullWhen(true)] string? path)
		=> Path.IsPathRooted(path);

	public string TrimEndingDirectorySeparator(string path)
		=> Path.TrimEndingDirectorySeparator(path);
}
