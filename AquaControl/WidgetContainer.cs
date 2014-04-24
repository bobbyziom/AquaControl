using System;

namespace AquaControl
{
	public static class WidgetContainer
	{

		public static DatapointObject[] widgetArray;

		/// <summary>
		/// Gets or sets the total widget count.
		/// </summary>
		/// <value>The total widget count.</value>
		public static int TotalWidgetCount { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.WidgetContainer"/> class.
		/// </summary>
		public static void CreateWidgets (int amount)
		{

			TotalWidgetCount = amount;

			widgetArray = new DatapointObject[TotalWidgetCount];

			for (int i = 0; i < 9; i++) {

				widgetArray [i] = new TestObject ();

			}

		}

	}
}

