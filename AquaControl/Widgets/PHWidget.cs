﻿using System;

namespace AquaControl
{
	public class PHWidget : BaseObject
	{

		float PHValue = 3.0f;
		float[] colorWater = new float[3];
		float alphaChannel = 0.0f;

		public PHWidget () 
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


			PHValue = CurrentData.GetCurrentValueByIdFloat("ph");

			// CIRCLE
			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
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
			string widgetText = Convert.ToString("PH");
			Cairo.TextExtents text = surface.TextExtents (widgetText);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));
			surface.ShowText (widgetText);
			surface.Fill();

		}

		public override void OnHoverAction ()
		{

		}

		public override void OnNoHoverAction()
		{

		}

	}
}

