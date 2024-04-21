using QuantumQuery.WPF.MVVM.ViewModel;
using System.Windows;

namespace QuantumQuery.WPF.MVVM.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(MainWindowModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}
	}
}
