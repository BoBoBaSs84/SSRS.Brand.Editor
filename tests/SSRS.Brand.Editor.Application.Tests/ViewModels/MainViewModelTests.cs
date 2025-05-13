using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;
[TestClass]
public sealed class MainViewModelTests
{
	[TestMethod]
	public void ConstructorShouldSetPropertiesCorrect()
	{
		Mock<IHostEnvironment> hostEnvironmentMock = new();
		hostEnvironmentMock.Setup(x => x.ApplicationName).Returns("TestApp");
		hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("TestEnv");
		Mock<IUserService> userServiceMock = new();
		userServiceMock.Setup(x => x.Domain).Returns("TestDomain");
		userServiceMock.Setup(x => x.Name).Returns("TestUser");
		userServiceMock.Setup(x => x.Machine).Returns("TestMachine");

		MainViewModel viewModel = new(hostEnvironmentMock.Object, userServiceMock.Object);

		Assert.AreEqual("TestApp", viewModel.ApplicationName);
		Assert.AreEqual("TestEnv", viewModel.EnvironmentName);
		Assert.AreEqual("TestDomain\\TestUser@TestMachine", viewModel.CurrentUser);
	}
}
