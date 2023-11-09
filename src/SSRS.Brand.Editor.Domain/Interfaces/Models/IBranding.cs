using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;

public interface IBranding
{
	Colors Colors { get; set; }
	Metadata Metadata { get; set; }
}
