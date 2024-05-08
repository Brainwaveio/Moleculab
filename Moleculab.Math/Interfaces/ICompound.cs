namespace Moleculab.Math.Interfaces
{
    public interface ICompound : ICloneable
    {
        Task Add(Element element);
        Task<bool> Remove(Element element);
    }
}
