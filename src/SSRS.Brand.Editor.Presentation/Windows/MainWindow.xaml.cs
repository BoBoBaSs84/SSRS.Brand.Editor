using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Presentation.Windows;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly MainViewModel _mainViewModel;

	public MainWindow()
	{
		_mainViewModel = new();
		DataContext = _mainViewModel;

		InitializeComponent();
	}
}
