// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
using SSRS.Brand.Editor.Application.Providers;

namespace SSRS.Brand.Editor.Application.Services;

/// <summary>
/// Represents a service that provides access to external providers.
/// </summary>
internal sealed class ProviderService : IProviderService
{
	private readonly Lazy<IDateTimeProvider> _dateTimeProvider = new(() => new DateTimeProvider());
	private readonly Lazy<IDirectoryProvider> _directoryProvider = new(() => new DirectoryProvider());
	private readonly Lazy<IEnvironmentProvider> _environmentProvider = new(() => new EnvironmentProvider());
	private readonly Lazy<IFileProvider> _fileProvider = new(() => new FileProvider());
	private readonly Lazy<IPathProvider> _pathProvider = new(() => new PathProvider());

	public IDateTimeProvider DateTime => _dateTimeProvider.Value;
	public IDirectoryProvider Directory => _directoryProvider.Value;
	public IEnvironmentProvider Environment => _environmentProvider.Value;
	public IFileProvider File => _fileProvider.Value;
	public IPathProvider Path => _pathProvider.Value;
}
