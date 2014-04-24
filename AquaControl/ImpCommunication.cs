using System;
using System.Net;

namespace AquaControl
{

	public static class ImpCommunication
	{
	
		/// <summary>
		/// Send the specified key and value to imp.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public static void Send(string key, string value) 
		{

			WebRequest request = WebRequest.Create ("https://agent.electricimp.com/" + UserSettings.ImpKey + "?" + key + "=" + value);

			WebResponse response = request.GetResponse ();

			response.Close ();
		
		}
			

	}
}

