using BB84.Notifications;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;

namespace SSRS.Brand.Editor.Presentation.Services;
/// <summary>
/// The navigation service class.
/// </summary>
internal sealed class NavigationService : NotifiableObject, INavigationService
{
	private readonly Func<Type, Form> _formFactory;
	private Form? _currentForm;

	/// <summary>
	/// Initializes a new instance of the <see cref="NavigationService"/> class.
	/// </summary>
	/// <param name="formFactory">The function for creating a specific form.</param>
	public NavigationService(Func<Type, Form> formFactory)
	{
		_formFactory = formFactory;

		PropertyChanging += (s, e) => OnCurrentFormChanging();
		PropertyChanged += (s, e) => OnCurrentFormChanged();
	}

	public Form? CurrentForm
	{
		get => _currentForm;
		private set => SetProperty(ref _currentForm, value);
	}

	public void NavigateTo<T>() where T : Form
	{
		Form form = _formFactory.Invoke(typeof(T));
		form.TopLevel = false;
		form.Dock = DockStyle.Fill;
		form.FormBorderStyle = FormBorderStyle.None;
		CurrentForm = form;
	}

	private void OnCurrentFormChanged()
	{
		if (CurrentForm is not null)
			CurrentForm.Visible = true;
	}

	private void OnCurrentFormChanging()
	{
		if (CurrentForm is not null)
			CurrentForm.Visible = false;
	}
}
