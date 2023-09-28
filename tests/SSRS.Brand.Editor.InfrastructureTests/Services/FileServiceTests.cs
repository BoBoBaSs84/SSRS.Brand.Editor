using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Domain.Exceptions;

namespace SSRS.Brand.Editor.InfrastructureTests.Services;

[TestClass]
public class FileServiceTests : InfrastructureTestBase
{
	private readonly IFileService _fileService;

	public FileServiceTests()
		=> _fileService = GetService<IFileService>();

	[TestMethod]
	public void LoadTest()
	{
		Assert.Fail();
	}

	[TestMethod]
	public void LoadExceptionTest()
	{
		Assert.ThrowsException<FileServiceException>(() => _fileService.Load(string.Empty));
	}

	[TestMethod]
	public void SaveTest()
	{
		Assert.Fail();
	}

	[TestMethod]
	public void SaveExceptionTest()
	{
		Assert.ThrowsException<FileServiceException>(() => _fileService.Save(string.Empty, Array.Empty<byte>()));
	}
}
