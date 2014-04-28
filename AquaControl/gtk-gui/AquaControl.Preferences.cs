
// This file has been generated by the GUI designer. Do not modify.
namespace AquaControl
{
	public partial class Preferences
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.Label xivelyFeedLabel;
		private global::Gtk.Entry xivelyFeedIdEntry;
		private global::Gtk.Label xivelyApiLabel;
		private global::Gtk.Entry xivelyApiKeyEntry;
		private global::Gtk.Label impKeyLabel;
		private global::Gtk.Entry impKeyEntry;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.HButtonBox hbuttonbox1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label r;
		private global::Gtk.SpinButton rEntry;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label b1;
		private global::Gtk.SpinButton gEntry;
		private global::Gtk.Button rndBtn;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label b;
		private global::Gtk.SpinButton bEntry;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Button save;
		private global::Gtk.Label statusLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget AquaControl.Preferences
			this.Name = "AquaControl.Preferences";
			this.Title = global::Mono.Unix.Catalog.GetString ("Window");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(15));
			// Container child AquaControl.Preferences.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.xivelyFeedLabel = new global::Gtk.Label ();
			this.xivelyFeedLabel.Name = "xivelyFeedLabel";
			this.xivelyFeedLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Xively Feed Id:");
			this.vbox1.Add (this.xivelyFeedLabel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.xivelyFeedLabel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.xivelyFeedIdEntry = new global::Gtk.Entry ();
			this.xivelyFeedIdEntry.CanFocus = true;
			this.xivelyFeedIdEntry.Name = "xivelyFeedIdEntry";
			this.xivelyFeedIdEntry.IsEditable = true;
			this.xivelyFeedIdEntry.InvisibleChar = '●';
			this.vbox1.Add (this.xivelyFeedIdEntry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.xivelyFeedIdEntry]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.xivelyApiLabel = new global::Gtk.Label ();
			this.xivelyApiLabel.Name = "xivelyApiLabel";
			this.xivelyApiLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Xively Api Key:");
			this.vbox1.Add (this.xivelyApiLabel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.xivelyApiLabel]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.xivelyApiKeyEntry = new global::Gtk.Entry ();
			this.xivelyApiKeyEntry.CanFocus = true;
			this.xivelyApiKeyEntry.Name = "xivelyApiKeyEntry";
			this.xivelyApiKeyEntry.IsEditable = true;
			this.xivelyApiKeyEntry.InvisibleChar = '●';
			this.vbox1.Add (this.xivelyApiKeyEntry);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.xivelyApiKeyEntry]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.impKeyLabel = new global::Gtk.Label ();
			this.impKeyLabel.Name = "impKeyLabel";
			this.impKeyLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Imp Api Key:");
			this.vbox1.Add (this.impKeyLabel);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.impKeyLabel]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.impKeyEntry = new global::Gtk.Entry ();
			this.impKeyEntry.CanFocus = true;
			this.impKeyEntry.Name = "impKeyEntry";
			this.impKeyEntry.IsEditable = true;
			this.impKeyEntry.InvisibleChar = '●';
			this.vbox1.Add (this.impKeyEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.impKeyEntry]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.vbox1.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator2]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbuttonbox1 = new global::Gtk.HButtonBox ();
			this.hbuttonbox1.Name = "hbuttonbox1";
			this.vbox1.Add (this.hbuttonbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbuttonbox1]));
			w8.Position = 7;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.r = new global::Gtk.Label ();
			this.r.Name = "r";
			this.r.LabelProp = global::Mono.Unix.Catalog.GetString ("Background R:");
			this.hbox1.Add (this.r);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.r]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.rEntry = new global::Gtk.SpinButton (0, 1, 0.01);
			this.rEntry.CanFocus = true;
			this.rEntry.Name = "rEntry";
			this.rEntry.Adjustment.PageIncrement = 10;
			this.rEntry.ClimbRate = 0.01;
			this.rEntry.Numeric = true;
			this.hbox1.Add (this.rEntry);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.rEntry]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w11.Position = 8;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.b1 = new global::Gtk.Label ();
			this.b1.Name = "b1";
			this.b1.LabelProp = global::Mono.Unix.Catalog.GetString ("Background G:");
			this.hbox2.Add (this.b1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.b1]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.gEntry = new global::Gtk.SpinButton (0, 1, 0.01);
			this.gEntry.CanFocus = true;
			this.gEntry.Name = "gEntry";
			this.gEntry.Adjustment.PageIncrement = 10;
			this.gEntry.ClimbRate = 0.01;
			this.gEntry.Numeric = true;
			this.hbox2.Add (this.gEntry);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.gEntry]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.rndBtn = new global::Gtk.Button ();
			this.rndBtn.CanFocus = true;
			this.rndBtn.Name = "rndBtn";
			this.rndBtn.UseUnderline = true;
			this.rndBtn.Label = global::Mono.Unix.Catalog.GetString ("Randomize!");
			this.hbox2.Add (this.rndBtn);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.rndBtn]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w15.Position = 9;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.b = new global::Gtk.Label ();
			this.b.Name = "b";
			this.b.LabelProp = global::Mono.Unix.Catalog.GetString ("Background B:");
			this.hbox3.Add (this.b);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.b]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.bEntry = new global::Gtk.SpinButton (0, 1, 0.01);
			this.bEntry.CanFocus = true;
			this.bEntry.Name = "bEntry";
			this.bEntry.Adjustment.PageIncrement = 10;
			this.bEntry.ClimbRate = 0.01;
			this.bEntry.Numeric = true;
			this.hbox3.Add (this.bEntry);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.bEntry]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w18.Position = 10;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator1]));
			w19.Position = 11;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.save = new global::Gtk.Button ();
			this.save.CanFocus = true;
			this.save.Name = "save";
			this.save.UseUnderline = true;
			this.save.Label = global::Mono.Unix.Catalog.GetString ("Save");
			this.vbox1.Add (this.save);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.save]));
			w20.Position = 12;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.statusLabel = new global::Gtk.Label ();
			this.statusLabel.Name = "statusLabel";
			this.vbox1.Add (this.statusLabel);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusLabel]));
			w21.Position = 13;
			w21.Expand = false;
			w21.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 408;
			this.DefaultHeight = 358;
			this.Show ();
			this.rndBtn.Clicked += new global::System.EventHandler (this.OnRndBtnClicked);
			this.save.Clicked += new global::System.EventHandler (this.OnSaveButtonClicked);
		}
	}
}
