using QuantumQuery.WPF.Extensions;

namespace QuantumQuery.WPF.MVVM.ViewModel
{
	internal class MainWindowModel : ObservableObject
	{
		public RelayCommand ShowLeftSideBar;

		public LeftSideBarModel LeftSideBarVM { get; set; }

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}

		public MainWindowModel()
		{ 
			LeftSideBarVM = new LeftSideBarModel();
			CurrentView = LeftSideBarVM;
		}
	}
}
	