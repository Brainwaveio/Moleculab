using Newtonsoft.Json;

namespace PTofE.Console.Model
{
	internal class Columns
	{
		[JsonProperty("Column")]
		public List<string> Column { get; set; }
	}
}
