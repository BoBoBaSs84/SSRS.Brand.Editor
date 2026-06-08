using System.Diagnostics.CodeAnalysis;
using System.IO;

using BB84.SourceGenerators.Attributes;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;

namespace SSRS.Brand.Editor.Application.Providers;

/// <summary>
/// Represents a provider for path-related operations. This class serves as
/// a wrapper around the <see cref="Path"/> class, providing an abstraction
/// layer for path operations within the application.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "This class is a simple wrapper around the System.IO.Path class.")]
[GenerateAbstraction(typeof(Path), typeof(IPathProvider), typeof(PathProvider))]
internal sealed partial class PathProvider : IPathProvider
{ }
