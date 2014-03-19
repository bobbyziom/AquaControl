using System;
using Gtk;
using System.Net;
using System.Timers;
using System.IO;
using Newtonsoft.Json;
using xively_test;

public partial class MainWindow: Gtk.Window
{

	Preferences pref = new Preferences ();
	G1 AIR_TEMP = new G1 ();
	Timer update;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		update = new Timer (10000);
		update.Start ();
		update.AutoReset = true;
		update.Elapsed += new ElapsedEventHandler(TickHandler);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	private void TickHandler(object sender, EventArgs e)
	{
		Console.WriteLine ();
	}


	protected void OnButtonGetDataClicked (object sender, EventArgs e)
	{

		if (pref.APIisSaved) {
			// create web request to xively
			WebRequest request = WebRequest.Create ("https://api.xively.com/v2/feeds/1742736382.json");
			// add api key, for verification


			Console.WriteLine (pref.APIKey);
			request.Headers.Add ("X-ApiKey", pref.APIKey);
		
			// get response from xively
			WebResponse response = request.GetResponse ();
			// write data into stream
			Stream dataStream = response.GetResponseStream ();
			// create reader
			StreamReader reader = new StreamReader (dataStream);
			// copy recieved data into str
			string responseFromServer = reader.ReadToEnd ();
			// write recieved into console
			Console.WriteLine (responseFromServer);
			// collect and store data 
			XivelyData info = JsonConvert.DeserializeObject<XivelyData> (responseFromServer);
			// write data streams and values to console



			label1.Text = info.datastreams [0].id + ": ";
			label2.Text = info.datastreams [0].current_value;

			label7.Text = info.datastreams [1].id + ": ";
			label8.Text = info.datastreams [1].current_value;

			label9.Text = info.datastreams [2].id + ": ";
			label10.Text = info.datastreams [2].current_value;

			label11.Text = info.datastreams [3].id + ": ";
			label12.Text = info.datastreams [3].current_value;

			label13.Text = info.datastreams [4].id + ": ";
			label14.Text = info.datastreams [4].current_value;

			label15.Text = info.datastreams [5].id + ": ";
			label16.Text = info.datastreams [5].current_value;

			label17.Text = info.datastreams [6].id + ": ";
			label18.Text = info.datastreams [6].current_value;

			label19.Text = info.datastreams [7].id + ": ";
			label20.Text = info.datastreams [7].current_value;

			label21.Text = info.datastreams [8].id + ": ";
			label22.Text = info.datastreams [8].current_value;

			label23.Text = info.datastreams [9].id + ": ";
			label24.Text = info.datastreams [9].current_value;

			label25.Text = info.datastreams [10].id + ": ";
			label26.Text = info.datastreams [10].current_value;

			label27.Text = info.datastreams [11].id + ": ";
			label28.Text = info.datastreams [11].current_value;

			label29.Text = info.datastreams [12].id + ": ";
			label30.Text = info.datastreams [12].current_value;
		} else {
			label30.Text = "API KEY NOT STORED!";
		}


	}

	protected void OnPrefButtonClicked (object sender, EventArgs e)
	{
		pref.Visible = true;
	}

	protected void OnButton5Clicked (object sender, EventArgs e)
	{
		AIR_TEMP.Visible = true;
	}
}
