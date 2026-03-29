using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Infrastructure.Providers;

namespace SSRS.Brand.Editor.Infrastructure.Services;

/// <summary>
/// Represents a service that provides access to external providers.
/// </summary>
internal sealed class ProviderService : IProviderService
{
	private readonly Lazy<IDateTimeProvider> _dateTimeProvider = new(() => new DateTimeProvider());
	private readonly Lazy<IDirectoryProvider> _directoryProvider = new(() => new DirectoryProvider());
	private readonly Lazy<IFileProvider> _fileProvider = new(() => new FileProvider());

	public IDateTimeProvider DateTime => _dateTimeProvider.Value;

	public IDirectoryProvider Directory => _directoryProvider.Value;

	public IFileProvider File => _fileProvider.Value;
}
