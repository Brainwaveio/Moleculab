using Moleculab.Core.Extensions;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.Math.Interfaces.Calculators;

namespace Moleculab.Math.Calculators
{
	public class ElementCalculators : IElementCalculators
	{
		private readonly IElementService _elementService;

		public ElementCalculators()
		{
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public async Task<int> CountOfElectrons(Element element)
		{
			return (int)(await _elementService.GetByShortNameAsync(element.ToString())).Index;
		}

		public async Task<int> CountOfNeutrons(Element element)
		{
			var sqlElement = await _elementService.GetByShortNameAsync(element.ToString());

			if (sqlElement.ShortName != Element.Cl.ToString())
			{
				return (int)(System.Math.Round(sqlElement.AtomicMass) - sqlElement.Index);
			}
			else
			{
				return 18;
			}
		}

		public async Task<int> CountOfProtons(Element element)
		{
			//calls method CountOfElectrons because it is the same code
			return await CountOfElectrons(element);
		}
	}
}
