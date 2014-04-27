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
			rEntry.Value = UserSettings.BgColorR;
			gEntry.Value = UserSettings.BgColorG;
			bEntry.Value = UserSettings.BgColorB;

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
			if (rEntry.Text != "") {
				UserSettings.BgColorR = (float)Convert.ToDouble(rEntry.Value);
			}
			if (gEntry.Text != "") {
				UserSettings.BgColorG = (float)Convert.ToDouble(gEntry.Value);
			}
			if (bEntry.Text != "") {
				UserSettings.BgColorB = (float)Convert.ToDouble(bEntry.Value);
			}

			UserSettings.Save ();

			// display status in statusLael
			statusLabel.Text = "Stored!";

			UserSettings.UserSetupCompleted = true;

		}

		protected void OnRndBtnClicked (object sender, EventArgs e)
		{

			rEntry.Value = GetRandomNumber (0, 100);
			gEntry.Value = GetRandomNumber (0, 100);
			bEntry.Value = GetRandomNumber (0, 100);

		}
			
		private double GetRandomNumber(double minimum, double maximum)
		{ 
			Random random = new Random();
			return random.NextDouble ();
		}
	}
}

