using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Presentation.Forms;

namespace SSRS.Brand.Editor.Presentation.Tests.Forms;
[TestClass]
public sealed class MainFormTests
{
	private Mock<IHostEnvironment> _hostEnvironmentMock = default!;
	private Mock<IUserService> _userServiceMock = default!;
	private Mock<INavigationService> _navigationServiceMock = default!;
	private Mock<IServiceProvider> _serviceProviderMock = default!;

	[TestMethod]
	public void ConstructorShouldSetFieldsCorrectly()
	{
		MainViewModel viewModel = GetMainViewModel();
		_navigationServiceMock = new();
		_serviceProviderMock = new();

		using MainForm form = new(_navigationServiceMock.Object, viewModel, _serviceProviderMock.Object);

		Assert.AreEqual($"{viewModel.ApplicationName} - {viewModel.EnvironmentName}", form.Text);
	}

	private MainViewModel GetMainViewModel()
	{
		_hostEnvironmentMock = new();
		_hostEnvironmentMock.Setup(x => x.ApplicationName).Returns("TestApp");
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("TestEnv");
		_userServiceMock = new();
		_userServiceMock.Setup(x => x.Domain).Returns("TestDomain");
		_userServiceMock.Setup(x => x.Name).Returns("TestUser");
		_userServiceMock.Setup(x => x.Machine).Returns("TestMachine");

		MainViewModel viewModel = new(_hostEnvironmentMock.Object, _userServiceMock.Object);
		return viewModel;
	}
}
