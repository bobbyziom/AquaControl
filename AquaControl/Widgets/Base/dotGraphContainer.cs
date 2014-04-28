using System;

namespace AquaControl
{
	public class dotGraphContainer
	{

		public BaseObject[] arrayofDots;

		public dotGraphContainer ()
		{
			// THIS IS KEVIN
		}

		public void creatingGraphDots(int containerSize, double[] dataArray){

			arrayofDots = new BaseObject[containerSize];

			for( int i = 0; i < containerSize; i++){

				arrayofDots [i] = new graphDot(dataArray[i]);

			}

		}
	}
}

