using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

// 
enum SECTIONS {BOT = 1, MID = 2, TOP = 3};

namespace AquaControl
{
	public class DrawAssembly {

		KevinsObject newGraph = new KevinsObject();

		private float _contentHeight1;
		private float _contentWidth1;
		private Gdk.Window mainDrawingArea2;
		private int frameSize = 3;
		public int[,,] FrameCoordinates = new int[3,3,2];
		public float BgColorR = 0.2f;
		public float BgColorG = 0.2f;
		public float BgColorB = 0.2f;
		public int graphPosition = (int)SECTIONS.BOT;

		/// <summary>
		/// Receives data from UpdateParameters and makes them global to both DrawFramework and DrawBackground.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public void UpdateDrawingContext(Gdk.Window context2, float width, float height)
		{
			mainDrawingArea2 = context2;
			_contentHeight1 = height;
			_contentWidth1 = width; 
		}

		/// <summary>
		/// Draws background
		/// </summary>
		public void DrawBackground (){
			using (Cairo.Context surface1 = Gdk.CairoHelper.Create (mainDrawingArea2)) {

				// Background color (Created from a rectangle covering the background)
				surface1.SetSourceRGB (BgColorR, BgColorG, BgColorB);
				surface1.Rectangle (0, 0, _contentWidth1, _contentHeight1);
				surface1.Fill ();
			}
		}

		/// <summary>
		/// Finds the coordinates for the entire frame and posts it into "FrameCoordinates", followed by the posting process of surface objects, dependent on those coordinates generated.
		/// </summary>
		public void DrawFramework (){
			for (int NewCordi = 1; NewCordi < (FrameCoordinates.Length/2); NewCordi++) {

				for (int xPos = 0; xPos < frameSize; xPos++) {

					for (int yPos = 0; yPos < frameSize; yPos++) {

						// Puts a coordinate into the FrameCoordinate array

						//------- The array -------- Dimensions of drawing area -- Rows and coloums ------------------ Margin ------------------ //
						FrameCoordinates [xPos, yPos, 0] = (int)_contentWidth1 / frameSize * yPos+((int)_contentWidth1 / frameSize/2);
						FrameCoordinates [xPos, yPos, 1] = (int)_contentHeight1 / frameSize * xPos+((int)_contentHeight1 / frameSize/2);

					}
				}
			}

			//----------- Generates Widgets from widgetContainer
			graphPosition = 3;

			int CountWidgets = 0;
			int RowStart = 0;
			int RowJump = 0;
			int RowStop = 0;

			if (graphPosition == (int)SECTIONS.BOT) {		
				RowStart = 0;	
				RowJump = 0; 	
				RowStop = 1;        
				newGraph.KevinCoordinates (FrameCoordinates [3, 0, 0], FrameCoordinates [3, 0, 1]);		
			}

			if (graphPosition == (int)SECTIONS.MID) {		
				RowStart = 0;	
				RowJump = 1; 	
				RowStop = 0;
				newGraph.KevinCoordinates (FrameCoordinates [2, 0, 0], FrameCoordinates [2, 0, 1]);	
			}
			if (graphPosition == (int)SECTIONS.TOP) {		
				RowStart = 1;	
				RowJump = 0; 	
				RowStop = 0;	
				newGraph.KevinCoordinates (FrameCoordinates [1, 0, 0], FrameCoordinates [1, 0, 1]);	
			}
				

			for (int Xframes = 0; Xframes < frameSize; Xframes++) {
				for (int Yframes = 0+RowStart; Yframes < frameSize-RowStop; Yframes+=(1+RowJump)) {
					using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (mainDrawingArea2)) {
						WidgetContainer.widgetArray [CountWidgets].Draw (SurfaceWidget, FrameCoordinates [Yframes, Xframes, 0], FrameCoordinates [Yframes, Xframes, 1]);
						CountWidgets++;
					}
				}
			}
				


		}
	}
}

