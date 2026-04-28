using System.Diagnostics.CodeAnalysis;
using System.IO;

using BB84.SourceGenerators.Attributes;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;

namespace SSRS.Brand.Editor.Application.Providers;

/// <summary>
/// Represents a provider for file-related operations. This class serves as
/// a wrapper around the <see cref="File"/> class, providing an abstraction
/// layer for file operations within the application.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "This class is a simple wrapper around the System.IO.File class.")]
[GenerateAbstraction(typeof(File), typeof(IFileProvider), typeof(FileProvider))]
internal sealed partial class FileProvider : IFileProvider
{ }
