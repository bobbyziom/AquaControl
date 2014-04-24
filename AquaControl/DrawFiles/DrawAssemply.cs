﻿using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

namespace AquaControl
{
	public class DrawAssembly {

		private float _contentHeight1;
		private float _contentWidth1;
	
		private Gdk.Window mainDrawingArea2;
		private int frameSize = 3;
		public int[,,] FrameCoordinates = new int[3,3,2];

		/// <summary>
		/// Updates data from Update Parameters and sends it to DrawAssembly
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
		/// Draws background and layout.
		/// </summary>
		public void DrawBackground (){
			using (Cairo.Context surface1 = Gdk.CairoHelper.Create (mainDrawingArea2)) {

				// takes the context and selects a color, and draws a rectangle. 
				surface1.SetSourceRGB (0.2, 0.3, 0.2);
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
					
						FrameCoordinates [xPos, yPos, 0] = (int)_contentWidth1 / frameSize * yPos+((int)_contentWidth1 / frameSize/2);
						FrameCoordinates [xPos, yPos, 1] = (int)_contentHeight1 / frameSize * xPos+((int)_contentHeight1 / frameSize/2);

						Console.WriteLine (FrameCoordinates [xPos, yPos, 0] + " " + FrameCoordinates [xPos, yPos, 1]);
					}
				}
			}
				
			for (int Yframes = 0; Yframes < frameSize; Yframes++) {
				for (int Xframes = 0; Xframes < frameSize; Xframes++) {

					using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (mainDrawingArea2)) {

						//Widget.draw (SurfaceWidget, FrameCoordinates [Yframes, Xframes, 0], FrameCoordinates [Yframes, Xframes, 1]);

						SurfaceWidget.SetSourceRGB (0.1, 0.8, 0.0);
						SurfaceWidget.Arc (FrameCoordinates [Yframes, Xframes, 0], FrameCoordinates [Yframes, Xframes, 1], 20, 0, 2 * Math.PI);
						SurfaceWidget.StrokePreserve ();
						SurfaceWidget.Fill ();
					}
				}
			}
		}
	}
}
