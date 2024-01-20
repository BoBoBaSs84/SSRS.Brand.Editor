using SSRS.Brand.Editor.Domain.Exceptions;

namespace SSRS.Brand.Editor.DomainTests.Exceptions;

[TestClass]
public sealed class FileServiceExceptionTests : DomainTestBase
{
	[TestMethod]
	[ExpectedException(typeof(FileServiceException))]
	public void ThrowMessageTest()
		=> FileServiceException.Throw("Something went wrong!");

	[TestMethod]
	[ExpectedException(typeof(FileServiceException))]
	public void ThrowMessageAndExceptionTest()
		=> FileServiceException.Throw("Something went wrong!", new IOException("File not found."));
}
