using System;

namespace AquaControl
{
	public class PumpWidget : BaseObject
	{

		public PumpWidget () 
		{

			Console.WriteLine ("Pumpwidget Up!");

			Radius = 100;

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;

			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.SetSourceRGBA (0.2, 1, 0.5, 0.1);
			surface.Rectangle (X-Width, Y-Height, 100, 100);
			surface.Fill ();
	


		}

		public override void OnHoverAction ()
		{

		}

		public override void OnNoHoverAction()
		{

		}

	}
}

