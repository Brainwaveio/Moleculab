using Moleculab.Core.Extensions;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.Math.Interfaces;
using System.Runtime.CompilerServices;

namespace Moleculab.Math
{
	public class Compound : ICompound
	{
		public int Count => _composition.Count;
		public Dictionary<ElementDto, int>.ValueCollection Values => _composition.Values;

		private Dictionary<ElementDto, int> _composition { get; set; }
		private readonly IElementService _elementService;

		public Compound(Dictionary<ElementDto, int> composition)
		{
			_composition = composition;
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public Compound()
		{
			_composition = new Dictionary<ElementDto, int>();
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public async Task Add(Element element, int quantity)
		{
			var jsonElement = await _elementService.GetByShortNameAsync(element.ToString());

			if (_composition.ContainsKey(jsonElement))
			{
				_composition[jsonElement] += quantity;
			}
			else
			{
				_composition.Add(jsonElement, quantity);
			}
		}

		public async Task Add(Element element)
		{
			var jsonElement = await _elementService.GetByShortNameAsync(element.ToString());

			if (_composition.ContainsKey(jsonElement))
			{
				_composition[jsonElement] += 1;
			}
			else
			{
				_composition.Add(jsonElement, 1);
			}
		}

		public async Task<bool> Remove(Element element)
		{
			return _composition.Remove(await _elementService.GetByShortNameAsync(element.ToString()));
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
			return new Compound(new Dictionary<ElementDto, int>(_composition));
		}

		public override bool Equals(object? obj)
		{
			return obj is Compound compound &&
				   EqualityComparer<Dictionary<ElementDto, int>>.Default.Equals(_composition, compound._composition);
		}

		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this);
		}
	}
}
