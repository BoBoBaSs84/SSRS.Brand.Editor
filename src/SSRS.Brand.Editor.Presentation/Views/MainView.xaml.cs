using System.Windows;

using SSRS.Brand.Editor.Application.ViewModels;

using ADIH = SSRS.Brand.Editor.Application.Helpers.DependencyInjectionHelper;

namespace SSRS.Brand.Editor.Presentation.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainView : Window
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MainView"/> class.
	/// </summary>
	public MainView()
	{
		DataContext = ADIH.GetService<MainViewModel>();
		InitializeComponent();
	}
}
