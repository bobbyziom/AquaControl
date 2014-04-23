using System;
using System.Configuration;

namespace AquaControl
{
	public class UserSettings
	{
		// config variable
		Configuration config;

		/// <summary>
		/// Gets or sets the xively API key.
		/// </summary>
		/// <value>The xively API key.</value>
		public string XivelyApiKey { get; set; }

		/// <summary>
		/// Gets or sets the imp key.
		/// </summary>
		/// <value>The imp key.</value>
		public string ImpKey { get; set; }

		/// <summary>
		/// Gets or sets the xively feed id.
		/// </summary>
		/// <value>The xively feed id.</value>
		public string XivelyFeedId { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="system_settings_test.UserSettings"/> class.
		/// </summary>
		public UserSettings ()
		{
			// find the config file and set it to config variable
			config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			// copy all user settings to class properties
			StoreSettings ();

		}

		/// <summary>
		/// Save current settings.
		/// </summary>
		public void Save() 
		{
			// clear current user settings 
			config.AppSettings.Settings.Clear ();

			// add xively api key
			config.AppSettings.Settings.Add("XivelyApiKey", XivelyApiKey);

			// add xively feed id
			config.AppSettings.Settings.Add("XivelyFeedId", XivelyFeedId);

			// add imp key
			config.AppSettings.Settings.Add("ImpKey", ImpKey);

			// save added configurations
			config.Save(ConfigurationSaveMode.Full);

		}

		/// <summary>
		/// Get settings from user configuration files and store them.
		/// </summary>
		private void StoreSettings() 
		{

			KeyValueConfigurationCollection collection = config.AppSettings.Settings;

			foreach (KeyValueConfigurationElement keyValue in collection) {

				if (keyValue.Key == "XivelyApiKey") {
					XivelyApiKey = keyValue.Value;
				} 

				if (keyValue.Key == "XivelyFeedId") {
					XivelyFeedId = keyValue.Value;
				} 

				if (keyValue.Key == "ImpKey") {
					ImpKey = keyValue.Value;
				} 
					
			}

		}

	}
}

