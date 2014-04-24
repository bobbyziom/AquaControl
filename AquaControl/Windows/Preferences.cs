using System;

namespace AquaControl
{
	public partial class Preferences : Gtk.Window
	{
	
		/// <summary>
		/// Initializes a new instance of the settings window.
		/// </summary>
		public Preferences () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			impKeyEntry.Text = UserSettings.ImpKey;
			xivelyApiKeyEntry.Text = UserSettings.XivelyApiKey;
			xivelyFeedIdEntry.Text = UserSettings.XivelyFeedId;

		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			// save entryToSave value into system settings
			if (impKeyEntry.Text != "") {
				UserSettings.ImpKey = impKeyEntry.Text;
			}
			if (xivelyApiKeyEntry.Text != "") {
				UserSettings.XivelyApiKey = xivelyApiKeyEntry.Text;
			}
			if (xivelyFeedIdEntry.Text != "") {
				UserSettings.XivelyFeedId = xivelyFeedIdEntry.Text;
			}

			UserSettings.Save ();

			// display status in statusLael
			statusLabel.Text = "Stored!";

		}

	}
}

