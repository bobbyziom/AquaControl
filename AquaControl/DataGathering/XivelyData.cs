using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace AquaControl
{
	public class XivelyData
	{

		public class Datastream
		{
			public string id { get; set; }
			public string current_value { get; set; }
			public string at { get; set; }
			public string max_value { get; set; }
			public string min_value { get; set; }
			public List<string> tags { get; set; }
			public List<Datapoint> datapoints { get; set; }
		}

		public class Location
		{
			public string disposition { get; set; }
			public string domain { get; set; }
			public double lat { get; set; }
			public double lon { get; set; }
		}

		public class Datapoint
		{
			public string value { get; set; }
			public string at { get; set; }
		}
			
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string title { get; set; }

		/// <summary>
		/// Gets or sets the private.
		/// </summary>
		/// <value>The private.</value>
		public string @private { get; set; }

		/// <summary>
		/// Gets or sets the feed.
		/// </summary>
		/// <value>The feed.</value>
		public string feed { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string status { get; set; }

		/// <summary>
		/// Gets or sets the updated.
		/// </summary>
		/// <value>The updated.</value>
		public string updated { get; set; }

		/// <summary>
		/// Gets or sets the created.
		/// </summary>
		/// <value>The created.</value>
		public string created { get; set; }

		/// <summary>
		/// Gets or sets the creator.
		/// </summary>
		/// <value>The creator.</value>
		public string creator { get; set; }

		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		/// <value>The version.</value>
		public string version { get; set; }

		/// <summary>
		/// Gets or sets the datastreams.
		/// </summary>
		/// <value>The datastreams.</value>
		public List<Datastream> datastreams { get; set; }

		/// <summary>
		/// Gets or sets the product_id.
		/// </summary>
		/// <value>The product_id.</value>
		public string product_id { get; set; }

		/// <summary>
		/// Gets or sets the device_serial.
		/// </summary>
		/// <value>The device_serial.</value>
		public string device_serial { get; set; }



		/// <summary>
		/// Gets the current data.
		/// Example:
		/// XivelyData data = XivelyData.GetCurrentData (apiKey, feedId);
		/// </summary>
		/// <returns>The current data.</returns>
		/// <param name="xivelyDataApiKey">Xively data API key.</param>
		/// <param name="feedId">Feed identifier.</param>
		public static XivelyData GetCurrentData(string xivelyDataApiKey, string feedId) 
		{
			try {
				// send request to specified feedId
				WebRequest request = WebRequest.Create ("https://api.xively.com/v2/feeds/" + feedId + ".json");

				// debug
				Console.WriteLine (xivelyDataApiKey);

				// add api key, for verification
				request.Headers.Add ("X-ApiKey", xivelyDataApiKey);

				// get response
				WebResponse response = request.GetResponse ();

				Stream rawdata = response.GetResponseStream ();
				StreamReader reader = new StreamReader (rawdata);
				string jsonData = reader.ReadToEnd ();

				// translate string (JSON) into new weather info object
				XivelyData data = JsonConvert.DeserializeObject<XivelyData> (jsonData);

				// sets up correct key
				UserSettings.CorrectKey = true;

				// return data
				return data;


			} catch {

				Console.WriteLine ("keys doesn't work");
				UserSettings.CorrectKey = false;
				return null;

			}




		}

		/// <summary>
		/// Gets the historic data.
		/// Example:
		/// XivelyData historicData = XivelyData.GetHistoricData (apiKey, feedId, "6hours", "500"); 
		/// </summary>
		/// <returns>The historic data.</returns>
		/// <param name="xivelyDataApiKey">Xively data API key.</param>
		/// <param name="feedId">Feed identifier.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="limit">Limit.</param>
		public static XivelyData GetHistoricData(string xivelyDataApiKey, string feedId, string duration, string limit) 
		{
		
			try {
				// send request to specified feedId
				WebRequest request = WebRequest.Create ("https://api.xively.com/v2/feeds/" + feedId + "?duration=" + duration + "&limit=" + limit + "&function=average");

				// add api key, for verification
				request.Headers.Add ("X-ApiKey", xivelyDataApiKey);

				// get response
				WebResponse response = request.GetResponse ();

				// translate data to string
				Stream rawdata = response.GetResponseStream ();
				StreamReader reader = new StreamReader (rawdata);
				string jsonData = reader.ReadToEnd ();

				// translate string (JSON) into new weather info object
				XivelyData data = JsonConvert.DeserializeObject<XivelyData> (jsonData);

				UserSettings.CorrectKey = true;

				// return data
				return data;

			} catch {

				UserSettings.CorrectKey = false;
				Console.WriteLine ("keys doesn't work");
				return null;

			}

		}
			
	}
}

