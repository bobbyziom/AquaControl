using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

// 
enum SECTIONS {BOT = 1, MID = 2, TOP = 3};

namespace AquaControl
{
	public static class DrawAssembly {


		private const int _coordinatesNum = 2;

		private static int[,,] _frameCoordinates;

		private static int _frameSize;

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
		public static void Setup(int frameSize)
		{


			_frameSize = frameSize;

			GraphPosition = (int)SECTIONS.BOT;

			_frameCoordinates = new int[_frameSize,_frameSize,_coordinatesNum];

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

				for (int xPos = 0; xPos < _frameSize; xPos++) {

					for (int yPos = 0; yPos < _frameSize; yPos++) {

						// Puts a coordinate into the FrameCoordinate array

						//------- The array -------- Dimensions of drawing area -- Rows and coloums ------------------ Margin ------------------ //
						_frameCoordinates [xPos, yPos, 0] = (int)ContentWidth / _frameSize * yPos+((int)ContentWidth / _frameSize/2);
						_frameCoordinates [xPos, yPos, 1] = (int)ContentHeigth / _frameSize * xPos+((int)ContentHeigth / _frameSize/2);

					}
				}
			}

			//----------- Generates Widgets from widgetContainer
			GraphPosition = 3;


			int RowStart = 0;
			int RowJump = 0;
			int RowStop = 0;

			if (GraphPosition == (int)SECTIONS.BOT) {		
				RowStart = 0;	
				RowJump = 0; 	
				RowStop = 1;        
				//newGraph.KevinCoordinates (FrameCoordinates [3, 0, 0], FrameCoordinates [3, 0, 1]);		
			}

			if (GraphPosition == (int)SECTIONS.MID) {		
				RowStart = 0;	
				RowJump = 1; 	
				RowStop = 0;
				//newGraph.KevinCoordinates (FrameCoordinates [2, 0, 0], FrameCoordinates [2, 0, 1]);	
			}
			if (GraphPosition == (int)SECTIONS.TOP) {		
				RowStart = 1;	
				RowJump = 0; 	
				RowStop = 0;	
				//newGraph.KevinCoordinates (FrameCoordinates [1, 0, 0], FrameCoordinates [1, 0, 1]);	
			}
				


			int CountWidgets = 0;

			for (int Xframes = 0; Xframes < _frameSize; Xframes++) {
				for (int Yframes = 0+RowStart; Yframes < _frameSize-RowStop; Yframes+=(1+RowJump)) {

					using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (MainDrawingArea)) {
						WidgetContainer.widgetArray [CountWidgets].Draw (SurfaceWidget, _frameCoordinates [Yframes, Xframes, 0], _frameCoordinates [Yframes, Xframes, 1]);
						CountWidgets++;
					}

				}
			}


			using (Cairo.Context SurfaceGraph = Gdk.CairoHelper.Create (MainDrawingArea)) {

				for (int i = 0; i < GraphContainer.TotalGraphCount; i++) {
					GraphContainer.graphArray [i].Draw (SurfaceGraph, 50, i*50);
				}
			}


		}
	}
}

