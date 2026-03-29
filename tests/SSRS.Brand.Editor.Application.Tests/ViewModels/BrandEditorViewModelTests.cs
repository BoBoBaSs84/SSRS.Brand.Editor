using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class BrandEditorViewModelTests : ApplicationTestBase
{
	private readonly Mock<IBrandPackageService> _brandPackageServiceMock = new();
	private readonly Mock<IFileDialogService> _fileDialogServiceMock = new();
	private readonly Mock<IFileProvider> _fileProviderMock = new();
	private readonly Mock<INotificationService> _notificationServiceMock = new();
	private readonly Mock<ILoggerService<BrandEditorViewModel>> _loggerServiceMock = new();

	private BrandEditorViewModel CreateViewModel()
		=> new(_brandPackageServiceMock.Object, _fileDialogServiceMock.Object, _fileProviderMock.Object, _notificationServiceMock.Object, _loggerServiceMock.Object);

	[TestMethod]
	public void ConstructorShouldHaveNoPackageLoaded()
	{
		BrandEditorViewModel viewModel = CreateViewModel();

		Assert.IsFalse(viewModel.HasPackage);
		Assert.IsNull(viewModel.Model);
		Assert.IsNull(viewModel.CurrentFilePath);
		Assert.IsNull(viewModel.MetadataViewModel);
		Assert.IsNull(viewModel.InterfaceColorsViewModel);
		Assert.IsNull(viewModel.ThemeColorsViewModel);
		Assert.IsNull(viewModel.LogoViewModel);
	}

	[TestMethod]
	public void NewCommandShouldCreateNewPackage()
	{
		BrandEditorViewModel viewModel = CreateViewModel();

		viewModel.NewCommand.Execute(null);

		Assert.IsTrue(viewModel.HasPackage);
		Assert.IsNotNull(viewModel.Model);
		Assert.AreEqual("New Brand", viewModel.Model.Metadata.Name);
		Assert.IsNull(viewModel.CurrentFilePath);
		Assert.IsNotNull(viewModel.MetadataViewModel);
		Assert.IsNotNull(viewModel.InterfaceColorsViewModel);
		Assert.IsNotNull(viewModel.ThemeColorsViewModel);
		Assert.IsNotNull(viewModel.LogoViewModel);
	}

	[TestMethod]
	public void CloseCommandShouldClearPackage()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);

		Assert.IsTrue(viewModel.HasPackage);

		viewModel.CloseCommand.Execute(null);

		Assert.IsFalse(viewModel.HasPackage);
		Assert.IsNull(viewModel.Model);
		Assert.IsNull(viewModel.CurrentFilePath);
		Assert.IsNull(viewModel.MetadataViewModel);
		Assert.IsNull(viewModel.InterfaceColorsViewModel);
		Assert.IsNull(viewModel.ThemeColorsViewModel);
		Assert.IsNull(viewModel.LogoViewModel);
	}

	[TestMethod]
	public async Task OpenCommandShouldLoadPackageFromFile()
	{
		BrandPackageModel expectedModel = new();
		expectedModel.Metadata.Name = "Loaded Brand";
		_fileDialogServiceMock.Setup(x => x.ShowOpenFileDialog(It.IsAny<string>(), It.IsAny<string>()))
			.Returns("test.zip");
		_brandPackageServiceMock.Setup(x => x.ReadAsync("test.zip", It.IsAny<CancellationToken>()))
			.ReturnsAsync(expectedModel);
		BrandEditorViewModel viewModel = CreateViewModel();

		await viewModel.OpenCommand.ExecuteAsync();

		Assert.IsTrue(viewModel.HasPackage);
		Assert.AreEqual("Loaded Brand", viewModel.Model!.Metadata.Name);
		Assert.AreEqual("test.zip", viewModel.CurrentFilePath);
	}

	[TestMethod]
	public async Task OpenCommandShouldDoNothingWhenDialogCancelled()
	{
		_fileDialogServiceMock.Setup(x => x.ShowOpenFileDialog(It.IsAny<string>(), It.IsAny<string>()))
			.Returns((string?)null);
		BrandEditorViewModel viewModel = CreateViewModel();

		await viewModel.OpenCommand.ExecuteAsync();

		Assert.IsFalse(viewModel.HasPackage);
		_brandPackageServiceMock.Verify(x => x.ReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
	}

	[TestMethod]
	public async Task SaveCommandShouldDelegateSaveAsWhenNoFilePath()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		_fileDialogServiceMock.Setup(x => x.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
			.Returns("new-brand.zip");

		await viewModel.SaveCommand.ExecuteAsync();

		_brandPackageServiceMock.Verify(x => x.WriteAsync("new-brand.zip", viewModel.Model!, It.IsAny<CancellationToken>()), Times.Once);
		Assert.AreEqual("new-brand.zip", viewModel.CurrentFilePath);
	}

	[TestMethod]
	public async Task SaveAsCommandShouldWriteToSelectedPath()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		_fileDialogServiceMock.Setup(x => x.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
			.Returns("saved.zip");

		await viewModel.SaveAsCommand.ExecuteAsync();

		_brandPackageServiceMock.Verify(x => x.WriteAsync("saved.zip", viewModel.Model!, It.IsAny<CancellationToken>()), Times.Once);
		Assert.AreEqual("saved.zip", viewModel.CurrentFilePath);
	}

	[TestMethod]
	public async Task SaveAsCommandShouldDoNothingWhenDialogCancelled()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		_fileDialogServiceMock.Setup(x => x.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
			.Returns((string?)null);

		await viewModel.SaveAsCommand.ExecuteAsync();

		_brandPackageServiceMock.Verify(x => x.WriteAsync(It.IsAny<string>(), It.IsAny<BrandPackageModel>(), It.IsAny<CancellationToken>()), Times.Never);
	}

	[TestMethod]
	public void NewCommandShouldRaisePropertyChangedForHasPackage()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		List<string> changedProperties = [];
		viewModel.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		viewModel.NewCommand.Execute(null);

		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.HasPackage)));
		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.Model)));
		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.MetadataViewModel)));
		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.InterfaceColorsViewModel)));
		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.ThemeColorsViewModel)));
		Assert.IsTrue(changedProperties.Contains(nameof(BrandEditorViewModel.LogoViewModel)));
	}
}
