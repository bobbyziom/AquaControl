﻿using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

// 
enum SECTIONS {BOT = 0, MID = 1, TOP = 2};

namespace AquaControl
{
	public static class DrawAssembly {

		// FRAME GENERATION
		private const int _coordinatesNum = 2;
		private static int[,,] _frameCoordinates;
		private static int _frameWidth;
		private static int _frameHeight;
		private static int RowStart = 0;
		private static int RowJump = 0;
		private static int RowStop = 0;
		private static int Putgraph = 0;
		private static int CountWidgets = 0;

		/// <summary>
		/// Gets or sets the lenght of swipe.
		/// </summary>
		/// <value>The _ swipe lenght.</value>
		public static float SwipeLength { get; set; }

		/// <summary>
		/// Gets or sets the _ swipe margin.
		/// </summary>
		/// <value>The _ swipe margin.</value>
		public static float SwipeMargin { get; set; }

		/// <summary>
		/// Gets or sets the GlobalRadius
		/// </summary>
		/// <value>The swipe margin.</value>
		public static int GlobalRadius { get; set; }

		/// <summary>
		/// Gets or sets the times able to swipe.
		/// </summary>
		/// <value>The swipe amount.</value>
		public static float SwipeAmount { get; set; }

		/// <summary>
		/// Gets or sets the content heigth.
		/// </summary>
		/// <value>The content heigth.</value>
		public static float ContentHeight { get; set; }

		/// <summary>
		/// Gets or sets the width of the content.
		/// </summary>
		/// <value>The width of the content.</value>
		public static float ContentWidth { get; set;}

		/// <summary>
		/// Gets or sets the LEFT margin of the entire frame setup.
		/// </summary>
		/// <value>The frame area margin.</value>
		public static int FrameAreaMarginLEFT { get; set; }

		/// <summary>
		/// Gets or sets the TOP margin of the entire frame setup.
		/// </summary>
		/// <value>The frame area margin.</value>
		public static int FrameAreaMarginTOP { get; set; }

		/// <summary>
		/// The area height of one frame
		/// </summary>
		/// <value>The height of the frame area.</value>
		public static int FrameAreaHeight { get; set; }

		/// <summary>
		/// The area width of one frame
		/// </summary>
		/// <value>The height of the frame area.</value>
		public static int FrameAreaWidth { get; set; }

		/// <summary>
		/// Gets or sets the widget margin TO.
		/// </summary>
		/// <value>The widget margin TO.</value>
		public static int WidgetMarginTOP { get; set; }

		/// <summary>
		/// Gets or sets the widget margin LEF.
		/// </summary>
		/// <value>The widget margin LEF.</value>
		public static int WidgetMarginLEFT { get; set; }

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
		public static void Setup(int frameSize, int frameHeigh, int SwipeAmountSend) {
			SwipeLength = 0;
			SwipeAmount = SwipeAmountSend;
			_frameWidth = frameSize;
			_frameHeight = frameHeigh;
			GlobalRadius = 50;
			GraphPosition = (int)SECTIONS.BOT;
			_frameCoordinates = new int[_frameHeight,_frameWidth,_coordinatesNum];
		}

		/// <summary>
		/// Updates the drawing context.
		/// </summary>
		/// <param name="context2">Context2.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public static void UpdateDrawingContext(Gdk.Window context2, float width, float height) {
			MainDrawingArea = context2;
			ContentHeight = height;
			ContentWidth = width; 
			FrameAreaWidth = (int)ContentWidth;
			FrameAreaHeight = (int)ContentHeight / _frameHeight;
			FrameAreaMarginLEFT = ((int)ContentWidth / _frameWidth/2);
			FrameAreaMarginTOP = ((int)ContentHeight / _frameWidth /2);
			WidgetMarginTOP = (int)FrameAreaMarginTOP - (int)GlobalRadius;
			WidgetMarginLEFT = (int)FrameAreaMarginLEFT - (int)GlobalRadius;
		}

		/// <summary>
		/// Framework for drawing Widgets, Graph and setting coordinates
		/// </summary>
		public static void DrawFramework ()
		{
			// Sets the coordinates
			SetCoordinates ();
		
			// Draws widgets and graph
			DrawElements ();

		}

		/// <summary>
		/// Sets the coordinates.
		/// </summary>
		public static void SetCoordinates ()
		{
			for (int NewCordi = 1; NewCordi < (_frameCoordinates.Length/2); NewCordi++) {

				for (int xPos = 0; xPos < _frameHeight; xPos++) {

					for (int yPos = 0; yPos < _frameWidth; yPos++) {

						// Puts a coordinate into the FrameCoordinate array

						_frameCoordinates [xPos, yPos, 0] = (int)ContentWidth / _frameWidth * yPos + FrameAreaMarginLEFT;
						_frameCoordinates [xPos, yPos, 1] = (int)ContentHeight / _frameHeight  * xPos + FrameAreaMarginTOP;
					}
				}
			}
		}

		public static void DrawElements (){

			SetGraphPosition (2);
			CountWidgets = 0;

			// SWIPE TIMES
			for(int swipes = 0; swipes != SwipeAmount+1; swipes++){

				// LOOP FOR WIDGETS
				DrawWidgets (swipes);

				// GENERATING GRAPH
				DrawGraphArea ();
				SwipeMargin = -ContentWidth;
			}
		}


		/// <summary>
		/// Draws the widgets.
		/// </summary>
		/// <param name="swipes">Swipes.</param>
		public static void DrawWidgets (int swipes){

			for (int Xframes = 0; Xframes < _frameWidth; Xframes++) {
				for (int Yframes = 0 + RowStart; Yframes < _frameHeight-RowStop; Yframes += (1+RowJump)) {

					using (Cairo.Context SurfaceWidget = Gdk.CairoHelper.Create (MainDrawingArea)) {

						WidgetContainer.widgetArray [CountWidgets].Draw (SurfaceWidget, _frameCoordinates [Yframes, Xframes, 0]+(int)SwipeLength+((int)SwipeMargin*swipes), _frameCoordinates [Yframes, Xframes, 1]);
						CountWidgets++;
					}
				}
			}

		}

		/// <summary>
		/// Draws the graph area.
		/// </summary>
		public static void DrawGraphArea ()
		{
			using (Cairo.Context SurfaceGraph = Gdk.CairoHelper.Create (MainDrawingArea)) {
				for (int i = 0; i < GraphContainer.TotalGraphCount; i++) {
					GraphContainer.GraphBucket [i].Draw (SurfaceGraph,  _frameCoordinates [Putgraph, 1, 0], _frameCoordinates [Putgraph, 1, 1]); 
				}
			}

		}

		/// <summary>
		/// Sets the graph position.
		/// </summary>
		/// <param name="GAmount">G amount.</param>
		public static void SetGraphPosition (int GAmount){
		
			//----------- Generates Widgets from widgetContainer
			GraphPosition = GAmount;

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
		}

		/// <summary>
		/// Draws background
		/// </summary>
		public static void DrawBackground (float r, float g, float b)
		{
			using (Cairo.Context surface1 = Gdk.CairoHelper.Create (MainDrawingArea)) {
				// Background color (Created from a rectangle covering the background)
				surface1.SetSourceRGB (r, g, b);
				surface1.Rectangle (0, 0, ContentWidth, ContentHeight);
				surface1.Fill ();
			}

		}

	}
}

