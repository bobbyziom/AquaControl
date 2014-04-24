using System;

namespace AquaControl
{
	public class PreferencesWidget : DatapointObject
	{

		private float _textAlpha = 0.5f;

		/// <summary>
		/// Initializes a new instance of the <see cref="AquaControl.PreferencesWidget"/> class.
		/// </summary>
		public PreferencesWidget ()
		{

			Radius = 50;

			R = 0.1f;
			G = 0.2f;
			B = 0.5f;

		}

		/// <summary>
		/// Draw on specified surface.
		/// </summary>
		/// <param name="surface">Surface.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public override void Draw (Cairo.Context surface, int x, int y)
		{
		
			X = x;
			Y = y;
	
			surface.SetSourceRGB (R, G, B);
			surface.Arc (X, Y, Radius, 0, Math.PI * 2);
			surface.Stroke ();

			string widgetText = "Preferences";
			surface.SetFontSize (15);
			Cairo.TextExtents text = surface.TextExtents (widgetText);

			surface.SetSourceRGBA (1, 1, 1, _textAlpha);
			surface.MoveTo(X - (text.Width/2), Y + (text.Height/2));

			surface.ShowText (widgetText);

		}

		public override void OnHoverAction ()
		{

			R = 0.4f;
			G = 0.4f;
			B = 0.4f;

			_textAlpha = 0.9f;

		}

		public override void OnNoHoverAction()
		{

			R = 0.1f;
			G = 0.2f;
			B = 0.5f;

			_textAlpha = 0.5f;

		}

		public override void OnWidgetClickActionButtomLeft ()
		{
			PressAction ();
		}

		public override void OnWidgetClickActionButtomRight ()
		{
			PressAction ();
		}
			
		public override void OnWidgetClickActionTopLeft ()
		{
			PressAction ();
		}

		public override void OnWidgetClickActionTopRight ()
		{
			PressAction ();
		}

		private void PressAction() 
		{
			new Preferences ();
		}
			
	}
}

