namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;

/// <summary>
/// The interface for the web service.
/// </summary>
public interface IWebService
{
	/// <summary>
	/// Returns the wikpedia pizza content.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the request.</param>
	/// <returns>The wikipedia pizza content.</returns>
	Task<string> GetPizzaContentAsync(CancellationToken cancellationToken = default);
}
