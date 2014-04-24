using System;

namespace AquaControl
{
	public class PHWidget : DatapointObject
	{

		float fadecolor = 0;
		string phTextShow = "PH";
		int textMoveX;
		int textMoveY;
		float PHValue = 3.0f;
		float PHcolorR = 0;
		float PHcolorB = 0;

		public PHWidget () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;
		
			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.CurveTo(X-100, Y-10, X-60, Y+10, X-30, Y-10);
			surface.CurveTo(X-30, Y-10, X, Y+10, X+30, Y-10);
			surface.CurveTo(X+30, Y-10, X+60, Y+10, X+100, Y-10);
			surface.SetSourceRGB (0.1, 0.1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();

			//XivelyData data = XivelyData.GetCurrentData (apiKey, feedId);

			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.MoveTo (X+textMoveX, Y+textMoveY);
			surface.SetFontSize (80);
			surface.ShowText (phTextShow);

			//surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill();

			surface.CurveTo(X-100, Y-10, X-60, Y+10, X-30, Y-10);
			surface.CurveTo(X-30, Y-10, X, Y+10, X+30, Y-10);
			surface.CurveTo(X+30, Y-10, X+60, Y+10, X+100, Y-10);
			surface.SetSourceRGBA (PHcolorR, 0, PHcolorB, fadecolor);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();


		}

		public override void OnHoverAction ()
		{
			// MOVE TO ALIGN NUMBER
			if (PHValue < 10) {
				textMoveX = -22;
				textMoveY = 30;
			} else{
				textMoveX = -48;
				textMoveY = 30;
			}

			// SPECIFIC COLOR	
			PHcolorR = 1-(PHValue/7);
			PHcolorB = PHValue/7-1;	

			// FADE IN
			if (fadecolor < 0.3) {	
				fadecolor += 0.01f; 
				phTextShow =  Convert.ToString(PHValue);
			}

		}

		public override void OnNoHoverAction()
		{
			if (fadecolor > 0) {
				fadecolor -= 0.005f;
			} else {
			
			}

			phTextShow = "PH";
			textMoveX = -55;
			textMoveY = 30;


		}

	}
}

