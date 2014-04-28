using System;

namespace AquaControl
{
	public class PHWidget : BaseObject
	{

		float PHValue = 3.0f;
		float[] colorWater = new float[3];
		float alphaChannel = 0.8f;

		public PHWidget () 
		{

			Console.WriteLine ("Test Object construcT");

			X = 300;
			colorWater[0] = 0.6f;
			colorWater[1] = 0.6f;
			colorWater[2] = 0.6f;

		}

		public override void Draw (Cairo.Context surface, int x, int y){

			Radius = 100;
			X = x;
			Y = y;
			int barHeight = Radius / 2;
			//int barLength = Radius + (Radius / 2);
			int sectionSize = Radius / 5;
			int pushLength = sectionSize+1;
			int amountOfSections = 8;

			PHValue = CurrentData.GetCurrentValueByIdFloat("ph");

			// CIRCLE
			surface.SetSourceRGBA (1, 1, 1, 0.1);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			// WAVEFORMED CIRCLE
			surface.SetSourceRGB (0.8, 0.0, 0.0);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.6, 0.0, 0.0);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.4, 0.0, 0.0);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*2), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.2, 0.0, 0.0);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*3), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.0, 0.0, 0.2);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*4), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.0, 0.0, 0.4);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*5), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.0, 0.0, 0.6);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*6), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.0, 0.0, 0.8);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*7), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			// TEXT
			surface.SetSourceRGBA (1, 1, 1, 0.5);
			surface.MoveTo (X, Y);
			surface.SetFontSize (Radius/2);
			string widgetText = Convert.ToString(PHValue);
			Cairo.TextExtents text = surface.TextExtents (widgetText);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2)-barHeight);
			surface.ShowText (widgetText);
			surface.Fill();

			surface.SetSourceRGB (1, 1, 1);
			surface.Rectangle (X-(text.Width/2), Y-barHeight/2, 20, 50);
			surface.Stroke ();
			surface.Fill ();



		}

		public override void OnHoverAction ()
		{
		

		}

		public override void OnNoHoverAction()
		{

		}

	}
}

