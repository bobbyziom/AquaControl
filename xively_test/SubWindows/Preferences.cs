using System;
using Gtk;

namespace xively_test
{
	public partial class Preferences : Gtk.Window
	{
	
		public string APIKey { get; set; }
		public bool APIisSaved { get; set; }
	
		public Preferences () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.Visible = false;
		}

		protected void OnButton2Clicked (object sender, EventArgs e)
		{
			APIentry.Text = "docgCPCcgxGctvGhTYls4db6vZCwHeOhvP9XQVAshiRs0Osw";
			APIKey = APIentry.Text;
			APIisSaved = true;
			savedAPIKey.Text = "using: \n" + APIKey;

		}

		protected void OnCloseClicked (object sender, EventArgs e)
		{
			this.Visible = false;
		}
	}
}

