using Moleculab.Core;
using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Math.Interfaces.Calculators.GasDensity;

public interface IGasDensityElementCalculator : ICloneable
{
    Task AddDensityOfElementAsync(Element element, int quantity);
    Task<double> GetEqualsAsync(Element element);
    Task<ElementDto> GetElementAsync();
}
