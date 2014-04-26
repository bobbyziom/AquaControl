using System;

namespace AquaControl
{
	public class HumidityWidget : BaseObject
	{

		private int graphId; 

		public HumidityWidget ()
		{

			graphId = GraphContainer.AssignAndGetGraphId ();
			//GraphContainer.AssignValueByDataStreamId (graphId, "DS181");

			Alpha = 1;

			R = 0.4f;
			G = 0.9f;
			B = 0.1f;

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			X = x;
			Y = y;

			surface.SetSourceRGBA (R, B, G, Alpha);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

		}

		public override void OnHoverAction ()
		{

		}

		public override void OnNoHoverAction ()
		{


		}

		public override void OnWidgetClickActionButtomLeft ()
		{
			OnClickAll ();
		}

		public override void OnWidgetClickActionButtomRight ()
		{
			OnClickAll ();
		}

		public override void OnWidgetClickActionTopLeft ()
		{
			OnClickAll ();
		}

		public override void OnWidgetClickActionTopRight ()
		{
			OnClickAll ();
		}

		private void OnClickAll() 
		{

			if (GraphContainer.IsShownById (graphId)) {
				GraphContainer.HideGraphById (graphId);
			} else {
				GraphContainer.ShowGraphById (graphId);
			}




		}



	}
}

