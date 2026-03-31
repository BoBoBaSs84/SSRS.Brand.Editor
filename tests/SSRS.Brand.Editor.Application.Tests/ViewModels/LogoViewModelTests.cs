// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class LogoViewModelTests : ApplicationTestBase
{
	private readonly Mock<IFileDialogService> _fileDialogServiceMock = new();
	private readonly Mock<IFileProvider> _fileProviderMock = new();
	private readonly Mock<INotificationService> _notificationServiceMock = new();

	private LogoViewModel CreateViewModel(BrandPackageModel? model = null)
		=> new(model ?? new BrandPackageModel(), _fileDialogServiceMock.Object, _fileProviderMock.Object, _notificationServiceMock.Object);

	[TestMethod]
	public void ConstructorShouldSetInitialState()
	{
		LogoViewModel viewModel = CreateViewModel();

		Assert.IsFalse(viewModel.HasLogo);
		Assert.IsNull(viewModel.LogoBytes);
	}

	[TestMethod]
	public void BrowseCommandShouldLoadValidPng()
	{
		byte[] pngBytes = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x01, 0x02, 0x03];
		_fileDialogServiceMock.Setup(x => x.ShowOpenImageDialog()).Returns("test.png");
		_fileProviderMock.Setup(x => x.ReadAllBytes("test.png")).Returns(pngBytes);
		LogoViewModel viewModel = CreateViewModel();

		viewModel.BrowseCommand.Execute(null);

		Assert.IsTrue(viewModel.HasLogo);
		CollectionAssert.AreEqual(pngBytes, viewModel.LogoBytes);
	}

	[TestMethod]
	public void BrowseCommandShouldRejectInvalidFile()
	{
		byte[] invalidBytes = [0x00, 0x01, 0x02, 0x03];
		_fileDialogServiceMock.Setup(x => x.ShowOpenImageDialog()).Returns("test.bmp");
		_fileProviderMock.Setup(x => x.ReadAllBytes("test.bmp")).Returns(invalidBytes);
		LogoViewModel viewModel = CreateViewModel();

		viewModel.BrowseCommand.Execute(null);

		Assert.IsFalse(viewModel.HasLogo);
		_notificationServiceMock.Verify(x => x.ShowError(It.IsAny<string>()), Times.Once);
	}

	[TestMethod]
	public void BrowseCommandShouldDoNothingWhenDialogCancelled()
	{
		_fileDialogServiceMock.Setup(x => x.ShowOpenImageDialog()).Returns((string?)null);
		LogoViewModel viewModel = CreateViewModel();

		viewModel.BrowseCommand.Execute(null);

		Assert.IsFalse(viewModel.HasLogo);
		_fileProviderMock.Verify(x => x.ReadAllBytes(It.IsAny<string>()), Times.Never);
	}

	[TestMethod]
	public void RemoveCommandShouldClearLogo()
	{
		BrandPackageModel model = new()
		{
			Logo = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A]
		};
		LogoViewModel viewModel = CreateViewModel(model);

		Assert.IsTrue(viewModel.HasLogo);

		viewModel.RemoveCommand.Execute(null);

		Assert.IsFalse(viewModel.HasLogo);
		Assert.IsNull(viewModel.LogoBytes);
	}

	[TestMethod]
	public void RemoveCommandShouldRaisePropertyChanged()
	{
		BrandPackageModel model = new()
		{
			Logo = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A]
		};
		LogoViewModel viewModel = CreateViewModel(model);
		List<string> changedProperties = [];
		viewModel.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		viewModel.RemoveCommand.Execute(null);

		Assert.Contains(nameof(LogoViewModel.HasLogo), changedProperties);
		Assert.Contains(nameof(LogoViewModel.LogoBytes), changedProperties);
	}
}
