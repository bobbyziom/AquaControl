using System;
using System.Timers;

namespace AquaControl
{
	public static class CurrentData
	{

		public static Timer _dataGetter;

		/// <summary>
		/// Gets a value indicating whether this <see cref="AquaControl.CurrentData"/> data is received.
		/// </summary>
		/// <value><c>true</c> if data is received; otherwise, <c>false</c>.</value>
		public static bool DataIsReceived { get; set; }

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public static XivelyData Data { get; set; }

		/// <summary>
		/// Starts the data gathering.
		/// </summary>
		public static void StartDataGathering() 
		{

			DataIsReceived = false;

			_dataGetter = new Timer (10000);
			_dataGetter.Elapsed += new ElapsedEventHandler(OnUpdate);
			_dataGetter.Enabled = true;
			_dataGetter.AutoReset = true;

		}

		private static void OnUpdate(object source, ElapsedEventArgs e) 
		{

			if (!DataIsReceived) {
				Data = XivelyData.GetCurrentData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId);
				DataIsReceived = true;
			} else {
				DataIsReceived = false;
			}

		}

	}
}

