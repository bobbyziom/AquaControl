using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

namespace AquaControl {
	public class UpdateParameters {

		private float _contentHeight;
		private float _contentWidth;
		private Gdk.Window mainDrawingArea;

		public void UpdateContext (Gdk.Window context, float width, float height, ref DrawAssembly drawingAssembly) {
			mainDrawingArea = context;
			_contentHeight = height;
			_contentWidth = width; 

			drawingAssembly = new DrawAssembly ();
			drawingAssembly.UpdateDrawingContext (mainDrawingArea, _contentWidth, _contentHeight);


			}
	}
}

