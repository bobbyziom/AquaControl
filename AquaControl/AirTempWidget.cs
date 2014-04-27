using System;

namespace AquaControl
{
	public class AirTempWidget : BaseObject
	{

		private int _graphId; 
		private string _airTempValue;
		private const string XIVELY_DATA_STREAM_ID = "AIR_TEMPERATURE";

		public AirTempWidget ()
		{

			_graphId = GraphContainer.AssignAndGetGraphId ();

			R = 0.2f;
			G = 0.3f;
			B = 0.3f;

		}

		public override void Draw (Cairo.Context surface, int PositionX, int PositionY)
		{

			_airTempValue = CurrentData.GetCurrentValueByIdString (XIVELY_DATA_STREAM_ID);

			GraphContainer.AssignXivelyDatastreamStringById (_graphId, XIVELY_DATA_STREAM_ID);

			GraphContainer.SetGraphColorById (_graphId, R, G, B);

			GraphContainer.AssignCustomNameById (_graphId, "AIR");

			X = PositionX;
			Y = PositionY;

			surface.SetSourceRGBA (R, B, G, Alpha);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			surface.SetSourceRGB (R, G, B);
			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();

			string widgetText = _airTempValue + "°";
			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (1, 1, 1, Alpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));

			surface.ShowText (widgetText);

			widgetText = "Air";
			surface.SetFontSize (13);
			text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (0.98f, 0.5f, 0.4f, Alpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2) + 15);

			surface.ShowText (widgetText);

		}

		public override void OnHoverAction ()
		{

			R = 0.2f;
			G = 0.3f;
			B = 0.8f;

		}

		public override void OnNoHoverAction ()
		{

			R = 0.2f;
			G = 0.3f;
			B = 0.3f;
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
		
			if (GraphContainer.IsShownById (_graphId)) {
				GraphContainer.HideGraphById (_graphId);
			} else {
				CurrentData.ForceUpdateData ();
				GraphContainer.ShowGraphById (_graphId);
			}

		}

	}
}

