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

		private Dictionary<ElementDto, int> _composition;
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

		/// <summary>
		/// use this method if you want add some element
		/// </summary>
		/// <param name="element"></param>
		/// <param name="quantity"></param>
		/// <returns></returns>
		public async Task Add(Element element, int quantity)
		{
			try
			{
				var sqlElement = await _elementService.GetByShortNameAsync(element.ToString());
				if (_composition.ContainsKey(sqlElement))
				{
					_composition[sqlElement] += quantity;
				}
				else
				{
					_composition.Add(sqlElement, quantity);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// use this method if you want add only one element
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public async Task Add(Element element)
		{
			try
			{
				var sqlElement = await _elementService.GetByShortNameAsync(element.ToString());
				if (_composition.ContainsKey(sqlElement))
				{
					_composition[sqlElement] += 1;
				}
				else
				{
					_composition.Add(sqlElement, 1);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// This method removes the element completely
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
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
