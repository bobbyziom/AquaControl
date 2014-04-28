using System;

namespace AquaControl
{
	public class PHWidget : BaseObject
	{

		float PHValue = 7.0f;
		private const string XIVELY_DATA_STREAM_ID = "HUMIDITY"; // NEEDS TO BE CHANGED

		public PHWidget () 
		{

			Console.WriteLine ("Test Object construcT");

			X = 300;

		}

		public override void Draw (Cairo.Context surface, int x, int y){
		
			//PHValue = CurrentData.GetCurrentValueByIdFloat("ph");

			PHValue = CurrentData.GetCurrentValueByIdFloat (XIVELY_DATA_STREAM_ID);
			PHValue = PHValue%14;

			X = x;
			Y = y;
			int barHeight = Radius / 2;
			//int barLength = Radius + (Radius / 2);
			int sectionSize = Radius / 5;
			int pushLength = sectionSize+1;
			int amountOfSections = 8;

			int selectwidth = Radius / 10;
			int selectHeight = Radius / 2;

			float phSelect = (((float)sectionSize * (float)amountOfSections) / 14.0f) * PHValue;
			int distanceOnBar = X-((sectionSize * amountOfSections)/2)+(int)phSelect;

			// CIRCLE
			surface.SetSourceRGBA (1, 1, 1, 0.3);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();
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

			surface.SetSourceRGB (0.3, 0.0, 0.0);
			surface.Rectangle (X - ((1+sectionSize)*amountOfSections / 2)+(pushLength*3), Y - (barHeight/2), (sectionSize), barHeight);
			surface.Fill ();

			surface.SetSourceRGB (0.0, 0.0, 0.3);
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
			surface.MoveTo(distanceOnBar-(text.Width/2), Y + (text.Height/2)-barHeight);
			surface.ShowText (widgetText);
			surface.Fill();

			surface.SetSourceRGB (1, 1, 1);
			surface.Rectangle (distanceOnBar-(selectwidth/2), Y-barHeight/2, selectwidth, selectHeight);
			surface.Stroke ();
			surface.Fill ();
		
		}

	}
}

