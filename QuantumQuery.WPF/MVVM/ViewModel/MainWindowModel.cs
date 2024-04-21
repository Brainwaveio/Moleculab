using QuantumQuery.WPF.Extensions;
using System;

namespace QuantumQuery.WPF.MVVM.ViewModel
{
	public class MainWindowModel : ObservableObject
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

		public MainWindowModel(LeftSideBarModel leftSideBarVM)
		{ 
			LeftSideBarVM = leftSideBarVM ?? throw new ArgumentNullException(nameof(leftSideBarVM));
			CurrentView = LeftSideBarVM;
		}
	}
}
	