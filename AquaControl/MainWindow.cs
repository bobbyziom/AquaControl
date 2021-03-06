﻿// // // // // // // // // // // // // // // // // // // // // // // // // // // // //
//																					//
//  AquaControl, a Xively and Electric Imp cross platform control application.		//
//  Copyright 2014 (c) Mads Maretty Sønderup, Kevin Ruder and Martin "Bobby" Dal.	//
//  Aalborg Univesity Copenhagen (AAU) - Medialogy B.Sc.							//						
//																					//
//	Maretty Productions (http://www.madsmaretty.dk/)								//
//	Bobby Technologies (http://bobbytechnologies.dk/)								//																				
//																					//
// // // // // // // // // // // // // // // // // // // // // // // // // // // // //
//																					//
//	Permission is hereby granted, free of charge, to any person obtaining a copy	//
//	of this software and associated documentation files (the "Software"), to deal	//
//	in the Software without restriction, including without limitation the rights	//
//	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell		//
//	copies of the Software, and to permit persons to whom the Software is			//
//	furnished to do so, subject to the following conditions:						//
//	The above copyright notice and this permission notice shall be included in		//
//	all copies or substantial portions of the Software.								//
//																					//
// // // // // // // // // // // // // // // // // // // // // // // // // // // // //
//																					//
//	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR		//
//	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,		//
//	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE		//
//	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER			//
//	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,	//
//	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN		//
//	THE SOFTWARE. 																	//
//																					//
// // // // // // // // // // // // // // // // // // // // // // // // // // // // //

using System;
using Gtk;
using Cairo;
using AquaControl;
using System.Timers;
using Gdk;

public partial class MainWindow : Gtk.Window
{

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MAIN APPLICATION VARIABLES - START OF PROGRAM								 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	private Timer MainUpdate;

	private const int MAX_WIDGETS = 16; 


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MAIN CONSTRUCTOR																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{

		// Build window
		Build ();

		// Start internet connectivity periodic check
		Connection.StartCheck ();

		// drawing framework setup
		// Input 1: Coloumns
		// Input 2: Rows
		// Input 3: Swipe Times
		DrawAssembly.Setup (4,3,1);

		// Create space for max widgets
		WidgetContainer.AssignWidgetSpace (MAX_WIDGETS);

		// Instantiate widgets from widget construct
		WidgetConstruct.ConstructWidgets ();


		// initiate user settings
		UserSettings.Initiate ();

		// starts data gathering
		CurrentData.StartDataGathering ();


		GraphContainer.CreateGraphs ();

		// Setup main update timer
		MainUpdate = new Timer (10);
		MainUpdate.Elapsed += new ElapsedEventHandler(OnUpdate);
		MainUpdate.Enabled = true;
		MainUpdate.AutoReset = true;

		// Setup events 
		mainDrawingArea.ButtonPressEvent += new ButtonPressEventHandler(HandlePress);
		mainDrawingArea.AddEvents ((int)EventMask.AllEventsMask);

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// WIDGET DRAING AREA EXPOSE EVENT												 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnMainDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{

		DrawAssembly.UpdateDrawingContext (mainDrawingArea.GdkWindow, this.Allocation.Width, this.Allocation.Height);
		DrawAssembly.DrawBackground (UserSettings.BgColorR, UserSettings.BgColorG, UserSettings.BgColorB);
		DrawAssembly.DrawFramework (); 

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// TIMER UPDATE EVENT															 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnUpdate(object source, ElapsedEventArgs e)
	{
	
		mainDrawingArea.QueueDraw ();

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MOUSE CLICK HANDLER															 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void HandlePress (object o, ButtonPressEventArgs args)
	{

		WidgetContainer.CheckAllWidgetHover (args.Event.X, args.Event.Y, true);

	}
		

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// UPDATE MOUSE POSITION														 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnMainDrawingAreaMotionNotifyEvent (object o, MotionNotifyEventArgs args)
	{

		WidgetContainer.CheckAllWidgetHover (args.Event.X, args.Event.Y, false);

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// CLOSE APP EVENT																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{

		UserSettings.Save ();
		Application.Quit ();
		a.RetVal = true;

	}

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// END OF PROGRAM																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 

}
