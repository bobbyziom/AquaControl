using System;

namespace AquaControl
{
	public class TestObject : DatapointObject
	{


		public TestObject () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			X = x;
			Y = y;

			if (Connection.IsAlive) {
				surface.SetSourceRGB (0.5, 0.3, 0.2);
			} else {
				surface.SetSourceRGB (0.1, 0.1, 0.2);
			}

			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

		}
	}
}

