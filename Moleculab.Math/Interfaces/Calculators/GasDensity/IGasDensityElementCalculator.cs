using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Math.Interfaces.Calculators.GasDensity
{
    public interface IGasDensityElementCalculator
    {
        Task AddDensityOfElementAsync(Element element, int quantity);
        Task<float> GetEqualsAsync(Element element);
        Task<ElementDto> GetElementAsync();
    }
}
