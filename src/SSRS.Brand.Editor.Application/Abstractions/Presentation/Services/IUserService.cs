namespace SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

/// <summary>
/// The interface for the user service.
/// </summary>
public interface IUserService
{
	/// <summary>
	/// The user name.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// The user domain name.
	/// </summary>
	string Domain { get; }

	/// <summary>
	/// The user machine name.
	/// </summary>
	string Machine { get; }
}
