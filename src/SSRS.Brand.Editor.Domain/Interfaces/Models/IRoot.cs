namespace SSRS.Brand.Editor.Domain.Models;

public interface IRoot
{
	Interface Interface { get; set; }
	string Name { get; set; }
	Theme Theme { get; set; }
	string Version { get; set; }
}