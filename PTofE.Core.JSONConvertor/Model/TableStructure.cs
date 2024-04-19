using Newtonsoft.Json;

namespace PTofE.Core.JSONConvertor.Model
{
	internal class TableStructure
	{
		[JsonProperty("Table")]
		public Table Table { get; set; }
	}
}
