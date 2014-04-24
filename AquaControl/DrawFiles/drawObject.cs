using System;
using Gtk;
using Cairo;
using Gdk;
using AquaControl;

namespace AquaControl
{
	public class DrawObject
	{
		public void _drawObject (Context importedDrawingArea) {

			// This will be initiated in background.cs
			importedDrawingArea.SetSourceRGB (0.1, 0.8, 0.0);
			importedDrawingArea.Arc (0, 0, 50, 0, 2 * Math.PI);
			importedDrawingArea.StrokePreserve ();
			importedDrawingArea.Fill ();

		}
	}
}

