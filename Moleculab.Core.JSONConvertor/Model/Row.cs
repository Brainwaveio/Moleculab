using Newtonsoft.Json;

namespace Moleculab.Core.JSONConvertor.Model
{
	internal class Row
	{
		[JsonProperty("Cell")]
		public List<string>? Cell { get; set; }
	}
}
