using Newtonsoft.Json;

namespace QuantumQuery.Core.JSONConvertor.Model
{
	internal class Columns
	{
		[JsonProperty("Column")]
		public List<string>? Column { get; set; }
	}
}
