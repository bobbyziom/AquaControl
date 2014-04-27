using System;
using Cairo;

namespace AquaControl
{
	public class Graph : BaseObject
	{


		private double[] GraphData;
		private int totalDataPoints;
		private double smallestValue;
		private PointD p1,p2;

		/// <summary>
		/// Gets or sets the graphic spacing between each data point in the x direction 
		/// </summary>
		/// <value>The x_scale_ratio.</value>
		public double x_scale_ratio { get; set; } 

		/// <summary>
		/// Gets or sets the graphic spacing between each data point in the y direction
		/// </summary>
		/// <value>The y_scale_ratio.</value>
		public double y_scale_ratio { get; set; }

		/// <summary>
		/// Gets or sets the data stream identifier.
		/// </summary>
		/// <value>The data stream identifier.</value>
		public string DataStreamId { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the width of the graph line.
		/// </summary>
		/// <value>The width of the graph line.</value>
		public int GraphLineWidth { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.KevinsObject"/> class.
		/// </summary>
		public Graph ()
		{

			GraphLineWidth = 1;

			x_scale_ratio = 10;
			y_scale_ratio = 10;

			//SelectingColor (); // Selects a color based on dataStreamIndex

		}

		/// <summary>
		/// Draw the specified surface.
		/// </summary>
		/// <param name="surface">Surface.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public override void Draw(Cairo.Context surface, int x, int y)
		{

			X = x;
			Y = y;


			RetrieveData ();
			FindSmallestValue(GraphData);
	

			surface.LineWidth = GraphLineWidth;
			surface.SetSourceRGBA (R, G, B, Alpha);


			//Console.WriteLine ("the smallest value is " + smallestValue);

			for (int i = 0; i < totalDataPoints - 1; i++) {

				int k = i + 1;


				p1 = new PointD (X + (i * x_scale_ratio), Y + 200 - (GraphData [i] - smallestValue) * y_scale_ratio);
				p2 = new PointD (X + (k * x_scale_ratio), Y + 200 - (GraphData [k] - smallestValue) * y_scale_ratio);

				surface.MoveTo (p1);
				surface.LineTo (p2);

			}

			surface.Stroke ();

			string widgetText = DataStreamId;
			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (R, G, B, Alpha);
			surface.MoveTo(X + 200, Y + 100 + (text.Height*Id));

			surface.ShowText (widgetText);

		
		}

		/// <summary>
		/// Finds the smallest value.
		/// </summary>
		/// <returns>The smallest value.</returns>
		/// <param name="value">Value.</param>
		public double FindSmallestValue(Double[] value)
		{

			smallestValue = value [1];

			for (int i = 0; i < totalDataPoints; i++) {
				for (int k = 0; k < totalDataPoints; k++) {
					if (value [i] < smallestValue) {
						smallestValue = value [i];
					}
				}
			}

			return smallestValue;

		}

		/*
		/// <summary>
		/// Selectings the color.
		/// </summary>
		public void SelectingColor()
		{

			switch (dataStreamIndex) {

			case 0:
				_r = 0;
				_g = 1;
				_b = 0;
				break;

			case 1:

				_r = 1;
				_g = 1;
				_b = 0;
				break;

			case 2:

				_r = 1;
				_g = 0;
				_b = 0;
				break;

			case 3: 

				_r = 0;
				_g = 1;
				_b = 1;
				break;

			case 4:

				_r = 0;
				_g = 0;
				_b = 1;
				break;

			case 5:

				_r = 0.5;
				_g = 1;
				_b = 0;
				break;

			case 6:

				_r = 1;
				_g = 0.5;
				_b = 0;
				break;

			case 7:

				_r = 0.5;
				_g = 1;
				_b = 1;
				break;

			case 8:

				_r = 0;
				_g = 0.5;
				_b = 0.5;
				break;

			case 9:

				_r = 0;
				_g = 0;
				_b = 0;
				break;

			};


		}
		*/

		/// <summary>
		/// Retrieves the data.
		/// </summary>
		public void RetrieveData() 
		{

			XivelyData newData = CurrentData.HistroicData;

			if (newData.datastreams.Count < 1) {
				Console.WriteLine ("Datastream Not Found");
			} else  {
				for (int i = 0; i < newData.datastreams.Count; i++) {
					if (newData.datastreams [i].id == DataStreamId) {

						if (newData.datastreams [i].datapoints != null) {

							int graph_dataP = newData.datastreams [i].datapoints.Count;
							totalDataPoints = graph_dataP;
							GraphData = new double[totalDataPoints];

							for (int j = 0; j < totalDataPoints; j++) {

								GraphData [j] = Convert.ToDouble (newData.datastreams [i].datapoints [j].value);

								Console.Write (" " + GraphData [j]);
	
							}
						} else {

							Console.WriteLine ("no dataspoints");
						}
					}
				}
			} 
				
		}


	}
}

