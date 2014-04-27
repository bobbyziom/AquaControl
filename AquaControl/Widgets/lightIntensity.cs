using System;
using Cairo;

namespace AquaControl
{
	public class lightIntensity:BaseObject
	{

		float lightValue;
		public float scaleFactor{ get ; set;}
		private string widgetText;
		private TextExtents text;
		private bool _showText;


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

			if (_showText == true) {

				widgetText = lightValue+"";
				surface.SetFontSize (13);
				text = surface.TextExtents (widgetText);

				surface.SetSourceRGBA (0.98f, 0.5f, 0.4f, Alpha);
				surface.MoveTo(X - (text.Width/2), Y + (text.Height/2) + 15);

				surface.ShowText (widgetText);

			}

		}

		public float normalizingLightValue(){

			return lightValue / 64000;
		}

		public override void OnHoverAction ()
		{
			_showText = true;
		}

		public override void OnNoHoverAction ()
		{
			_showText = false;
		}
	}
}

