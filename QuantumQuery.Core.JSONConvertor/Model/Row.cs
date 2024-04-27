using Newtonsoft.Json;

namespace QuantumQuery.Core.JSONConvertor.Model
{
	internal class Row
	{
		[JsonProperty("Cell")]
		public List<string>? Cell { get; set; }
	}
}
