namespace QuantumQuery.Core.DTOs
{
	public class ElementDto
	{
		public required Guid Id { get; set; }
		public required int Index { get; set; }
		public required string ShortName { get; set; }
		public required string ElementName { get; set; }
		public required float AtomicMass { get; set; }
		public required string CPKHexColor { get; set; }
		public ElemntState? StandardState { get; set; }
		public string? ElectronConfiguration { get; set; }
		public string? OxidationStates { get; set; }
		public float? Electronegativity { get; set; }
		public int? AtomicRadius { get; set; }	
		public float? IonizationEnergy { get; set; }
		public float? ElectronAffinity { get; set; }
		public float? MeltingPoint { get; set; }
		public float? BoilingPoint { get; set; }
		public float? Density { get; set; }
		public required string GroupBlock { get; set; }
		public string? YearDiscovered { get; set; }
	}
}
