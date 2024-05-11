using Moleculab.Core;

namespace Moleculab.Math.Interfaces.Calculators
{
	public interface IMoleCalculator
	{
		Task<double> CalculateMolesAsync(double mass, Element element);
		double CalculateMolesAsync(double mass, Compound compound);
	}
}
