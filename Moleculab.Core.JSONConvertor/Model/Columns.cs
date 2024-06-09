using Newtonsoft.Json;

namespace Moleculab.Core.JSONConvertor.Model;

internal class Columns
{
	[JsonProperty("Column")]
	public List<string>? Column { get; set; }
}
