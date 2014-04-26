using System;
using Gtk;
using Cairo;
using Gdk;


namespace AquaControl
{

	public class graphClass
	{

		XivelyData _historicData;
	

		private double[] GraphData;
		private int totalDataPoints;

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


		public double _x { get; set; }
		public double _y { get; set; }

		PointD p1,p2;

		double _r, _g, _b;
	
		Context graphSurface;


		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.graphClass"/> class.
		/// </summary>
		public graphClass ()
		{
			x_scale_ratio = 20;
			y_scale_ratio = 50;

			_r = 0;
			_g = 1;
			_b = 0;

			_historicData = XivelyData.GetHistoricData (UserSettings.XivelyApiKey, UserSettings.XivelyFeedId, "6hours", "500");
			Console.WriteLine (totalDataPoints);

		}

		/// <summary>
		/// Draws the graph.
		/// </summary>
		/// <param name="dataStreamIndex">Data stream index.</param>
		public void drawGraph(int dataStreamIndex) // value has to be between 1 and 9
		{ 
		 
			if (dataStreamIndex > _historicData.datastreams.Count) {
				Console.WriteLine ("Datastream Not Found");
			} else {
				int graph_dataP = _historicData.datastreams [dataStreamIndex].datapoints.Count;
				totalDataPoints = graph_dataP;

				GraphData = new double[totalDataPoints];

				for (int i = 0; i < totalDataPoints; i++) {

					GraphData [i] = Convert.ToDouble (_historicData.datastreams [dataStreamIndex].datapoints [i].value);
				}
					
				graphSurface.LineWidth = 3;
				graphSurface.SetSourceRGB (_r, _g, _b);

				findSmallestValue(GraphData);

				Console.WriteLine ("the smallest value is " + smallestValue);
		
				for (int i = 0; i < totalDataPoints - 1; i++) {

					int k = i + 1;

					Console.WriteLine (_y);

					p1 = new PointD (0 + (i * x_scale_ratio), _y - 10 - (GraphData [i] - smallestValue) * y_scale_ratio);
					p2 = new PointD (0 + (k * x_scale_ratio), _y - 10 - (GraphData [k] - smallestValue) * y_scale_ratio);

					graphSurface.MoveTo (p1);
					graphSurface.LineTo (p2);
				}
				graphSurface.Stroke ();
			}
		}

		/// <summary>
		/// Finds the smallest value amongst the data points.
		/// </summary>
		/// <returns>The smallest value.</returns>
		/// <param name="value">Value.</param>
		public double findSmallestValue(Double[] value)
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

		/// <summary>
		/// Swap the specified a and b.
		/// </summary>
		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		private void swap(ref int a, ref int b)
		{

			int tmp = a;
			a = b;
			b = tmp;
		}

		/// <summary>
		/// Updates the graph.
		/// </summary>
		/// <param name="drawingArea">Drawing area.</param>
		/// <param name="W">W.</param>
		/// <param name="H">H.</param>
		public void updateGraph(Gdk.Window drawingArea , double W, double H)
		{
		
			_x = W;
			_y = H;
			graphSurface = Gdk.CairoHelper.Create(drawingArea);

		}

		/// <summary>
		/// Clears the draw area.
		/// </summary>
		/// <param name="drawingAreaR">Drawing area r.</param>
		public void clearDrawArea(Gdk.Window drawingAreaR)
		{
		
			drawingAreaR.Clear ();

		}

	}
}

