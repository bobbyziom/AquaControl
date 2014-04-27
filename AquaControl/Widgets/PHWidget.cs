using System;

namespace AquaControl
{
	public class PHWidget : BaseObject
	{
	
		float PHValue = 3.0f;
		float WaterTemp = 0.0f;
		float[] colorWater = new float[3];
		float _alphaChannel = 0.2f;
		float topBottomDifference = 0.4f;

		public PHWidget () 
		{

			Console.WriteLine ("Test Object construcT");

			Radius = 100;
			X = 300;
			colorWater[0] = 0.6f;
			colorWater[1] = 0.6f;
			colorWater[2] = 0.6f;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;

			PHValue = CurrentData.GetCurrentValueByIdFloat("ph");
			WaterTemp = CurrentData.GetCurrentValueByIdFloat("temp");
		
			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.CurveTo(X-100, Y-10, X-60, Y+10, X-30, Y-10);
			surface.CurveTo(X-30, Y-10, X, Y+10, X+30, Y-10);
			surface.CurveTo(X+30, Y-10, X+60, Y+10, X+100, Y-10);
			surface.SetSourceRGB (0.1, 0.1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();

			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.MoveTo (X, Y);

			surface.SetFontSize (50);
			string widgetText = "TEMP";
			Cairo.TextExtents text = surface.TextExtents (widgetText);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));
			surface.ShowText (widgetText);

			surface.Fill();

			surface.CurveTo(X-100, Y-10, X-60, Y+10, X-30, Y-10);
			surface.CurveTo(X-30, Y-10, X, Y+10, X+30, Y-10);
			surface.CurveTo(X+30, Y-10, X+60, Y+10, X+100, Y-10);
			surface.SetSourceRGBA (colorWater[0], colorWater[1], colorWater[2], _alphaChannel);
			surface.Arc (X, Y, Radius, 0, Math.PI * 1);
			surface.Fill ();

		}

		public override void OnHoverAction ()
		{
			// MOVE TO ALIGN NUMBER
			//if (WaterTemp < 20) {

				//} else{

				//}
				
			// SPECIFIC COLOR	

			//PHcolorR = WaterTemp/40;
			//PHcolorB = WaterTemp/40;	

			// FADE IN
			if (_alphaChannel < 0.6) {	
				_alphaChannel += 0.01f; 
				//phTextShow =  Convert.ToString(WaterTemp/100);
			}

		}

		public override void OnNoHoverAction()
		{
			if (_alphaChannel > 0) {
				_alphaChannel -= 0.01f;
			} else {
			
			}

			//phTextShow = "";
			//textMoveX = -55;
			//textMoveY = 30;

		}

	}
}

