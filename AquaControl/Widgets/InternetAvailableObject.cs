using System;

namespace AquaControl
{
	public class InternetAvailableObject : BaseObject
	{

		private float _textAlpha = 0.0f;
	
		public InternetAvailableObject () 
		{

			Alpha = 1;
		
			R = 0.2f;
			G = 0.5f;
			B = 0.2f;

		}

		public override void Draw (Cairo.Context surface, int x, int y)
		{

			X = x;
			Y = y;

			string widgetText = "";

			if (Connection.IsAlive) {
				widgetText = "Online";
				surface.SetSourceRGB (R, G, B);
			} else {
				widgetText = "Offline";
				surface.SetSourceRGB (G, R, B);
			}

			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Fill ();

			if (!UserSettings.UserSetupCompleted) { 
				surface.SetSourceRGB (1, 0, 0);
			} else {
				surface.SetSourceRGB (R, G, 0);
			}
			surface.Arc (X, Y, Radius+5, 0, Math.PI * 2);
			surface.Stroke ();

			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);
			surface.SetSourceRGBA (0, 0, 0, _textAlpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));
			surface.ShowText (widgetText);


			if (!UserSettings.UserSetupCompleted) { 
				widgetText = "Settings Incomplete";
				surface.SetFontSize (10);
				text = surface.TextExtents (widgetText);
				surface.SetSourceRGBA (0, 0, 0, Alpha);
				surface.MoveTo (X - (text.Width / 2), Y + (text.Height));
				surface.ShowText (widgetText);
			}
			if (!UserSettings.CorrectKey && UserSettings.UserSetupCompleted) { 
				widgetText = "Settings Incomplete";
				surface.SetFontSize (10);
				text = surface.TextExtents (widgetText);
				surface.SetSourceRGBA (0, 0, 0, Alpha);
				surface.MoveTo (X - (text.Width / 2), Y + (text.Height)+10);
				surface.ShowText (widgetText);
				widgetText = "Wrong Key";
				surface.SetFontSize (10);
				text = surface.TextExtents (widgetText);
				surface.SetSourceRGBA (0.4f, 0, 0, Alpha);
				surface.MoveTo (X - (text.Width / 2), Y + (text.Height)+(text.Height)+10);
				surface.ShowText (widgetText);
			}
			if (UserSettings.CorrectKey && UserSettings.UserSetupCompleted) { 
				widgetText = "Settings OK!";
				surface.SetFontSize (10);
				text = surface.TextExtents (widgetText);
				surface.SetSourceRGBA (0, 0, 0, _textAlpha);
				surface.MoveTo (X - (text.Width / 2), Y + (text.Height)+10);
				surface.ShowText (widgetText);
			}
				
		}

		public override void OnHoverAction ()
		{

			_textAlpha = 0.9f;

		}

		public override void OnNoHoverAction ()
		{

			_textAlpha = 0.0f;

		}

		public override void OnWidgetClickActionButtomLeft ()
		{
			OnAllClick ();
		}

		public override void OnWidgetClickActionButtomRight ()
		{
			OnAllClick ();
		}

		public override void OnWidgetClickActionTopLeft ()
		{
			OnAllClick ();
		}

		public override void OnWidgetClickActionTopRight ()
		{
			OnAllClick ();
		}

		public override void OnAllClick ()
		{



		}





	}
}

