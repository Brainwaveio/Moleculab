using PTofE.Core.DTOs;
using PTofE.WPF.Extensions;
using System.Collections.ObjectModel;

namespace PTofE.WPF.MVVM.ViewModel
{
	internal class LeftSideBarModel : ObservableObject
	{
		public ObservableCollection<ElementDto> Elements { get; set; }

		public LeftSideBarModel() 
		{
		}
	}
}
