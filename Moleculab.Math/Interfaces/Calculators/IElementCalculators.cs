using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Math.Interfaces.Calculators
{
	public interface IElementCalculators
	{
		Task<int> CountOfNeutrons(Element element);
		Task<int> CountOfElectrons(Element element);
		Task<int> CountOfProtons(Element element);
	}
}
