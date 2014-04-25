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

			retrieveData ();
			findSmallestValue(GraphData);
			SelectingColor (); // Selects a color based on dataStreamIndex






		}

		public override void Draw(Context surface, int x, int y){

				cr = surface;
				cr.LineWidth = 3;
				cr.SetSourceRGB (_r, _g, _b);


				

				Console.WriteLine ("the smallest value is " + smallestValue);

				for (int i = 0; i < totalDataPoints - 1; i++) {

					int k = i + 1;

					Console.WriteLine (y);

					p1 = new PointD (_x + (i * x_scale_ratio), _y - 10 - (GraphData [i] - smallestValue) * y_scale_ratio);
					p2 = new PointD (_x + (k * x_scale_ratio), _y - 10 - (GraphData [k] - smallestValue) * y_scale_ratio);

					cr.MoveTo (p1);
					cr.LineTo (p2);

				}

				cr.Stroke ();






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

		public void KevinCoordinates( int x , int y) {

			_x = x;

			_y = y;
		}

		public void SelectingColor(){

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

		public void retrieveData() {

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

			}


		}
		/// <summary>
		/// Clears the graph from drawing Area
		/// </summary>
		public void clearGraph(){

				_r = 0;
				_g = 0;
				_b = 0;

			// DEN ER SAT TIL [0,0,0] LIGE NU, men den skal sætter til samme farve som drawingAreaBackGround
			// hvis den er sat til den rigtig farve, så tegner den over det samme graph, DVS. den forsvinder


			cr.SetSourceRGB (_r, _g, _b);

			for (int i = 0; i < totalDataPoints - 1; i++) {

				int k = i + 1;


				p1 = new PointD (_x + (i * x_scale_ratio), _y - 10 - (GraphData [i] - smallestValue) * y_scale_ratio);
				p2 = new PointD (_x + (k * x_scale_ratio), _y - 10 - (GraphData [k] - smallestValue) * y_scale_ratio);

				cr.MoveTo (p1);
				cr.LineTo (p2);

			}

			cr.Stroke ();


		}

	}
}

