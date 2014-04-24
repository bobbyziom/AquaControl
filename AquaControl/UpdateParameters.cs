using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

namespace AquaControl {

	public static class UpdateParameters {

		private static float _contentHeight;
		private static float _contentWidth;
		private static Gdk.Window mainDrawingArea;

		public static void UpdateContext (Gdk.Window context, float width, float height, ref DrawAssembly drawingAssembly) 
		{

			mainDrawingArea = context;
			_contentHeight = height;
			_contentWidth = width; 

			drawingAssembly = new DrawAssembly ();
			drawingAssembly.UpdateDrawingContext (mainDrawingArea, _contentWidth, _contentHeight);

		}
	}
}

