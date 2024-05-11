using Moleculab.Core;
using Moleculab.Core.Extensions;
using Moleculab.Core.SQLite.Interfaces;

namespace Moleculab.Math.Calculators
{
	public class MoleCalculator
	{
		private readonly IElementService _elementService;

		public MoleCalculator()
		{
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public async Task<double> CalculateMolesAsync(double mass, Element element)
		{
			var sqlElement = await _elementService.GetByShortNameAsync(element);

			if (element == Element.Cl)
			{
				return mass / 35.35;
			}

			return mass / System.Math.Round(sqlElement.AtomicMass);
		}

		public static double CalculateMolesAsync(double mass, Compound compound)
		{
			return mass / compound.CalculateMolecularWeight();
		}
	}
}
