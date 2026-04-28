// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;
using System.Windows;

using Moq;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;
using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
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
	private readonly Mock<IProviderService> _providerServiceMock = new();
	private readonly Mock<INavigationService> _navigationServiceMock = new();
	private readonly Mock<INotificationService> _notificationServiceMock = new();
	private readonly Mock<ILoggerService<BrandEditorViewModel>> _loggerServiceMock = new();

	private BrandEditorViewModel CreateViewModel()
	{
		Mock<IFileProvider> fileProviderMock = new();
		_providerServiceMock.Setup(x => x.File)
			.Returns(fileProviderMock.Object);

		return new(_brandPackageServiceMock.Object, _fileDialogServiceMock.Object, _providerServiceMock.Object, _navigationServiceMock.Object, _notificationServiceMock.Object, _loggerServiceMock.Object);
	}

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
		_navigationServiceMock.Verify(x => x.NavigateTo<BrandEditorViewModel>(), Times.Once);
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
		_navigationServiceMock.Verify(x => x.NavigateTo<BrandEditorViewModel>(), Times.Once);
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

		Assert.Contains(nameof(BrandEditorViewModel.HasPackage), changedProperties);
		Assert.Contains(nameof(BrandEditorViewModel.Model), changedProperties);
		Assert.Contains(nameof(BrandEditorViewModel.MetadataViewModel), changedProperties);
		Assert.Contains(nameof(BrandEditorViewModel.InterfaceColorsViewModel), changedProperties);
		Assert.Contains(nameof(BrandEditorViewModel.ThemeColorsViewModel), changedProperties);
		Assert.Contains(nameof(BrandEditorViewModel.LogoViewModel), changedProperties);
	}

	[TestMethod]
	public void NewCommandShouldPopulateDefaultColors()
	{
		BrandEditorViewModel viewModel = CreateViewModel();

		viewModel.NewCommand.Execute(null);

		Assert.IsNotNull(viewModel.Model);
		Assert.AreNotEqual(Color.Empty, viewModel.Model.ColorScheme.Interface.Primary);
		Assert.AreNotEqual(Color.Empty, viewModel.Model.ColorScheme.Interface.Secondary);
		Assert.AreNotEqual(Color.Empty, viewModel.Model.ColorScheme.Interface.NeutralPrimary);
		Assert.AreNotEqual(Color.Empty, viewModel.Model.ColorScheme.Theme.Good);
		Assert.AreNotEqual(Color.Empty, viewModel.Model.ColorScheme.Theme.Bad);
		Assert.IsNotEmpty(viewModel.Model.ColorScheme.Theme.DataPoints);
	}

	[TestMethod]
	public void NewCommandShouldNotBeDirty()
	{
		BrandEditorViewModel viewModel = CreateViewModel();

		viewModel.NewCommand.Execute(null);

		Assert.IsFalse(viewModel.IsDirty);
	}

	[TestMethod]
	public void IsDirtyShouldBeTrueAfterModelPropertyChange()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);

		Assert.IsFalse(viewModel.IsDirty);

		viewModel.Model!.Metadata.Name = "Changed Name";

		Assert.IsTrue(viewModel.IsDirty);
	}

	[TestMethod]
	public async Task SaveCommandShouldClearIsDirty()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		viewModel.Model!.Metadata.Name = "Changed";
		_fileDialogServiceMock.Setup(x => x.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
			.Returns("test.zip");

		Assert.IsTrue(viewModel.IsDirty);

		await viewModel.SaveCommand.ExecuteAsync();

		Assert.IsFalse(viewModel.IsDirty);
	}

	[TestMethod]
	public void CloseCommandShouldPromptWhenDirty()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		viewModel.Model!.Metadata.Name = "Changed";
		_notificationServiceMock.Setup(x => x.ShowQuestion(It.IsAny<string>()))
			.Returns(MessageBoxResult.No);

		Assert.IsTrue(viewModel.IsDirty);

		viewModel.CloseCommand.Execute(null);

		Assert.IsTrue(viewModel.HasPackage, "Package should still be loaded when user declines.");
		_notificationServiceMock.Verify(x => x.ShowQuestion(It.IsAny<string>()), Times.Once);
	}

	[TestMethod]
	public void CloseCommandShouldCloseWhenDirtyAndUserConfirms()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		viewModel.Model!.Metadata.Name = "Changed";
		_notificationServiceMock.Setup(x => x.ShowQuestion(It.IsAny<string>()))
			.Returns(MessageBoxResult.Yes);

		viewModel.CloseCommand.Execute(null);

		Assert.IsFalse(viewModel.HasPackage);
	}

	[TestMethod]
	public void NewCommandShouldPromptWhenCurrentPackageIsDirty()
	{
		BrandEditorViewModel viewModel = CreateViewModel();
		viewModel.NewCommand.Execute(null);
		viewModel.Model!.Metadata.Name = "Changed";
		_notificationServiceMock.Setup(x => x.ShowQuestion(It.IsAny<string>()))
			.Returns(MessageBoxResult.No);

		string? originalName = viewModel.Model.Metadata.Name;
		viewModel.NewCommand.Execute(null);

		Assert.AreEqual(originalName, viewModel.Model!.Metadata.Name, "Model should remain unchanged when user declines.");
	}
}
