using System;
using Gtk;
using Cairo;
using AquaControl;
using System.Timers;
using Gdk;


public partial class MainWindow: Gtk.Window
{

	DrawAssembly _DrawingAssembly;

	private bool _clicked = false;
	private double _cursorX;
	private double _cursorY;

	private Timer _updater;

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



	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{

		Application.Quit ();
		a.RetVal = true;

	}



	protected void OnMainDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{

		UpdateParameters.UpdateContext (mainDrawingArea.GdkWindow, this.Allocation.Width, this.Allocation.Height, ref _DrawingAssembly);

		_DrawingAssembly.DrawBackground ();
		_DrawingAssembly.DrawFramework (); 

	}



	protected void OnUpdate(object source, ElapsedEventArgs e)
	{
	
		mainDrawingArea.QueueDraw ();

		WidgetContainer.CheckAllWidgetHover (_cursorX, _cursorY, ref _clicked);

	}



	protected void HandlePress (object o, ButtonPressEventArgs args)
	{

		_clicked = true;


	}
		


	protected void OnMainDrawingAreaMotionNotifyEvent (object o, MotionNotifyEventArgs args)
	{

		_cursorX = args.Event.X;
		_cursorY = args.Event.Y;

		_clicked = false;

		//Console.WriteLine ("X pos: " + _cursorX);
		//Console.WriteLine ("Y pos: " + _cursorY);

	}



}
