using System;

namespace AquaControl
{
	public class HumidityWidget : BaseObject
	{

		private int graphId; 

		public HumidityWidget ()
		{

			graphId = GraphContainer.AssignAndGetGraphId ();

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			GraphContainer.AssignXivelyDatastreamStringById (graphId, "HUMIDITY");

			X = x;
			Y = y;

			surface.SetSourceRGBA (R, B, G, Alpha);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.SetSourceRGB (R, G, B);
			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();

			string widgetText = "Press Me!";
			surface.SetFontSize (13);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (1, 1, 1, Alpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));

			surface.ShowText (widgetText);

		}

		public override void OnHoverAction ()
		{
			base.OnHoverAction ();
			Alpha = 0.9f;

		}

		public override void OnNoHoverAction ()
		{
			base.OnNoHoverAction ();
			Alpha = 0.5f;

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

