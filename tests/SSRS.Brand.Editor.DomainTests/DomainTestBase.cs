namespace SSRS.Brand.Editor.Domain.Tests;

[TestClass]
public abstract class DomainTestBase
{
	private static TestContext? s_context;

	[AssemblyInitialize]
	public static void AssemblyInitialize(TestContext context)
		=> s_context = context;

	[TestInitialize]
	public void TestInitialize()
		=> s_context?.WriteLine($"Initialize {s_context.TestName} ..");

	[TestCleanup]
	public void TestCleanup()
		=> s_context?.WriteLine($"Cleanup {s_context.TestName} ..");
}
