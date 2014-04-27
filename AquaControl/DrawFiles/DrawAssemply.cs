using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

// 
enum SECTIONS {BOT = 0, MID = 1, TOP = 2};

namespace AquaControl
{
	public static class DrawAssembly {

		private const int _coordinatesNum = 2;
		private static int[,,] _frameCoordinates;
		private static int _frameSize;
		private static int _frameHeight;

		/// <summary>
		/// Gets or sets the lenght of swipe.
		/// </summary>
		/// <value>The _ swipe lenght.</value>
		public static float _SwipeLenght { get; set; }

		/// <summary>
		/// Gets or sets the _ swipe margin.
		/// </summary>
		/// <value>The _ swipe margin.</value>
		public static float _SwipeMargin { get; set; }

		/// <summary>
		/// Gets or sets the times able to swipe.
		/// </summary>
		/// <value>The swipe amount.</value>
		public static float _SwipeAmount { get; set; }

		/// <summary>
		/// Gets or sets the content heigth.
		/// </summary>
		/// <value>The content heigth.</value>
		public static float ContentHeigth { get; set; }

		/// <summary>
		/// Gets or sets the width of the content.
		/// </summary>
		/// <value>The width of the content.</value>
		public static float ContentWidth { get; set;}

		/// <summary>
		/// Gets or sets the main drawing area2.
		/// </summary>
		/// <value>The main drawing area2.</value>
		public static Gdk.Window MainDrawingArea { get; set; }

		/// <summary>
		/// The graph position.
		/// </summary>
		public static int GraphPosition;

		/// <summary>
		/// Setup draw assembly with the specified frameSize.
		/// </summary>
		/// <param name="frameSize">Frame size.</param>
		public static void Setup(int frameSize, int frameHeigh, int SwipeAmount)
		{

			_SwipeAmount = SwipeAmount;
			_frameSize = frameSize;
			_frameHeight = frameHeigh;


			GraphPosition = (int)SECTIONS.BOT;

			_frameCoordinates = new int[_frameHeight,_frameSize,_coordinatesNum];

		}

		/// <summary>
		/// Updates the drawing context.
		/// </summary>
		/// <param name="context2">Context2.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public static void UpdateDrawingContext(Gdk.Window context2, float width, float height)
		{

			MainDrawingArea = context2;
			ContentHeigth = height;
			ContentWidth = width; 

		}

		/// <summary>
		/// Draws background
		/// </summary>
		public static void DrawBackground (float r, float g, float b)
		{

			using (Cairo.Context surface1 = Gdk.CairoHelper.Create (MainDrawingArea)) {
				// Background color (Created from a rectangle covering the background)
				surface1.SetSourceRGB (r
					, g, b);
				surface1.Rectangle (0, 0, ContentWidth, ContentHeigth);
				surface1.Fill ();
			}

		}

		/// <summary>
		/// Finds the coordinates for the entire frame and posts it into "FrameCoordinates", followed by the posting process of surface objects, dependent on those coordinates generated.
		/// </summary>
		public static void DrawFramework ()
		{

			for (int NewCordi = 1; NewCordi < (_frameCoordinates.Length/2); NewCordi++) {

				for (int xPos = 0; xPos < _frameHeight; xPos++) {

					for (int yPos = 0; yPos < _frameSize; yPos++) {

						// Puts a coordinate into the FrameCoordinate array

						//------- The array -------- Dimensions of drawing area -- Rows and coloums ------------------ Margin ------------------ //
						_frameCoordinates [xPos, yPos, 0] = (int)ContentWidth / _frameSize * yPos +((int)ContentWidth / _frameSize/2);
						_frameCoordinates [xPos, yPos, 1] = (int)ContentHeigth / _frameHeight  * xPos +((int)ContentHeigth / _frameSize/2);
					}
				}
			}

			//----------- Generates Widgets from widgetContainer
			GraphPosition = 2;


			int RowStart = 0;
			int RowJump = 0;
			int RowStop = 0;
			int Putgraph = 0;

			if (GraphPosition == (int)SECTIONS.BOT) {		
				RowStart = 0;	
				RowJump = 0; 	
				RowStop = 1; 
				Putgraph = 2;
			}

			if (GraphPosition == (int)SECTIONS.MID) {		
				RowStart = 0;	
				RowJump = 1; 	
				RowStop = 0;
				Putgraph = 1;
			}
			if (GraphPosition == (int)SECTIONS.TOP) {		
				RowStart = 1;	
				RowJump = 0; 	
				RowStop = 0;	
				Putgraph = 0;
			}

			int CountWidgets = 0;

			// SWIPE TIMES
			for(int swipes = 0; swipes != _SwipeAmount; swipes++){
			Console.WriteLine (swipes);

				// LOOP FOR WIDGETS
				for (int Xframes = 0; Xframes < _frameSize; Xframes++) {
					for (int Yframes = 0 + RowStart; Yframes < _frameHeight-RowStop; Yframes += (1+RowJump)) {

						using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (MainDrawingArea)) {
							WidgetContainer.widgetArray [CountWidgets].Draw (SurfaceWidget, _frameCoordinates [Yframes, Xframes, 0]+(int)_SwipeLenght+(int)_SwipeMargin, _frameCoordinates [Yframes, Xframes, 1]);
							CountWidgets++;
						}
					}
				}
				//((int)ContentWidth/2*swipes)

				// GENERATING GRAPH
				using (Cairo.Context SurfaceGraph = Gdk.CairoHelper.Create (MainDrawingArea)) {

					for (int i = 0; i < GraphContainer.TotalGraphCount; i++) {
						GraphContainer.graphArray [i].Draw (SurfaceGraph,  _frameCoordinates [Putgraph, 1, 0], _frameCoordinates [Putgraph, 1, 1]-(int)(ContentHeigth/7)); 

						// dynamic way of updating graph length and height

//						GraphContainer.graphArray [i].x_scale_ratio = GraphContainer.graphArray [i]._totalDataPoints / ContentWidth;
//						GraphContainer.graphArray [i].y_scale_ratio = GraphContainer.graphArray[i]._totalDataPoints/ ContentHeigth;
					}
				}

				_SwipeMargin = -ContentWidth;
			}
			_SwipeMargin = 0;
		}
	}
}

