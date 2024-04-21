using QuantumQuery.Core.DTOs;
using QuantumQuery.Core.Interfaces;
using QuantumQuery.WPF.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace QuantumQuery.WPF.MVVM.ViewModel
{
	public class LeftSideBarModel : ObservableObject
	{
		public ObservableCollection<ElementDto> Elements { get; set; }

		private readonly IElementService _elementService;

		public LeftSideBarModel(IElementService elementService)
		{
			_elementService = elementService ??
				throw new ArgumentNullException(nameof(elementService));
		}

		public async Task InitializeAsync()
		{
			try
			{
				Elements = new ObservableCollection<ElementDto>();

				foreach (var element in await _elementService.GetAllAsync())
				{
					Elements.Add(element);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
