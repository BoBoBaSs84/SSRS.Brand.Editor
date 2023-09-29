using System.Text;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Domain.Exceptions;

namespace SSRS.Brand.Editor.InfrastructureTests.Services;

[TestClass]
public class FileServiceTests : InfrastructureTestBase
{
	private static readonly string TestFileName = "TestFile.txt";
	private static readonly string TestFileFolder = AppContext.BaseDirectory;

	private readonly IFileService _fileService;

	public FileServiceTests()
		=> _fileService = GetService<IFileService>();

	[TestMethod]
	public void LoadTest()
	{
		string filePath = Path.Combine(TestFileFolder, TestFileName);

		byte[] content = _fileService.Load(filePath);

		Assert.IsNotNull(content);
	}

	[TestMethod]
	public void LoadExceptionTest()
	{
		_ = Assert.ThrowsException<FileServiceException>(() => _fileService.Load(string.Empty));
	}

	[TestMethod]
	public void SaveTest()
	{
		byte[] content = Encoding.UTF8.GetBytes("UnitTest");
		string filePath = Path.Combine(TestFileFolder, TestFileName);

		bool success = _fileService.Save(filePath, content);

		Assert.IsTrue(success);
	}

	[TestMethod]
	public void SaveExceptionTest()
	{
		_ = Assert.ThrowsException<FileServiceException>(() => _fileService.Save(string.Empty, Array.Empty<byte>()));
	}
}
