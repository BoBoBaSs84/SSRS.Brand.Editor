using BB84.Notifications.Commands;

using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class MainViewModelTests : ApplicationTestBase
{
	private readonly Mock<IHostEnvironment> _hostEnvironmentMock;
	private readonly Mock<INavigationService> _navigationServiceMock;
	private readonly Mock<IUserService> _userServiceMock;
	private readonly BrandEditorViewModel _brandEditorViewModel;

	public MainViewModelTests()
	{
		_hostEnvironmentMock = new();
		_navigationServiceMock = new();
		_userServiceMock = new();
		_brandEditorViewModel = new(
			new Mock<IBrandPackageService>().Object,
			new Mock<IFileDialogService>().Object,
			new Mock<IProviderService>().Object,
			new Mock<INotificationService>().Object,
			new Mock<ILoggerService<BrandEditorViewModel>>().Object);
	}

	[TestMethod]
	public void MainViewModelConstructorShouldSetUpAllPropertiesCorrectly()
	{
		string expectedApplicationName = "TestApp";
		string expectedEnvironmentName = "TestEnv";
		string expectedDomainName = "TestDomain";
		string expectedUserName = "TestUser";
		string expectedMachineName = "TestMachine";
		_hostEnvironmentMock.Setup(x => x.ApplicationName).Returns(expectedApplicationName);
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns(expectedEnvironmentName);
		_userServiceMock.Setup(x => x.Domain).Returns(expectedDomainName);
		_userServiceMock.Setup(x => x.Name).Returns(expectedUserName);
		_userServiceMock.Setup(x => x.Machine).Returns(expectedMachineName);

		MainViewModel viewModel = new(_hostEnvironmentMock.Object, _navigationServiceMock.Object, _userServiceMock.Object, _brandEditorViewModel);

		Assert.AreEqual(expectedApplicationName, viewModel.ApplicationName, "ApplicationName should be set correctly.");
		Assert.AreEqual(expectedEnvironmentName, viewModel.EnvironmentName, "EnvironmentName should be set correctly.");
		Assert.AreEqual($"{expectedDomainName}\\{expectedUserName}@{expectedMachineName}", viewModel.CurrentUser, "CurrentUser should be set correctly.");
		Assert.AreEqual(_navigationServiceMock.Object, viewModel.NavigationService, "NavigationService should be set correctly.");
		Assert.AreEqual(_brandEditorViewModel, viewModel.BrandEditor, "BrandEditor should be set correctly.");
		Assert.IsInstanceOfType<ActionCommand>(viewModel.AboutCommand, "AboutCommand should be of type ActionCommand.");
		Assert.IsInstanceOfType<ActionCommand>(viewModel.ExitCommand, "ExitCommand should be of type ActionCommand.");
	}
}
