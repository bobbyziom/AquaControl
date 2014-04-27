﻿using System;

namespace AquaControl
{
	public class PumpWidget : BaseObject
	{

		public PumpWidget () 
		{

			Console.WriteLine ("Pumpwidget Up!");

			Radius = 50;

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			X = x;
			Y = y;
			int rectSideWidth = Radius/20;
			int rectSideLenght = Radius;
			int pumphead = Radius / 5;


			surface.SetSourceRGB (0.3, 0.3, 0.3);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.SetSourceRGB (0.5, 0.5, 0.5);
			surface.Rectangle (X-(Radius/2), Y-(Radius/2), rectSideLenght, rectSideLenght); 				// Middle
			surface.Fill ();

			surface.SetSourceRGB (0, 0, 0);
			surface.Rectangle (X-(Radius/2), Y-(Radius/2), rectSideWidth, rectSideLenght); 					// Left
			surface.Rectangle (X+(Radius/2)-rectSideWidth, Y-(Radius/2), rectSideWidth, rectSideLenght); 	// Right
			surface.Rectangle (X-(Radius/2), Y-(Radius/2), rectSideLenght, rectSideWidth); 					// Top
			surface.Rectangle (X-(Radius/2), Y+(Radius/2)-rectSideWidth, rectSideLenght, rectSideWidth); 	// Bottom
			surface.Fill ();

			surface.Rectangle (X-(Radius/2)-pumphead, Y, pumphead, pumphead);
			surface.Fill ();

			surface.SetSourceRGB (0.5, 0.5, 0.5);
			surface.Rectangle (X-(Radius/2)-pumphead, Y+(pumphead/2/2), (pumphead*2), (pumphead/2));
			surface.Fill ();

			surface.SetSourceRGB (0, 0, 0);
			surface.Rectangle (X, Y-(Radius/2)-pumphead, pumphead, pumphead);
			surface.Fill ();

			surface.SetSourceRGB (0.5, 0.5, 0.5);
			surface.Rectangle (X+(pumphead/2/2), Y-(Radius/2)-(pumphead), (pumphead/2), (pumphead*2));
			surface.Fill ();


			// - ON / OFF
			surface.SetSourceRGB (0.1, 0.1, 0.1);
			surface.Arc (X+Radius/4, Y+Radius/4, Radius/10, 0, Math.PI * 2);
			surface.Stroke ();
			surface.SetSourceRGB (0, 0.5, 0);
			surface.Arc (X+Radius/4, Y+Radius/4, Radius/10, 0, Math.PI * 2);
			surface.Fill ();

		}
			
	}
}

