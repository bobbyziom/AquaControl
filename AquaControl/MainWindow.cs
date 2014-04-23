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

		new Preferences ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

	}

	protected void OnMainDrawingAreaExposeEvent (object o, ExposeEventArgs args)
	{
		Cairo.Context surface = Gdk.CairoHelper.Create (mainDrawingArea.GdkWindow);

		surface.SetSourceRGB (0.1,0.1,0.1);
		surface.Rectangle (0, 0, Allocation.Width, Allocation.Height);
		surface.Fill ();


		//surface.Arc (Allocation.Width / 2, Allocation.Height / 2, Allocation.Width / 2, Math.PI, Math.PI * 2);
		//surface.Stroke ();



	}


}
