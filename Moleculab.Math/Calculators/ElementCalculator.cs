using Moleculab.Core;
using Moleculab.Core.Extensions;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.Math.Interfaces.Calculators;

namespace Moleculab.Math.Calculators;

public class ElementCalculator : IElementCalculators
{
	private readonly IElementService _elementService;

	public ElementCalculator()
	{
		_elementService = ServiceLocator.GetService<IElementService>();
	}

	public async Task<int> CountOfElectrons(Element element)
	{
		return (int)(await _elementService.GetByShortNameAsync(element)).Index;
	}

	public async Task<int> CountOfNeutrons(Element element)
	{
		ElementDto sqlElement = await _elementService.GetByShortNameAsync(element);

		if (sqlElement.ShortName != Element.Cl)
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
