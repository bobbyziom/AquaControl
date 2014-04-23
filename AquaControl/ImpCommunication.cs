using System;
using System.Net;

namespace AquaControl
{
	public class ImpCommunication
	{

		UserSettings _settings;


		/// <summary>
		/// Initializes a new instance of the <see cref="system_settings_test.ImpCommunication"/> class.
		/// </summary>
		public ImpCommunication ()
		{

			_settings = new UserSettings();

		}

		/// <summary>
		/// Send the specified key and value to imp.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public void Send(string key, string value) 
		{

			WebRequest request = WebRequest.Create ("https://agent.electricimp.com/" + _settings.ImpKey + "?" + key + "=" + value);

			WebResponse response = request.GetResponse ();

			response.Close ();
		
		}
			

	}
}

