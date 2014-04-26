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

		/// <summary>
		/// Gets or sets the content heigth.
		/// </summary>
		/// <value>The content heigth.</value>
		public  static float ContentHeigth { get; set; }

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
		/// The size of the frame.
		/// </summary>
		public static int FrameSize { get; set; }


		public static int[,,] FrameCoordinates = new int[3,3,2];

		public static int graphPosition = (int)SECTIONS.BOT;


		public static void Setup(int frameSize)
		{
			//KevinsObject newGraph = new KevinsObject();

			FrameSize = frameSize;

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
				surface1.SetSourceRGB (r, g, b);
				surface1.Rectangle (0, 0, ContentWidth, ContentHeigth);
				surface1.Fill ();
			}

		}

		/// <summary>
		/// Finds the coordinates for the entire frame and posts it into "FrameCoordinates", followed by the posting process of surface objects, dependent on those coordinates generated.
		/// </summary>
		public static void DrawFramework ()
		{

			for (int NewCordi = 1; NewCordi < (FrameCoordinates.Length/2); NewCordi++) {

				for (int xPos = 0; xPos < FrameSize; xPos++) {

					for (int yPos = 0; yPos < FrameSize; yPos++) {

						// Puts a coordinate into the FrameCoordinate array

						//------- The array -------- Dimensions of drawing area -- Rows and coloums ------------------ Margin ------------------ //
						FrameCoordinates [xPos, yPos, 0] = (int)ContentWidth / FrameSize * yPos+((int)ContentWidth / FrameSize/2);
						FrameCoordinates [xPos, yPos, 1] = (int)ContentHeigth / FrameSize * xPos+((int)ContentHeigth / FrameSize/2);

					}
				}
			}

			//----------- Generates Widgets from widgetContainer
			graphPosition = 3;


			int RowStart = 0;
			int RowJump = 0;
			int RowStop = 0;

			if (graphPosition == (int)SECTIONS.BOT) {		
				RowStart = 0;	
				RowJump = 0; 	
				RowStop = 1;        
				//newGraph.KevinCoordinates (FrameCoordinates [3, 0, 0], FrameCoordinates [3, 0, 1]);		
			}

			if (graphPosition == (int)SECTIONS.MID) {		
				RowStart = 0;	
				RowJump = 1; 	
				RowStop = 0;
				//newGraph.KevinCoordinates (FrameCoordinates [2, 0, 0], FrameCoordinates [2, 0, 1]);	
			}
			if (graphPosition == (int)SECTIONS.TOP) {		
				RowStart = 1;	
				RowJump = 0; 	
				RowStop = 0;	
				//newGraph.KevinCoordinates (FrameCoordinates [1, 0, 0], FrameCoordinates [1, 0, 1]);	
			}
				


			int CountWidgets = 0;

			for (int Xframes = 0; Xframes < FrameSize; Xframes++) {
				for (int Yframes = 0+RowStart; Yframes < FrameSize-RowStop; Yframes+=(1+RowJump)) {

					using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (MainDrawingArea)) {
						WidgetContainer.widgetArray [CountWidgets].Draw (SurfaceWidget, FrameCoordinates [Yframes, Xframes, 0], FrameCoordinates [Yframes, Xframes, 1]);
						CountWidgets++;
					}

				}
			}
//
//			// HER SKULLE GRAFEN GERNE VIRKE -.-
//			using (Cairo.Context SurfaceGraph = Gdk.CairoHelper.Create (MainDrawingArea)) {
//				newGraph.Draw (SurfaceGraph, 0, 0);
//			}
//

		}
	}
}

