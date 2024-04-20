using QuantumQuery.Core.DTOs;
using QuantumQuery.WPF.Extensions;
using System.Collections.ObjectModel;

namespace QuantumQuery.WPF.MVVM.ViewModel
{
	internal class LeftSideBarModel : ObservableObject
	{
		public ObservableCollection<ElementDto> Elements { get; set; }

		public LeftSideBarModel() 
		{
		}
	}
}
