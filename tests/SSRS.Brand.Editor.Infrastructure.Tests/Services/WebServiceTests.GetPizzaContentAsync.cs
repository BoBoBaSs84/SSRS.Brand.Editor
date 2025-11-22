using System.Net;

using Microsoft.Extensions.Logging;

using Moq;

using SSRS.Brand.Editor.Infrastructure.Services;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Services;
public sealed partial class WebServiceTests
{
	[TestMethod]
	public async Task GetPizzaContentAsyncShouldLogAndNotifyOnException()
	{
		WebService sut = CreateMockedInstance();
		_httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
			.Throws<Exception>();

		string? result = await sut.GetPizzaContentAsync()
			.ConfigureAwait(false);

		Assert.IsNotNull(result);
		_loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception?>()), Times.Once);
		_notificationServiceMock.Verify(x => x.ShowError(It.IsAny<string>()), Times.Once);
	}

	[TestMethod]
	public async Task GetPizzaContentAsyncShouldLogAndNotifyOnNotSuccessful()
	{
		WebService sut = CreateMockedInstance();
		_httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
			.Returns(CreateMockedClient(HttpStatusCode.InternalServerError));

		string? result = await sut.GetPizzaContentAsync()
			.ConfigureAwait(false);

		Assert.IsNotNull(result);
		_loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception?>()), Times.Once);
		_notificationServiceMock.Verify(x => x.ShowError(It.IsAny<string>()), Times.Once);
	}

	[TestMethod]
	public async Task GetPizzaContentAsyncShouldReturnContentAndNotLogOrNotify()
	{
		WebService sut = CreateMockedInstance();
		string content = "{ \"query\": { \"pages\": { \"123\": { \"revisions\": [ { \"*\": \"Pizza content\" } ] } } } }";
		_httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
			.Returns(CreateMockedClient(HttpStatusCode.OK, content));

		string? result = await sut.GetPizzaContentAsync()
			.ConfigureAwait(false);

		Assert.AreEqual(content, result);
		_loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception?>()), Times.Never);
		_notificationServiceMock.Verify(x => x.ShowError(It.IsAny<string>()), Times.Never);
	}
}
