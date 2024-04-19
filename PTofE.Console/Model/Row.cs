using Newtonsoft.Json;

namespace PTofE.Console.Model
{
	internal class Row
	{
		[JsonProperty("Cell")]
		public List<string> Cell { get; set; }
	}
}
