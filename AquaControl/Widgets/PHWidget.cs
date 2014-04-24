using System;

namespace AquaControl
{
	public class PHWidget : DatapointObject
	{


		public PHWidget () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;
		
			surface.CurveTo(X-100, Y-10, X-60, Y+10, X-30, Y-10);
			surface.CurveTo(X-30, Y-10, X, Y+10, X+30, Y-10);
			surface.CurveTo(X+30, Y-10, X+60, Y+10, X+100, Y-10);
			surface.SetSourceRGB (0.1, 0.1, 0.2);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();

			surface.SetSourceRGBA (1, 1, 1, 0.3);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.CurveTo (X - 100, Y, X, Y+100, X + 100, Y);
			surface.Fill ();

			//XivelyData data = XivelyData.GetCurrentData (apiKey, feedId);

			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.MoveTo (X-32, Y+50);
			surface.SetFontSize (50);
			surface.ShowText ("PH");

			//surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill();


		}

	}
}

