using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass, ExcludeFromCodeCoverage]
public class MetadataTests
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
	private readonly string _fileName = "metadata.xml";
	private readonly string _xmlContent;

	public MetadataTests()
		=> _xmlContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

	[TestMethod]
	public void MetadataToXmlTest()
	{
		Metadata metadata = new();

		string xmlString = metadata.ToXml();

		Assert.IsFalse(string.IsNullOrWhiteSpace(xmlString));
	}

	[TestMethod]
	public void MetadataFromXmlTest()
	{
		Metadata metadata;

		metadata = _xmlContent.FromXml<Metadata>();

		Assert.IsFalse(string.IsNullOrWhiteSpace(metadata.Name));
	}
}
