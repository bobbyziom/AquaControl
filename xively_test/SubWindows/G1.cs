using System;
using Gtk;
using System.Net;
using System.IO;
using System.Drawing;
using Gdk;

namespace xively_test
{
	public partial class G1 : Gtk.Window
	{
		public G1 () : base (Gtk.WindowType.Toplevel)
		{
		
			this.Build ();

//			WebRequest requestPic = WebRequest.Create(@"https://api.xively.com/v2/feeds/1742736382/datastreams/AIR_TEMP.png");
//
//			requestPic.Headers.Add ("X-ApiKey", "docgCPCcgxGctvGhTYls4db6vZCwHeOhvP9XQVAshiRs0Osw");
//
//			WebResponse responsePic = requestPic.GetResponse();
//
//			System.Drawing.Image webImage = System.Drawing.Image.FromStream(responsePic.GetResponseStream());
//


			//string localFilename = @"/Users/Bobby/Desktop/graph.png";

			//WebClient client = new WebClient ();

			//client.Headers.Add ("X-ApiKey", "docgCPCcgxGctvGhTYls4db6vZCwHeOhvP9XQVAshiRs0Osw");

			//client.DownloadFile ("https://api.xively.com/v2/feeds/1742736382/datastreams/AIR_TEMP.png", localFilename);

			//graphImg = Image.LoadFromResource (@"/Users/Bobby/Desktop/hest.png");

		}

		protected void OnButton18Clicked (object sender, EventArgs e)
		{
			this.Visible = false;

		}

	}
}

