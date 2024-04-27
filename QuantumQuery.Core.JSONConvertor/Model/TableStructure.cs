using Newtonsoft.Json;

namespace QuantumQuery.Core.JSONConvertor.Model
{
	internal class TableStructure
	{
		[JsonProperty("Table")]
		public Table? Table { get; set; }
	}
}
