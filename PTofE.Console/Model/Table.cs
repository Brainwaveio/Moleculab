using Newtonsoft.Json;

namespace PTofE.Console.Model
{
	internal class Table
	{
		[JsonProperty("Columns")]
		public Columns Columns { get; set; }
		[JsonProperty("Row")]
		public List<Row> Row { get; set; }
	}
}
