using Newtonsoft.Json;

namespace PTofE.Core.JSONConvertor.Model
{
	internal class Columns
	{
		[JsonProperty("Column")]
		public List<string> Column { get; set; }
	}
}
