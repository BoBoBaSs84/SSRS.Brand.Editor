using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;

public interface ISystemResourcePackage
{
	Contents Contents { get; set; }
	string Name { get; set; }
	string Type { get; set; }
	string Version { get; set; }
}