using System;
using System.Timers;

namespace AquaControl
{
	public static class CurrentData
	{

		public static Timer _dataGetter;

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
			DataStored = false;

			_dataGetter = new Timer (10000);
			_dataGetter.Elapsed += new ElapsedEventHandler(OnUpdate);
			_dataGetter.Enabled = true;
			_dataGetter.AutoReset = true;

		}

		/// <summary>
		/// Raises the update event.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="e">E.</param>
		private static void OnUpdate(object source, ElapsedEventArgs e) 
		{

			if (!DataIsReceived) {
				Data = XivelyData.GetCurrentData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId);
				DataIsReceived = true;
				DataStored = true;
			} else {
				DataIsReceived = false;
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
		
			if (CurrentData.DataStored) {
				for (int i = 0; i < CurrentData.Data.datastreams.Count; i++) {
					if (CurrentData.Data.datastreams [i].id == id) {

						value = CurrentData.Data.datastreams [i].current_value;

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

			if (CurrentData.DataStored) {
				for (int i = 0; i < CurrentData.Data.datastreams.Count; i++) {
					if (CurrentData.Data.datastreams [i].id == id) {

						value = (float)Convert.ToDouble(CurrentData.Data.datastreams [i].current_value);

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

			if (CurrentData.DataStored) {
				for (int i = 0; i < CurrentData.Data.datastreams.Count; i++) {
					if (CurrentData.Data.datastreams [i].id == id) {

						value = Convert.ToInt32(CurrentData.Data.datastreams [i].current_value);

					}
				}
			}

			return value;

		}



	}
}

