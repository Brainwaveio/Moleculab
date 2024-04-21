using QuantumQuery.Core.DTOs;
using QuantumQuery.Core.Interfaces;
using QuantumQuery.WPF.Extensions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace QuantumQuery.WPF.MVVM.ViewModel
{
	public class LeftSideBarModel : ObservableObject
	{
		public ObservableCollection<ElementDto> Elements { get; set; } = new ObservableCollection<ElementDto>();
		private readonly IElementService _elementService;

		public LeftSideBarModel(IElementService elementService)
		{
			_elementService = elementService;
		}

		public async Task InitializeAsync()
		{
			try
			{
				var result = await _elementService.GetAllAsync();
				foreach (var element in result)
				{
					Elements.Add(element);
				}
			}
			catch (System.Exception)
			{
				throw;
			}
		}
	}
}
