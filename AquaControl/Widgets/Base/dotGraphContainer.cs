using System;

namespace AquaControl
{
	public class dotGraphContainer
	{

		public BaseObject[] arrayofDots;

		public int containerSize { get; set;}

		public dotGraphContainer ()
		{
			containerSize = 100;

			arrayofDots = new graphDot[containerSize];

		}

		public void creatingGraphDots(){

			arrayofDots[0].Draw (surface, (int)_p1.X,(int)_p1.Y);
		
		}
			
	}
}

