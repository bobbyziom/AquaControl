using System;

namespace AquaControl
{
	public partial class Preferences : Gtk.Window
	{

		UserSettings _settings;

		/// <summary>
		/// Initializes a new instance of the settings window.
		/// </summary>
		public Preferences () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			_settings = new UserSettings ();

			impKeyEntry.Text = _settings.ImpKey;
			xivelyApiKeyEntry.Text = _settings.XivelyApiKey;
			xivelyFeedIdEntry.Text = _settings.XivelyFeedId;

		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			// save entryToSave value into system settings
			if (impKeyEntry.Text != "") {
				_settings.ImpKey = impKeyEntry.Text;
			}
			if (xivelyApiKeyEntry.Text != "") {
				_settings.XivelyApiKey = xivelyApiKeyEntry.Text;
			}
			if (xivelyFeedIdEntry.Text != "") {
				_settings.XivelyFeedId = xivelyFeedIdEntry.Text;
			}

			_settings.Save ();

			// display status in statusLael
			statusLabel.Text = "Stored!";
		}

	}
}

