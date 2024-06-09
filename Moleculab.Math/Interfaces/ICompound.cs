using Moleculab.Core;

namespace Moleculab.Math.Interfaces;

public interface ICompound : ICloneable
{
    Task Add(Element element, int quantity);
	Task Add(Element element);
	Task<bool> Remove(Element element);
}
