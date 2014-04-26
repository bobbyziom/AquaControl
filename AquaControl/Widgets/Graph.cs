﻿using System;
using Cairo;

namespace AquaControl
{
	public class Graph : BaseObject
	{
	
		int dataStreamIndex;
		private double[] GraphData;
		private int totalDataPoints;
		int arrayLength;


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


		private double smallestValue;

		PointD p1,p2;

			

		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.KevinsObject"/> class.
		/// </summary>
		public Graph (int dataStreamInd)
		{

			dataStreamIndex = dataStreamInd;

			GraphData = new double[10] { 23, 24, 25, 23, 25, 28, 30, 23, 21, 22};
			arrayLength = 10;
			x_scale_ratio = 20;
			y_scale_ratio = 50;

			//retrieveData ();
			//findSmallestValue(GraphData);
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
		
	
			surface.LineWidth = 3;
			surface.SetSourceRGB (0.0f, 1.0f, 0.0f);


			//Console.WriteLine ("the smallest value is " + smallestValue);

			for (int i = 0; i < arrayLength - 1; i++) {

				int k = i + 1;


				p1 = new PointD (x + (i * x_scale_ratio), y - (GraphData [i] - smallestValue) * y_scale_ratio);
				p2 = new PointD (x + (k * x_scale_ratio), y - (GraphData [k] - smallestValue) * y_scale_ratio);

				surface.MoveTo (p1);
				surface.LineTo (p2);

			}

			surface.Stroke ();

		
		}

		/// <summary>
		/// Finds the smallest value.
		/// </summary>
		/// <returns>The smallest value.</returns>
		/// <param name="value">Value.</param>
		public double findSmallestValue(Double[] value)
		{

			smallestValue = value [1];

			for (int i = 0; i < arrayLength; i++) {
				for (int k = 0; k < arrayLength; k++) {
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
		public void retrieveData() 
		{

			XivelyData newData = XivelyData.GetHistoricData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId, "6hours", "500");


			if (dataStreamIndex > newData.datastreams.Count) {
					
				Console.WriteLine ("Datastream Not Found");

			} else if (newData.datastreams [dataStreamIndex].datapoints != null) {

				int graph_dataP = newData.datastreams [dataStreamIndex].datapoints.Count;
				totalDataPoints = graph_dataP;
				GraphData = new double[totalDataPoints];

				for (int i = 0; i < totalDataPoints; i++) {

					GraphData [i] = Convert.ToDouble (newData.datastreams [dataStreamIndex].datapoints [i].value);

				}

			} else {
				Console.WriteLine ("no datapoints found");
			}
				
		}
		/// <summary>
		/// Clears the graph from drawing Area
		/// </summary>
//		public void clearGraph(){
//
//			_r = UserSettings.BgColorR;
//			_g = UserSettings.BgColorG;
//			_b = UserSettings.BgColorG;
//
//			// DEN ER SAT TIL [0,0,0] LIGE NU, men den skal sætter til samme farve som drawingAreaBackGround
//			// hvis den er sat til den rigtig farve, så tegner den over det samme graph, DVS. den forsvinder
//
//
//			cr.SetSourceRGB (UserSettings.BgColorR, UserSettings.BgColorG, UserSettings.BgColorG);
//
//			for (int i = 0; i < totalDataPoints - 1; i++) {
//
//				int k = i + 1;
//
//
//				p1 = new PointD (_x + (i * x_scale_ratio), _y - 10 - (GraphData [i] - smallestValue) * y_scale_ratio);
//				p2 = new PointD (_x + (k * x_scale_ratio), _y - 10 - (GraphData [k] - smallestValue) * y_scale_ratio);
//
//				cr.MoveTo (p1);
//				cr.LineTo (p2);
//
//			}
//
//			cr.Stroke ();
//
//
//		}
//
	}
}

