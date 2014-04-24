using System;

namespace AquaControl
{
	public static class WidgetContainer
	{

		private static bool[] _isAssigned;

		/// <summary>
		/// The widget array.
		/// </summary>
		public static DatapointObject[] widgetArray;

		public static int TotalWidgetCount { get; set; }

		/// <summary>
		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.WidgetContainer"/> class.
		/// </summary>
		public static void AssignWidgetSpace (int amount)
		{

			TotalWidgetCount = amount;

			widgetArray = new DatapointObject[TotalWidgetCount];
			_isAssigned = new bool[TotalWidgetCount];

			for (int i = 0; i < TotalWidgetCount; i++) {

				widgetArray[i] = new DatapointObject ();
				_isAssigned [i] = false;

			}

		}

		/// <summary>
		/// Puts widget to widget container.
		/// </summary>
		/// <param name="o">The widget.</param>
		public static void PutWidget(DatapointObject o) 
		{

			int putIndex = 0;

			while (putIndex < TotalWidgetCount) {

				if (!_isAssigned [putIndex]) {

					widgetArray [putIndex] = o;
					_isAssigned [putIndex] = true;
					putIndex = TotalWidgetCount;

				} else {

					putIndex++;

				}

			}

		}


		/// <summary>
		/// Removes widget by index.
		/// </summary>
		/// <param name="index">Index (must be below TotalWidgetCount)</param>.</param>
		public static void RemoveWidget(int index) 
		{
		
			if (_isAssigned [index] && index < TotalWidgetCount) {

				widgetArray [index] = new DatapointObject ();
				_isAssigned [index] = false;

			} else {

				Console.WriteLine ("No widget assigned on index provided: ({0}) ... Still containing std widget!", index);
			}

		}
	}

}

