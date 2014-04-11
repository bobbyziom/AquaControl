using System;
using Gtk;
using Cairo;
using System.Net;
using System.IO;
using Gdk;

public partial class MainWindow: Gtk.Window
{

	bool statusOnOff = false;
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		// IMAGE 1-1
		// This loads an image from your computer. 
		var beamA = System.IO.File.ReadAllBytes ("/Users/Toretty/Projects/ImageImportProject/ImageImportProject/images/A.jpg");
		var A = new Gdk.Pixbuf (beamA);
		image1.Pixbuf = A;

		// This shuts off the light in order to follow the false/true
		WebRequest requestOFF = WebRequest.Create ("https://agent.electricimp.com/K0NppbqG6awI?led=0");
		WebResponse requestOFFR = requestOFF.GetResponse ();
		requestOFFR.Close ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void GraphLoader (object sender, EventArgs e)
	{
		// GRAPH LOADER
		// It both loads an image, but additionally also logs into xively so that it is possible to get the image.
		Pixbuf _graph;

		string StreamId = "LED";
		string GraphName = "Something";

		WebRequest request = WebRequest.Create ("https://api.xively.com/v2/feeds/1590545863/datastreams/"+ StreamId + ".png" + "?c=2188c5&g=true&t=" + GraphName + "&b=true");
		request.Headers.Add ("X-ApiKey", "PCwlL9WXyvGafdpdCY9R2PhTJIwstlwv8KncOHFsTSUC7jDr");
		WebResponse response = request.GetResponse ();
		Stream beam = response.GetResponseStream ();
		_graph = new Pixbuf (beam);
		image1.Pixbuf = _graph;
		response.Close ();

	}

	protected void On_Off_Toogled (object sender, EventArgs e)
	{
	
		// This turns off and turns on the light, which is connected to the Electric imp
		if(statusOnOff == false){
			WebRequest responseON = WebRequest.Create ("https://agent.electricimp.com/K0NppbqG6awI?led=1");
			WebResponse responseONR = responseON.GetResponse ();
			statusOnOff = true;
			responseONR.Close ();
		} else {
			WebRequest responseOFF2 = WebRequest.Create ("https://agent.electricimp.com/K0NppbqG6awI?led=0");
			WebResponse responseOFF2R = responseOFF2.GetResponse ();
			statusOnOff = false;
			responseOFF2R.Close ();
		}



	}
}