using System;

namespace AquaControl
{
	public class WaterTemp : BaseObject
	{
	
		float WaterTemperature = 15.0f;
		float[] colorWater = new float[3];
		float alphaChannel = 0.0f;
		private const string XIVELY_DATA_STREAM_ID = "AIR_TEMPERATURE";

		public WaterTemp () 
		{

			Console.WriteLine ("Test Object construcT");

			X = 300;
			colorWater[0] = 0.2f;
			colorWater[1] = 0.2f;
			colorWater[2] = 0.2f;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;
			int waveTops = Radius / 3;
			int waveBottoms = Radius / 2;
			int waveDepths = Radius / 6;

			WaterTemperature = CurrentData.GetCurrentValueByIdFloat (XIVELY_DATA_STREAM_ID);
			WaterTemperature = WaterTemperature / 100;


			// CIRCLE
			surface.SetSourceRGBA (1, 1, 1, 0.3);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();
			surface.Fill ();

			// WAVEFORMED CIRCLE
			surface.CurveTo(X-Radius, Y-waveDepths, X-waveBottoms, Y+waveDepths, X-waveTops, Y-waveDepths);
			surface.CurveTo(X-waveTops, Y-waveDepths, X, Y+waveDepths, X+waveTops, Y-waveDepths);
			surface.CurveTo(X+waveTops, Y-waveDepths, X+waveBottoms, Y+waveDepths, X+Radius, Y-waveDepths);
			surface.SetSourceRGBA (colorWater[0], colorWater[1], colorWater[2], alphaChannel);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();

			// TEXT
			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.MoveTo (X, Y);
			surface.SetFontSize (Radius/2);
			string widgetText = Convert.ToString(WaterTemperature);
			Cairo.TextExtents text = surface.TextExtents (widgetText);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));
			surface.ShowText (widgetText);
			surface.Fill();

		}

		public override void OnHoverAction ()
		{
			// SPECIFIC COLOR	
			if (WaterTemperature > 20.0f) {
				colorWater [0] = 0.6f;
				colorWater [1] = 0.0f;
				colorWater [2] = 0.0f;
			} else {
				colorWater[0] = 0.0f;
				colorWater[1] = 0.0f;
				colorWater[2] = 0.6f;
			}

			if (alphaChannel < 0.8f) {
				alphaChannel += 0.1f;
			}
		}

		public override void OnNoHoverAction()
		{
			if (alphaChannel > 0.0f) {
				alphaChannel -= 0.1f;
			}
		}

	}
}

