using System;

namespace AquaControl
{
	public class lightIntensity:BaseObject
	{

		float lightValue;
		public float scaleFactor{ get ; set;}

		public lightIntensity ()
		{
			scaleFactor = 0.2f;
		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			double StartAngle = (1/8)*Math.PI ;
			double EndAngle = 2 * Math.PI - ((1 / 8) * Math.PI);

			lightValue = CurrentData.GetCurrentValueByIdFloat("LIGHT");

			Console.WriteLine (lightValue);

			//LIGHTBULB ALL THE WAY BABY

			surface.MoveTo (x - 100 * scaleFactor, y + 200 * scaleFactor);
			surface.LineTo (x - 100 * scaleFactor, y - 100 * scaleFactor);
			surface.Arc (x, y-100 * scaleFactor, 200 * scaleFactor, StartAngle, EndAngle);
			surface.MoveTo (x + 100 * scaleFactor, y - 100 * scaleFactor);
			surface.LineTo (x + 100 * scaleFactor, y + 200 * scaleFactor);
			surface.LineTo (x - 100 * scaleFactor, y + 200 * scaleFactor);

			surface.SetSourceRGBA (1, 1, 0, 0.20+normalizingLightValue());
			surface.Fill ();



		}

		public float normalizingLightValue(){

			return lightValue / 64000;
		}
	}
}

