using System;
using Cairo;

namespace AquaControl
{
	public class ClockWidget : BaseObject
	{
		public string Name { get; set; }

		private bool _showText = false;

		private int _graphId = 0;

		private const string XIVELY_DATA_STREAM_ID = "DS181";


		public ClockWidget ()
		{

			_graphId = GraphContainer.AssignAndGetGraphId ();

			Alpha = 0.6f;
			Name = "";

			R = 0.98f;
			G = 0.96f;
			B = 0.88f;

		}

		public override void Draw (Cairo.Context surface, int PositionX, int PositionY)
		{

			GraphContainer.AssignXivelyDatastreamStringById (_graphId, XIVELY_DATA_STREAM_ID);

			GraphContainer.SetGraphColorById (_graphId, R, G, B);

			X = PositionX;
			Y = PositionY;

			double clockDegree = (Math.PI * 2) / 60;
			double angleSeconds = clockDegree * DateTime.Now.Second;
			double angleMinute = clockDegree * DateTime.Now.Minute;
			double angleHour = ( (Math.PI * 2) / 12 ) * DateTime.Now.Hour%12;
			bool minutes = true;


			surface.MoveTo (PositionX-Radius, PositionY);
			surface.SetSourceRGBA (R,G,B, Alpha);
			//context.MoveTo (x, y);
			surface.Arc (PositionX, PositionY, Radius, -Math.PI, Math.PI);
			surface.Stroke ();

			surface.SetSourceRGBA (R, 0.5f, 0.4f, 0.5f);
			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();

			// digital time
			surface.SetFontSize(12);
			TextExtents text = surface.TextExtents(DateTime.Now.ToString("HH:mm:ss"));
			surface.MoveTo(PositionX - text.Width/2,PositionY + text.Height/2 + Radius/2 - 10);
			surface.SetSourceRGBA (0.8,0.4,0.4, Alpha);
			surface.ShowText (DateTime.Now.ToString("HH:mm:ss"));

			// name
			surface.SetFontSize(10);
			text = surface.TextExtents(Name);
			surface.MoveTo(PositionX - text.Width/2, PositionY + text.Height/2 + Radius/2);
			surface.SetSourceRGBA (R,G,B, Alpha);
			surface.ShowText (Name);

			// seconds line
			surface.SetSourceRGB (0.8,0.4,0.4);
			surface.MoveTo (PositionX, PositionY);
			surface.LineTo (PositionX-Radius*Math.Cos(angleSeconds+Math.PI/2),PositionY-Radius*Math.Sin(angleSeconds+Math.PI/2));
			surface.Stroke ();

			if (minutes) {
				// minutes line
				surface.SetSourceRGB (0.4, 0.4, 0.4);
				surface.MoveTo (PositionX, PositionY);
				surface.LineTo (PositionX - (Radius - 10) * Math.Cos (angleMinute + Math.PI / 2), PositionY - (Radius - 10) * Math.Sin (angleMinute + Math.PI / 2));
				surface.Stroke ();
			}

			// hour line
			surface.SetSourceRGB (0.4,0.4,0.4);
			surface.MoveTo (PositionX, PositionY);
			surface.LineTo (PositionX-(Radius/2)*Math.Cos(angleHour+Math.PI/2),PositionY-(Radius/2)*Math.Sin(angleHour+Math.PI/2));
			surface.Stroke ();

			if (_showText) {

				// name
				surface.SetFontSize(30);
				text = surface.TextExtents("Kevins Mom");
				surface.MoveTo(PositionX - text.Width/2, PositionY + text.Height/2 + Radius/2);
				surface.SetSourceRGBA (1,0,1, 1);
				surface.ShowText ("Kevins Mom");

			}
		}

		public override void OnHoverAction ()
		{
			base.OnHoverAction ();
			Alpha = 1;
		}

		public override void OnNoHoverAction ()
		{
			base.OnNoHoverAction ();
			Alpha = 0.6f;
		}

		public override void OnAllClick ()
		{



			if (_showText) {
				_showText = false;
			} else {
				_showText = true;
			}

			if (GraphContainer.IsShownById (_graphId)) {
				GraphContainer.HideGraphById (_graphId);
			} else {
				GraphContainer.ShowGraphById (_graphId);
				CurrentData.ForceUpdateData ();
			}

		}


	}
}

