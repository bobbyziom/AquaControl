using System;

namespace AquaControl
{
	public class Swipe : BaseObject
	{

		public Swipe () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;
			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;

			surface.SetSourceRGBA (0, 1, 0, 0.5);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill (); 
		}

		public override void OnWidgetClickActionButtomLeft () {
			if (DrawAssembly.ContentWidth > DrawAssembly._SwipeLenght) {
				DrawAssembly._SwipeLenght = DrawAssembly.ContentWidth;
			} 
		}
	}
}

