using System.Diagnostics.CodeAnalysis;
using System.IO;

using BB84.SourceGenerators.Attributes;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;

namespace SSRS.Brand.Editor.Application.Providers;

/// <summary>
/// Represents a provider for directory-related operations. This class serves as
/// a wrapper around the <see cref="Directory"/> class, providing an abstraction
/// layer for directory operations within the application.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "This class is a simple wrapper around the System.IO.Directory class.")]
[GenerateAbstraction(typeof(Directory), typeof(IDirectoryProvider), typeof(DirectoryProvider))]
internal sealed partial class DirectoryProvider : IDirectoryProvider
{ }
