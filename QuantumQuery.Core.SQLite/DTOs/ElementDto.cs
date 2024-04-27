namespace QuantumQuery.Core.SQLite.DTOs
{
	public class ElementDto
	{
		public Guid? Id { get; set; }
		public required long Index { get; set; }
		public required string ShortName { get; set; }
		public required string ElementName { get; set; }
		public required double AtomicMass { get; set; }
		public required string CPKHexColor { get; set; }
		public ElemntState? StandardState { get; set; }
		public string? ElectronConfiguration { get; set; }
		public string? OxidationStates { get; set; }
		public double? Electronegativity { get; set; }
		public long? AtomicRadius { get; set; }	
		public double? IonizationEnergy { get; set; }
		public double? ElectronAffinity { get; set; }
		public double? MeltingPoint { get; set; }
		public double? BoilingPoint { get; set; }
		public double? Density { get; set; }
		public required string GroupBlock { get; set; }
		public string? YearDiscovered { get; set; }
	}
}
