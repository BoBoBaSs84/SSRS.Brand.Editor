// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Net;
using System.Text;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Infrastructure.Common;
using SSRS.Brand.Editor.Infrastructure.Services;

using Moq;
using Moq.Protected;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Services;

[TestClass]
public sealed partial class WebServiceTests
{
	private Mock<IHttpClientFactory> _httpClientFactoryMock = new();
	private Mock<ILoggerService<WebService>> _loggerServiceMock = new();
	private Mock<INotificationService> _notificationServiceMock = new();
	private Mock<HttpMessageHandler> _httpMessageHandler = new();

	private WebService CreateMockedInstance()
	{
		_httpClientFactoryMock = new();
		_loggerServiceMock = new();
		_notificationServiceMock = new();

		return new(_httpClientFactoryMock.Object, _loggerServiceMock.Object, _notificationServiceMock.Object);
	}

	private HttpClient CreateMockedClient(HttpStatusCode statusCode, string? content = null)
	{
		_httpMessageHandler = new(MockBehavior.Strict);

		HttpResponseMessage responseMessage = new(statusCode)
		{
			Content = new StringContent(content ?? string.Empty, Encoding.UTF8, Constants.WikiClient.MediaType)
		};

		_httpMessageHandler.Protected()
			.Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
			.ReturnsAsync(responseMessage)
			.Verifiable();

		return new(_httpMessageHandler.Object) { BaseAddress = new Uri(Constants.WikiClient.BaseUrl) };
	}
}
