using System;

namespace AquaControl
{
	public static class WidgetContainer
	{

		private static bool[] _isAssigned;

		/// <summary>
		/// The widget array.
		/// </summary>
		public static BaseObject[] widgetArray;

		/// <summary>
		/// Gets or sets the total widget count.
		/// </summary>
		/// <value>The total widget count.</value>
		public static int TotalWidgetCount { get; set; }

		/// <summary>
		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.WidgetContainer"/> class.
		/// </summary>
		public static void AssignWidgetSpace (int amount)
		{

			TotalWidgetCount = amount;

			widgetArray = new BaseObject[TotalWidgetCount];
			_isAssigned = new bool[TotalWidgetCount];

			for (int i = 0; i < TotalWidgetCount; i++) {

				widgetArray[i] = new BaseObject ();
				_isAssigned [i] = false;

			}

		}

		/// <summary>
		/// Puts widget to widget container.
		/// </summary>
		/// <param name="o">The widget.</param>
		public static void PutWidget(BaseObject o) 
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

				widgetArray [index] = new BaseObject ();
				_isAssigned [index] = false;

			} else {

				Console.WriteLine ("No widget assigned on index provided: ({0}) ... Still containing std widget!", index);
			}

		}


		/// <summary>
		/// Checks all widget hover.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="clicked">Clicked.</param>
		public static void CheckAllWidgetHover(double x, double y, ref bool clicked) 
		{

			for (int i = 0; i < TotalWidgetCount; i++) {
				widgetArray[i].CheckMouseHover (x, y, ref clicked);
			}

		}


	}

}

