using System;
using System.Net;

namespace system_settings_test
{
	public class ImpCommunication
	{

		UserSettings _settings;

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

