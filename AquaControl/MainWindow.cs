using System;
using Gtk;
using Cairo;
using AquaControl;

public partial class MainWindow: Gtk.Window
{

	public string apiKey = "PCwlL9WXyvGafdpdCY9R2PhTJIwstlwv8KncOHFsTSUC7jDr";
	public string feedId = "1590545863";

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Connection.StartCheck ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

	}

	protected void OnMainDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{



	}


}
