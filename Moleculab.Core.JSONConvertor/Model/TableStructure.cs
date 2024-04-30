using Newtonsoft.Json;

namespace Moleculab.Core.JSONConvertor.Model
{
	internal class TableStructure
	{
		[JsonProperty("Table")]
		public Table? Table { get; set; }
	}
}
