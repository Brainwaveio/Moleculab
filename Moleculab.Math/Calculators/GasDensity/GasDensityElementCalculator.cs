using Moleculab.Core.Extensions;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.Math.Interfaces.Calculators.GasDensity;
using System.Runtime.CompilerServices;

namespace Moleculab.Math.Calculators.GasDensity
{
	public class GasDensityElementCalculator : IGasDensityElementCalculator
	{
		private readonly IElementService _elementService;

		private ElementDto _element;
		private int _quantity;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public GasDensityElementCalculator()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public GasDensityElementCalculator(ElementDto element, int quantity)
		{
			_element = element;
			_quantity = quantity;
			_elementService = ServiceLocator.GetService<IElementService>();
		}

		public async Task AddDensityOfElementAsync(Element element, int quantity)
		{
			try
			{
				var sqlElement = await _elementService.GetByShortNameAsync(element.ToString());

				_element = sqlElement;
				_quantity = quantity;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}

		public async Task<float> GetEqualsAsync(Element element)
		{
			try
			{
				var sqlElement = await _elementService.GetByShortNameAsync(element.ToString());
				var atomicMassOfDelement = float.NaN;

				if (_element.ShortName == Element.Cl.ToString())
				{
					atomicMassOfDelement = (float)35.35 * _quantity;
				}
				else
				{
					atomicMassOfDelement = (int)System.Math.Round(_element.AtomicMass) * _quantity;
				}

				return (float)System.Math.Round(sqlElement.AtomicMass) / atomicMassOfDelement;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}

		public async Task<ElementDto> GetElementAsync()
		{
			try
			{
				var atomicMassOfElement = float.NaN;

				if (_element.ShortName == Element.Cl.ToString())
				{
					atomicMassOfElement = (float)35.35 * _quantity;
				}
				else
				{
					atomicMassOfElement = (int)System.Math.Round(_element.AtomicMass) * _quantity;
				}

				return await _elementService.GetByAtomicMassAsync((int)atomicMassOfElement);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}

		public object Clone()
		{
			return new GasDensityElementCalculator(_element, _quantity);
		}

		public override bool Equals(object? obj)
		{
			if (obj == null || obj.GetType() != GetType())
			{
				return false;
			}

			var other = obj as GasDensityElementCalculator;
			return _element.Equals(other?._element) && _quantity == other._quantity;
		}

		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this);
		}
	}
}
