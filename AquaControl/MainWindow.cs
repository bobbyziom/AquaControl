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

public partial class MainWindow: Gtk.Window
{

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MAIN APPLICATION VARIABLES - START OF PROGRAM								 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	DrawAssembly _DrawingAssembly;

	private bool _clicked = false;
	private double _cursorX;
	private double _cursorY;

	private Timer _updater;


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MAIN CONSTRUCTOR																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{

		Build ();

		_DrawingAssembly = new DrawAssembly ();

		// Start internet connectivity periodic check
		Connection.StartCheck ();

		// Create widgets
		WidgetContainer.AssignWidgetSpace (6);
		WidgetConstruct.ConstructWidgets ();

		// initiate user settings
		UserSettings.Initiate ();

		// starts data gathering
		CurrentData.StartDataGathering ();

		// Setup main update timer
		_updater = new Timer (10);
		_updater.Elapsed += new ElapsedEventHandler(OnUpdate);
		_updater.Enabled = true;
		_updater.AutoReset = true;

		// Setup events 
		mainDrawingArea.ButtonPressEvent += new ButtonPressEventHandler(HandlePress);
		mainDrawingArea.AddEvents ((int)EventMask.AllEventsMask);

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// WIDGET DRAING AREA EXPOSE EVENT												 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnMainDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{

		UpdateParameters.UpdateContext (mainDrawingArea.GdkWindow, this.Allocation.Width, this.Allocation.Height, ref _DrawingAssembly);

		_DrawingAssembly.DrawBackground ();
		_DrawingAssembly.DrawFramework (); 

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// TIMER UPDATE EVENT															 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnUpdate(object source, ElapsedEventArgs e)
	{
	
		mainDrawingArea.QueueDraw ();

		WidgetContainer.CheckAllWidgetHover (_cursorX, _cursorY, ref _clicked);

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// MOUSE CLICK HANDLER															 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void HandlePress (object o, ButtonPressEventArgs args)
	{

		_clicked = true;

	}
		

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// WIDGET DRAING AREA MOTION NOTIFY EVENT										 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnMainDrawingAreaMotionNotifyEvent (object o, MotionNotifyEventArgs args)
	{

		_cursorX = args.Event.X;
		_cursorY = args.Event.Y;

		_clicked = false;

		//Console.WriteLine ("X pos: " + _cursorX);
		//Console.WriteLine ("Y pos: " + _cursorY);

	}


	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// CLOSE APP EVENT																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{

		Application.Quit ();
		a.RetVal = true;

	}

	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 
	// END OF PROGRAM																 //
	// // // // // // // // // // // // // // // // // // // // // // // // // // // // 

}
