using Newtonsoft.Json;

namespace PTofE.Core.JSONConvertor.Model
{
	internal class Row
	{
		[JsonProperty("Cell")]
		public List<string> Cell { get; set; }
	}
}
