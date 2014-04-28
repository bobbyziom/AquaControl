using System;

namespace AquaControl
{
	public class Swipe : BaseObject
	{

		public float SwipeColorR = 0.3f;
		public float SwipeColorG = 0.3f;
		public float SwipeColorB = 0.1f;

		public Swipe () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;
			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;
			int RectLenght = -70;
			int RectHeight = -40;

			surface.SetSourceRGB (SwipeColorR, SwipeColorG, SwipeColorB);
			surface.Rectangle (X+(RectLenght/2), Y-(RectHeight/2), -RectLenght, RectHeight);
			surface.Stroke ();
			surface.Fill (); 

			surface.MoveTo (X+35, Y);
			surface.LineTo (X+35, Y-50);
			surface.LineTo (X+80, Y);
			surface.LineTo (X+35, Y+50);
			surface.ClosePath ();
			surface.Stroke ();
			surface.Fill (); 


		}

		public override void OnWidgetClickActionButtomLeft () {
			if (DrawAssembly.ContentWidth > DrawAssembly._SwipeLenght) {
				DrawAssembly._SwipeLenght += DrawAssembly.ContentWidth;
			} 
		}
		public override void OnHoverAction () {

			SwipeColorR = 0.6f;
		}
		public override void OnNoHoverAction () {

			SwipeColorR = 0.3f;
		}

	}
}

