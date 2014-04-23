
// This file has been generated by the GUI designer. Do not modify.
namespace AquaControl
{
	public partial class Preferences
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.Label label7;
		private global::Gtk.Entry xivelyApiKeyEntry;
		private global::Gtk.Label label8;
		private global::Gtk.Entry xivelyFeedIdEntry;
		private global::Gtk.Label label9;
		private global::Gtk.Entry impKeyEntry;
		private global::Gtk.HSeparator hseparator5;
		private global::Gtk.ToggleButton saveButton;
		private global::Gtk.Label statusLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget AquaControl.Preferences
			this.Name = "AquaControl.Preferences";
			this.Title = global::Mono.Unix.Catalog.GetString ("Window");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child AquaControl.Preferences.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(18));
			// Container child vbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Xively Api Key:");
			this.vbox3.Add (this.label7);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label7]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.xivelyApiKeyEntry = new global::Gtk.Entry ();
			this.xivelyApiKeyEntry.CanFocus = true;
			this.xivelyApiKeyEntry.Name = "xivelyApiKeyEntry";
			this.xivelyApiKeyEntry.IsEditable = true;
			this.xivelyApiKeyEntry.InvisibleChar = '●';
			this.vbox3.Add (this.xivelyApiKeyEntry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.xivelyApiKeyEntry]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Xively Feed Id:");
			this.vbox3.Add (this.label8);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label8]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.xivelyFeedIdEntry = new global::Gtk.Entry ();
			this.xivelyFeedIdEntry.CanFocus = true;
			this.xivelyFeedIdEntry.Name = "xivelyFeedIdEntry";
			this.xivelyFeedIdEntry.IsEditable = true;
			this.xivelyFeedIdEntry.InvisibleChar = '●';
			this.vbox3.Add (this.xivelyFeedIdEntry);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.xivelyFeedIdEntry]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Imp Key:");
			this.vbox3.Add (this.label9);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label9]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.impKeyEntry = new global::Gtk.Entry ();
			this.impKeyEntry.CanFocus = true;
			this.impKeyEntry.Name = "impKeyEntry";
			this.impKeyEntry.IsEditable = true;
			this.impKeyEntry.InvisibleChar = '●';
			this.vbox3.Add (this.impKeyEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.impKeyEntry]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hseparator5 = new global::Gtk.HSeparator ();
			this.hseparator5.Name = "hseparator5";
			this.vbox3.Add (this.hseparator5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hseparator5]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.saveButton = new global::Gtk.ToggleButton ();
			this.saveButton.CanFocus = true;
			this.saveButton.Name = "saveButton";
			this.saveButton.UseUnderline = true;
			this.saveButton.Label = global::Mono.Unix.Catalog.GetString ("Save");
			this.vbox3.Add (this.saveButton);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.saveButton]));
			w8.Position = 7;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.statusLabel = new global::Gtk.Label ();
			this.statusLabel.Name = "statusLabel";
			this.vbox3.Add (this.statusLabel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.statusLabel]));
			w9.Position = 8;
			w9.Expand = false;
			w9.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 297;
			this.DefaultHeight = 252;
			this.Show ();
			this.saveButton.Clicked += new global::System.EventHandler (this.OnSaveButtonClicked);
		}
	}
}
