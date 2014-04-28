using System;
using System.Timers;

namespace AquaControl
{
	public static class CurrentData
	{

		/// <summary>
		/// The data collection timer.
		/// </summary>
		public static Timer CollectTimer;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AquaControl.CurrentData"/> data stored.
		/// </summary>
		/// <value><c>true</c> if data stored; otherwise, <c>false</c>.</value>
		public static bool DataStored { get; set; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="AquaControl.CurrentData"/> data is received.
		/// </summary>
		/// <value><c>true</c> if data is received; otherwise, <c>false</c>.</value>
		public static bool DataIsReceived { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AquaControl.CurrentData"/> historic data stored.
		/// </summary>
		/// <value><c>true</c> if historic data stored; otherwise, <c>false</c>.</value>
		public static bool HistoricDataStored { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AquaControl.CurrentData"/> historic data is received.
		/// </summary>
		/// <value><c>true</c> if historic data is received; otherwise, <c>false</c>.</value>
		public static bool HistoricDataIsReceived { get; set; }

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public static XivelyData Data { get; set; }

		/// <summary>
		/// Gets or sets the histroic data.
		/// </summary>
		/// <value>The histroic data.</value>
		public static XivelyData HistroicData { get; set; }

		/// <summary>
		/// Starts the data gathering.
		/// </summary>
		public static void StartDataGathering() 
		{

			DataIsReceived = false;
			DataStored = false;
			HistoricDataIsReceived = false;
			HistoricDataStored = false;

			CollectTimer = new Timer (10000);
			CollectTimer.Elapsed += new ElapsedEventHandler(OnUpdate);
			CollectTimer.Enabled = true;
			CollectTimer.AutoReset = true;

			Collect ();
			CollectHistoric ();


		}

		/// <summary>
		/// Raises the update event.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="e">E.</param>
		private static void OnUpdate(object source, ElapsedEventArgs e) 
		{

			Collect ();

		}

		/// <summary>
		/// Updates the historic data.
		/// </summary>
		public static void ForceUpdateData()
		{
		
			CollectHistoric ();
			Collect ();

		}

		/// <summary>
		/// Collect the data.
		/// </summary>
		private static void Collect()
		{

			if (UserSettings.UserSetupCompleted) {

				if (!DataIsReceived) {
					Data = XivelyData.GetCurrentData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId);
					if (Data != null) {
						DataIsReceived = true;
						DataStored = true;
					}
				} else {
					DataIsReceived = false;
				}

			} 

		}

		/// <summary>
		/// Collects the historic data.
		/// </summary>
		private static void CollectHistoric()
		{

			if (UserSettings.UserSetupCompleted) {
			
				if (!HistoricDataIsReceived) {
					HistroicData = XivelyData.GetHistoricData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId, "6hours", "500");
					if (HistroicData != null) {
						HistoricDataIsReceived = true;
						HistoricDataStored = true;
					}
				} else {
					HistoricDataIsReceived = false;
				}
					
			}
				
		}

		/// <summary>
		/// Gets the current value by identifier string.
		/// </summary>
		/// <returns>The current value by identifier string.</returns>
		/// <param name="id">Identifier.</param>
		public static string GetCurrentValueByIdString(string id)
		{

			string value = "No data";
		
			if (UserSettings.CorrectKey && DataStored) {
				for (int i = 0; i < Data.datastreams.Count; i++) {
					if (Data.datastreams [i].id == id) {

						value = Data.datastreams [i].current_value;

					}
				}
			}

			return value;

		}

		/// <summary>
		/// Gets the current value by identifier float.
		/// </summary>
		/// <returns>The current value by identifier float.</returns>
		/// <param name="id">Identifier.</param>
		public static float GetCurrentValueByIdFloat(string id)
		{

			float value = 0.0f;

			if (UserSettings.CorrectKey && DataStored) {
				for (int i = 0; i < Data.datastreams.Count; i++) {
					if (Data.datastreams [i].id == id) {

						value = (float)Convert.ToDouble(Data.datastreams [i].current_value);

					}
				}
			}

			return value;

		}

		/// <summary>
		/// Gets the current value by identifier int.
		/// </summary>
		/// <returns>The current value by identifier int.</returns>
		/// <param name="id">Identifier.</param>
		public static int GetCurrentValueByIdInt(string id)
		{

			int value = 0;

			if (UserSettings.CorrectKey && DataStored) {
				for (int i = 0; i < Data.datastreams.Count; i++) {
					if (Data.datastreams [i].id == id) {

						value = Convert.ToInt32(Data.datastreams [i].current_value);

					}
				}
			}

			return value;

		}


	}
}

