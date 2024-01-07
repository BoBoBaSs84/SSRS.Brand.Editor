using System.Text;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Domain.Exceptions;
using SSRS.Brand.Editor.Infrastructure.Helpers;

namespace SSRS.Brand.Editor.InfrastructureTests.Services;

[TestClass]
public sealed class FileServiceTests : InfrastructureTestBase
{
	private static readonly string TestFileContent = "UnitTest";
	private static readonly string TestFileName = "TestFile.txt";
	private static readonly string TestFileFolder = AppContext.BaseDirectory;

	private readonly IFileService _fileService;

	public FileServiceTests()
		=> _fileService = DependencyInjectionHelper.GetService<IFileService>();

	[TestMethod]
	public void LoadTest()
	{
		byte[] expected = Encoding.UTF8.GetBytes(TestFileContent);

		byte[] content = _fileService.Load(TestFileFolder, TestFileName);

		Assert.IsTrue(content.SequenceEqual(expected));
	}

	[TestMethod]
	public void LoadExceptionTest()
		=> Assert.ThrowsException<FileServiceException>(() => _fileService.Load(string.Empty));

	[TestMethod]
	public void SaveTest()
	{
		byte[] content = Encoding.UTF8.GetBytes(TestFileContent);

		bool success = _fileService.Save(TestFileFolder, TestFileName, content);

		Assert.IsTrue(success);
	}

	[TestMethod]
	public void SaveExceptionTest()
		=> Assert.ThrowsException<FileServiceException>(() => _fileService.Save(string.Empty, []));
}
