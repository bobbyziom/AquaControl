using System;
using Cairo;

namespace AquaControl
{
	public class KevinsObject:BaseObject
	{

		private string xivelyDataApiKey = "PCwlL9WXyvGafdpdCY9R2PhTJIwstlwv8KncOHFsTSUC7jDr";
		private string feedid = "1590545863";
		int dataStreamIndex = 1;

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


		Context cr;

		public KevinsObject ()
		{


			x_scale_ratio = 20;
			y_scale_ratio = 50;


			_r = 0;
			_g = 1;
			_b = 0;




		}

		public override void Draw(Context surface, int x, int y){

			cr = surface;

			XivelyData newData = XivelyData.GetHistoricData (xivelyDataApiKey, feedid, "6hours", "500");

			if (dataStreamIndex > newData.datastreams.Count) {
				Console.WriteLine ("Datastream Not Found");
			} else {
				int graph_dataP = newData.datastreams [dataStreamIndex].datapoints.Count;
				totalDataPoints = graph_dataP;



				GraphData = new double[totalDataPoints];

				for (int i = 0; i < totalDataPoints; i++) {

					GraphData [i] = Convert.ToDouble (newData.datastreams [dataStreamIndex].datapoints [i].value);


				}



				cr.LineWidth = 3;
				cr.SetSourceRGB (_r, _g, _b);


				findSmallestValue(GraphData);

				Console.WriteLine ("the smallest value is " + smallestValue);

				for (int i = 0; i < totalDataPoints - 1; i++) {

					int k = i + 1;

					Console.WriteLine (y);

					p1 = new PointD (0 + (i * x_scale_ratio), y - 10 - (GraphData [i] - smallestValue) * y_scale_ratio);
					p2 = new PointD (0 + (k * x_scale_ratio), y - 10 - (GraphData [k] - smallestValue) * y_scale_ratio);

					cr.MoveTo (p1);
					cr.LineTo (p2);

				}

				cr.Stroke ();

			}





		}

		public double findSmallestValue(Double[] value){

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


	}
}

