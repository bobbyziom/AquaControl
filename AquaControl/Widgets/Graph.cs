using System;
using Cairo;

namespace AquaControl
{
	public class Graph : BaseObject
	{
	
		private double[] _graphData;
		//BaseObject[] dotContainer;

	
		public double _minValue { get; set;}
		public double _maxValue { get; set;}

		public double[] p1Xcoordinates ;
		public double[] p1Ycoordinates ;


		private PointD _p1,_p2;

		/// <summary>
		/// Gets or sets the graphic spacing between each data point in the x direction 
		/// </summary>
		/// <value>The x_scale_ratio.</value>
		public double x_scale_ratio { get; set; } 

		/// <summary>
		/// Only used for getting
		/// </summary>
		/// <value>The _total data points.</value>
		public int _totalDataPoints { get; set; }

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
			FindSmallestValue(_graphData);
			FindMaxValue (_graphData);



	

			surface.LineWidth = GraphLineWidth;
			surface.SetSourceRGBA (R, G, B, Alpha);


			//Console.WriteLine ("the smallest value is " + smallestValue);

			for (int i = 0; i < _totalDataPoints - 1; i++) {

				int k = i + 1;

				_p1 = new PointD (DrawAssembly.FrameAreaMarginLEFT + (i * (x_scale_ratio*0.5)), DrawAssembly.FrameAreaHeight - (_graphData [i] - _minValue) * (y_scale_ratio*0.5));
				_p2 = new PointD (DrawAssembly.FrameAreaMarginLEFT + (k * (x_scale_ratio*0.5)), DrawAssembly.FrameAreaHeight - (_graphData [k] - _minValue) * (y_scale_ratio*0.5));

				surface.MoveTo (_p1);
				surface.LineTo (_p2);

				p1Xcoordinates [i] = _p1.X;
				p1Ycoordinates [i] = _p1.Y;



			}

			surface.Stroke ();

			string widgetText = DataStreamId;
			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (R, G, B, Alpha);
			surface.MoveTo(DrawAssembly.FrameAreaWidth - text.Width - DrawAssembly.FrameAreaMarginLEFT, DrawAssembly.FrameAreaHeight - (text.Height*Id));

			surface.ShowText (widgetText);

			surface.SetSourceRGBA (1, 1, 1, 0.5);
			surface.Rectangle (DrawAssembly.FrameAreaMarginLEFT, 0, DrawAssembly.FrameAreaWidth, DrawAssembly.FrameAreaHeight);
			surface.Stroke ();


		}

		/// <summary>
		/// Finds the smallest value.
		/// </summary>
		/// <returns>The smallest value.</returns>
		/// <param name="value">Value.</param>
		public double FindSmallestValue(Double[] value)
		{
			if (CurrentData.HistoricDataStored) {
				_minValue = value [1];

				for (int i = 0; i < _totalDataPoints; i++) {
					for (int k = 0; k < _totalDataPoints; k++) {
						if (value [i] < _minValue) {
							_minValue = value [i];
						}
					}
				}

				return _minValue;
			} else {
				return 0;
			}

		}
		public double FindMaxValue(Double[] value){

			if (CurrentData.HistoricDataStored) {
				_maxValue = value [1];

				for (int i = 0; i < _totalDataPoints; i++) {
					for (int k = 0; k < _totalDataPoints; k++) {
						if (value [i] > _maxValue) {
							_maxValue= value [i];
						}
					}
				}

				return _maxValue;
			} else {
				return 0;
			}
				
		}



		/// <summary>
		/// Retrieves the data.
		/// </summary>
		public void RetrieveData() 
		{
		
			if (CurrentData.HistoricDataStored) {

				XivelyData newData = CurrentData.HistroicData;

				if (newData.datastreams.Count < 1) {
					Console.WriteLine ("Datastream Not Found");
				} else {
					for (int i = 0; i < newData.datastreams.Count; i++) {
						if (newData.datastreams [i].id == DataStreamId) {

							if (newData.datastreams [i].datapoints != null) {

								int graph_dataP = newData.datastreams [i].datapoints.Count;
								_totalDataPoints = graph_dataP;
								_graphData = new double[_totalDataPoints];
								p1Xcoordinates = new double[_totalDataPoints];
								p1Ycoordinates = new double[_totalDataPoints];

								for (int j = 0; j < _totalDataPoints; j++) {

									_graphData [j] = Convert.ToDouble (newData.datastreams [i].datapoints [j].value);

									//Console.Write (" " + GraphData [j]);
	
								}
							} else {

								Console.WriteLine ("no dataspoints");
							}
						}
					}
				} 
			}
				
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


	}
}

