using System.Diagnostics.CodeAnalysis;

using BB84.SourceGenerators.Attributes;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;

namespace SSRS.Brand.Editor.Application.Providers;

/// <summary>
/// Represents the implementation for the environment provider contract, which provides access
/// to environment-related information and operations.
/// </summary>
[ExcludeFromCodeCoverage]
[GenerateAbstraction(typeof(Environment), typeof(IEnvironmentProvider), typeof(EnvironmentProvider))]
internal sealed partial class EnvironmentProvider : IEnvironmentProvider
{ }
