using System;
using Cairo;

namespace AquaControl
{
	public class lightIntensity:BaseObject
	{

		float lightValue;
		public float scaleFactor{ get ; set;}
		private Context lightSurface;
		private string widgetText;
		private TextExtents text;
		private bool _showtext;


		public lightIntensity ()
		{
			scaleFactor = 0.2f;
			_showtext = false;


		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{
			X = x;
			Y = y;

			lightSurface = surface;

			double StartAngle = (1/8)*Math.PI ;
			double EndAngle = 2 * Math.PI - ((1 / 8) * Math.PI);
			string valueText = lightValue + "%";

			lightValue = CurrentData.GetCurrentValueByIdFloat("LIGHT");

			Console.WriteLine (lightValue);

			//LIGHTBULB ALL THE WAY BABY

			lightSurface.MoveTo (X - 100 * scaleFactor, Y + 200 * scaleFactor);
			lightSurface.LineTo (X - 100 * scaleFactor, Y - 100 * scaleFactor);
			lightSurface.Arc (X, Y-100 * scaleFactor, 200 * scaleFactor, StartAngle, EndAngle);
			lightSurface.MoveTo (X + 100 * scaleFactor, Y - 100 * scaleFactor);
			lightSurface.LineTo (X + 100 * scaleFactor, Y + 200 * scaleFactor);
			lightSurface.LineTo (X - 100 * scaleFactor, Y + 200 * scaleFactor);

			lightSurface.SetSourceRGBA (1, 1, 0, 0.20+normalizingLightValue());
			lightSurface.Fill ();

			if (_showtext == true) {
				widgetText = lightValue + "";

				lightSurface.SetFontSize (13);
				text = surface.TextExtents (widgetText);

				lightSurface.SetSourceRGBA (0.98f, 0.5f, 0.4f, Alpha);
				lightSurface.MoveTo (X - (text.Width / 2), Y + (text.Height / 2) + 15);
				lightSurface.ShowText (widgetText);
			}
				

		}

		public float normalizingLightValue(){

			return lightValue / 64000;
		}

		public override void OnHoverAction ()
		{
			_showtext = true;
		}
		public override void OnNoHoverAction ()
		{
			_showtext = false;
		}

	
	}
}

