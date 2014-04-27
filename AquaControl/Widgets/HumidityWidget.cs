using System;

namespace AquaControl
{
	public class HumidityWidget : BaseObject
	{

		private int _graphId; 
		private string _humidityValue;
		private const string XIVELY_DATA_STREAM_ID = "HUMIDITY";

		public HumidityWidget ()
		{

			_graphId = GraphContainer.AssignAndGetGraphId ();

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			_humidityValue = CurrentData.GetCurrentValueByIdString (XIVELY_DATA_STREAM_ID);

			GraphContainer.AssignXivelyDatastreamStringById (_graphId, XIVELY_DATA_STREAM_ID);

			GraphContainer.SetGraphColorById (_graphId, G, R, 0.4f);

			X = x;
			Y = y;

			surface.SetSourceRGBA (R, B, G, Alpha);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.SetSourceRGB (R, G, B);
			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();

			string widgetText = _humidityValue + "%";
			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (1, 1, 1, Alpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));

			surface.ShowText (widgetText);

			widgetText = "Humidity";
			surface.SetFontSize (13);
			text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (0.98f, 0.5f, 0.4f, Alpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2) + 15);

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

			CurrentData.ForceUpdateData ();

			if (GraphContainer.IsShownById (_graphId)) {
				GraphContainer.HideGraphById (_graphId);
			} else {
				GraphContainer.ShowGraphById (_graphId);
			}

		}



	}
}

