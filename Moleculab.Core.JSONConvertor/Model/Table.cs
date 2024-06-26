﻿using Newtonsoft.Json;

namespace Moleculab.Core.JSONConvertor.Model;

internal class Table
{
	[JsonProperty("Columns")]
	public Columns? Columns { get; set; }
	[JsonProperty("Row")]
	public List<Row>? Row { get; set; }
}
