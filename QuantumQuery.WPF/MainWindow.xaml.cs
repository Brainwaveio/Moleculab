using QuantumQuery.WPF.ViewModel;
using System.Windows;

namespace QuantumQuery.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			DataContext = new MainWindowModel();
			InitializeComponent();
		}
	}
}
