using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;

public interface IColors
{
	Interface Interface { get; set; }
	string Name { get; set; }
	Theme Theme { get; set; }
	string Version { get; set; }
}