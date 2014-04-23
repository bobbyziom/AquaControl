
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox5;
	private global::Gtk.Label label11;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Entry keyEntry;
	private global::Gtk.Entry valueEntry;
	private global::Gtk.Button impSendButton;
	private global::Gtk.HSeparator hseparator8;
	private global::Gtk.Button prefButton;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(9));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox5 = new global::Gtk.VBox ();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		this.vbox5.BorderWidth = ((uint)(15));
		// Container child vbox5.Gtk.Box+BoxChild
		this.label11 = new global::Gtk.Label ();
		this.label11.Name = "label11";
		this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Direct API [key] [value]:");
		this.vbox5.Add (this.label11);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.label11]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.keyEntry = new global::Gtk.Entry ();
		this.keyEntry.CanFocus = true;
		this.keyEntry.Name = "keyEntry";
		this.keyEntry.IsEditable = true;
		this.keyEntry.InvisibleChar = '●';
		this.hbox1.Add (this.keyEntry);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.keyEntry]));
		w2.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.valueEntry = new global::Gtk.Entry ();
		this.valueEntry.CanFocus = true;
		this.valueEntry.Name = "valueEntry";
		this.valueEntry.IsEditable = true;
		this.valueEntry.InvisibleChar = '●';
		this.hbox1.Add (this.valueEntry);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.valueEntry]));
		w3.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.impSendButton = new global::Gtk.Button ();
		this.impSendButton.CanFocus = true;
		this.impSendButton.Name = "impSendButton";
		this.impSendButton.UseUnderline = true;
		this.impSendButton.Label = global::Mono.Unix.Catalog.GetString ("Send");
		this.hbox1.Add (this.impSendButton);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.impSendButton]));
		w4.Position = 2;
		w4.Expand = false;
		w4.Fill = false;
		this.vbox5.Add (this.hbox1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox1]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hseparator8 = new global::Gtk.HSeparator ();
		this.hseparator8.Name = "hseparator8";
		this.vbox5.Add (this.hseparator8);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hseparator8]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.prefButton = new global::Gtk.Button ();
		this.prefButton.CanFocus = true;
		this.prefButton.Name = "prefButton";
		this.prefButton.UseUnderline = true;
		this.prefButton.Label = global::Mono.Unix.Catalog.GetString ("Preferences");
		this.vbox5.Add (this.prefButton);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.prefButton]));
		w7.Position = 3;
		w7.Expand = false;
		w7.Fill = false;
		this.Add (this.vbox5);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 422;
		this.DefaultHeight = 146;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.impSendButton.Clicked += new global::System.EventHandler (this.OnImpSendButtonClicked);
		this.prefButton.Clicked += new global::System.EventHandler (this.OnPrefButtonClicked);
	}
}
