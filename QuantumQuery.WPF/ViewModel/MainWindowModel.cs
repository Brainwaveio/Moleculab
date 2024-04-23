using QuantumQuery.WPF.Extensions;
using System.Collections.ObjectModel;
using System.Windows;

namespace QuantumQuery.WPF.ViewModel
{
	internal class MainWindowModel : BaseViewModel
	{
		//TODO delete in PROD this text code
		private string? _boundText;

		public string? BoundText
		{
			get { return _boundText; }
			set
			{
				_boundText = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<string> _entries;

		public ObservableCollection<string> Entries
		{
			get { return _entries; }
			set
			{
				_entries = value;
				OnPropertyChanged();
			}
		}

		public MainWindowModel()
		{
			_entries = new ObservableCollection<string>();
		}

		private void ButtonTest(object sender, RoutedEventArgs e)
		{
			BoundText = "set";
			Entries.Add("jhbgv");
		}
	}
}
