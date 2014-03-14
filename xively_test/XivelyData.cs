using System;
using System.Collections.Generic;

namespace xively_test
{
	public class Unit
	{
		public string symbol { get; set; }
		public string label { get; set; }
	}

	public class Datastream
	{
		public string id { get; set; }
		public string current_value { get; set; }
		public string at { get; set; }
		public string max_value { get; set; }
		public string min_value { get; set; }
		public Unit unit { get; set; }
	}

	public class XivelyData
	{
		public int id { get; set; }
		public string title { get; set; }
		public string @private { get; set; }
		public string feed { get; set; }
		public string status { get; set; }
		public string updated { get; set; }
		public string created { get; set; }
		public string creator { get; set; }
		public string version { get; set; }
		public List<Datastream> datastreams { get; set; }
		public string product_id { get; set; }
		public string device_serial { get; set; }
	}
}

