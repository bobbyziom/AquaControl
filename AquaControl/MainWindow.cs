using System;
using Gtk;
using AquaControl;

public partial class MainWindow: Gtk.Window
{

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnPrefButtonClicked (object sender, EventArgs e)
	{
		new Preferences ();
	}

	protected void OnImpSendButtonClicked (object sender, EventArgs e)
	{
		ImpCommunication imp = new ImpCommunication ();

		imp.Send (keyEntry.Text, valueEntry.Text);

	}
}
