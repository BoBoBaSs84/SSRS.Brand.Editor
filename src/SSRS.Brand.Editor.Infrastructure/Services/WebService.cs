// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

using Microsoft.Extensions.Logging;

using ApplicationConstants = SSRS.Brand.Editor.Infrastructure.Common.Constants;

namespace SSRS.Brand.Editor.Infrastructure.Services;

/// <summary>
/// The web service class.
/// </summary>
/// <param name="httpClientFactory">The http client factory instance to use.</param>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="notificationService">The notification service instance to use.</param>
internal sealed class WebService(IHttpClientFactory httpClientFactory, ILoggerService<WebService> loggerService, INotificationService notificationService) : IWebService
{
	private static readonly Action<ILogger, Exception?> LogException =
		LoggerMessage.Define(LogLevel.Error, 0, "Exception occured.");

	public async Task<string> GetPizzaContentAsync(CancellationToken cancellationToken = default)
	{
		try
		{
			HttpClient httpClient = httpClientFactory.CreateClient(ApplicationConstants.WikiClient.Name);
			string requestUri = @"/w/api.php?action=query&prop=revisions&format=json&rvprop=content&rvsection=0&titles=pizza";
			using HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri, cancellationToken)
				.ConfigureAwait(false);

			_ = responseMessage.EnsureSuccessStatusCode();

			string jsonContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken)
				.ConfigureAwait(false);

			return jsonContent;
		}
		catch (Exception ex)
		{
			loggerService.Log(LogException, ex);
			notificationService.ShowError(ex.Message);
			return string.Empty;
		}
	}
}
