using System;

namespace AquaControl
{
	public class graphDot : BaseObject
	{
		public double _dataValue{ get; set;}

		public graphDot ()
		{

			Radius = 2;


		}

		public override void Draw (Cairo.Context surface, int PositionX, int PositionY)
		{
			X = PositionX;
			Y = PositionY;

			surface.SetSourceRGBA (R, G, B, 0.4);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Stroke ();
		}
		public override void OnHoverAction ()
		{
			Console.WriteLine ("HOVERING ABOVE DATA POINT");
		}
	}
}

