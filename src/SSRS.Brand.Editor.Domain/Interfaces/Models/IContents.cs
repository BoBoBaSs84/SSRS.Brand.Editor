using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;

public interface IContents
{
	List<Item> Item { get; set; }
}