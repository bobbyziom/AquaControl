using System;

namespace AquaControl
{
	public class SwipeBack : BaseObject
	{

		public float SwipeBackColorR = 0.3f;
		public float SwipeBackColorG = 0.3f;
		public float SwipeBackColorB = 0.1f;

		public SwipeBack () 
		{

			Console.WriteLine ("Test Object construcT");

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			X = x;
			Y = y;
			int RectLenght = -70;
			int RectHeight = -40;

			surface.SetSourceRGB (SwipeBackColorR, SwipeBackColorG, SwipeBackColorB);
			surface.Rectangle (X+(RectLenght/2), Y-(RectHeight/2), -RectLenght, RectHeight);
			surface.Stroke ();
			surface.Fill (); 

			surface.MoveTo (X-35, Y);
			surface.LineTo (X-35, Y-50);
			surface.LineTo (X-80, Y);
			surface.LineTo (X-35, Y+50);
			surface.ClosePath ();
			surface.Stroke ();
			surface.Fill (); 



		}

		public override void OnWidgetClickActionButtomRight ()
		{
			base.OnWidgetClickActionButtomRight ();
		}

		public override void OnWidgetClickActionTopLeft ()
		{
			base.OnWidgetClickActionTopLeft ();
		}

		public override void OnWidgetClickActionTopRight ()
		{
			base.OnWidgetClickActionTopRight ();
		}

		public override void OnWidgetClickActionButtomLeft () 
		{
			base.OnWidgetClickActionButtomLeft ();
		}

		public override void OnAllClick ()
		{
			DrawAssembly.SwipeLenght = 0;
		}

		public override void OnHoverAction () 
		{

			SwipeBackColorR = 0.6f;
		}
		public override void OnNoHoverAction () 
		{

			SwipeBackColorR = 0.3f;
		}
	}
}

