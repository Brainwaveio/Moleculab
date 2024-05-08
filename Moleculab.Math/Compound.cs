using Moleculab.Core.Services;
using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Math
{
    public class Compound : ICloneable
    {
        public int Count => _composition.Count;
        public Dictionary<ElementDto, int>.ValueCollection Values => _composition.Values;

        private Dictionary<ElementDto, int> _composition { get; set; }
        private readonly JSONElementService _jsonElementService;

        public Compound(Dictionary<ElementDto, int> composition)
        {
            _composition = composition;
            _jsonElementService = new JSONElementService();
        }

        public Compound()
        {
            _composition = new Dictionary<ElementDto, int>();
            _jsonElementService = new JSONElementService();
        }

        public async Task Add(Element element, int quantity)
        {
            var jsonElement = await _jsonElementService.GetByShortNameAsync(element.ToString());

            if (_composition.ContainsKey(jsonElement))
            {
                _composition[jsonElement] += quantity;
            }
            else
            {
                _composition.Add(jsonElement, quantity);
                _composition.Remove(jsonElement);
            }
        }

        public async Task<bool> Remove(Element element)
        {
            return _composition.Remove(await _jsonElementService.GetByShortNameAsync(element.ToString()));
        }

        public float CalculateMolecularWeight()
        {
            var totalWeight = default(float);

            foreach (var element in _composition)
            {
                if (element.Key.ShortName != Element.Cl.ToString())
                {
                    totalWeight += (int)System.Math.Round(element.Key.AtomicMass) * element.Value;
                }
                else
                {
                    totalWeight += (float)35.35 * element.Value;
                }
            }

            return totalWeight;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is Compound compound &&
                   EqualityComparer<Dictionary<ElementDto, int>>.Default.Equals(_composition, compound._composition);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
