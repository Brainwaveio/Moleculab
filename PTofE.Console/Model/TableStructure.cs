using Newtonsoft.Json;

namespace PTofE.Console.Model
{
	internal class TableStructure
	{
		[JsonProperty("Table")]
		public Table Table { get; set; }
	}
}
