using Moleculab.Core.Services;
using Moleculab.Math.Interfaces.Calculators;

namespace Moleculab.Math.Calculators
{
	public class ElementCalculators : IElementCalculators
	{
		private readonly JSONElementService _jsonElementService;

		public ElementCalculators()
		{
			_jsonElementService = new JSONElementService();
		}

		public async Task<int> CountOfElectrons(Element element)
		{
			var jsonElement = await _jsonElementService.GetByShortNameAsync(element.ToString());
			return (int)jsonElement.Index;
		}

		public async Task<int> CountOfNeutrons(Element element)
		{
			var jsonElement = await _jsonElementService.GetByShortNameAsync(element.ToString());

			if (jsonElement.ShortName != Element.Cl.ToString())
			{
				return (int)(System.Math.Round(jsonElement.AtomicMass) - jsonElement.Index);
			}
			else
			{
				return 18;
			}
		}

		public async Task<int> CountOfProtons(Element element)
		{
			return await CountOfElectrons(element);
		}
	}
}
