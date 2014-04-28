using System;
using Cairo;

namespace AquaControl
{
	public class BaseObject
	{

		/// <summary>
		/// Gets or sets the alpha.
		/// </summary>
		/// <value>The alpha.</value>
		public float Alpha { get; set; }

		/// <summary>
		/// Gets or sets the red.
		/// </summary>
		/// <value>The red.</value>
		public float R { get; set; }

		/// <summary>
		/// Gets or sets the green.
		/// </summary>
		/// <value>The green.</value>
		public float G { get; set; }

		/// <summary>
		/// Gets or sets the blue.
		/// </summary>
		/// <value>The bblue.</value>
		public float B { get; set; }

		/// <summary>
		/// Gets or sets the x widget coordinate.
		/// </summary>
		/// <value>The x.</value>
		protected int X { get; set; }

		/// <summary>
		/// Gets or sets the Y widget coordinate.
		/// </summary>
		/// <value>The Y.</value>
		protected int Y { get; set; }

		/// <summary>
		/// Gets or sets the radius of the widget.
		/// </summary>
		/// <value>The radius.</value>
		protected int Radius { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="oose_testster.DatapointObject"/> class.
		/// </summary>
		public BaseObject ()
		{

			Console.WriteLine ("Base Object Construct");

			Radius = DrawAssembly.GlobalRadius;

			Alpha = 1;

			R = 0.5f;
			G = 0.5f;
			B = 0.5f;

		}

		/// <summary>
		/// Checks the mouse hover on object.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="clicked">Mouse Clicked bool.</param>
		public virtual void CheckMouseHover(double MouseX, double MouseY, bool clicked) 
		{

			// action lower left
			if (MouseX >= X - Radius && MouseX < X && MouseY >= Y && MouseY < Y + Radius) {
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionButtomLeft ();
					clicked = false;
				}
			} else if (MouseX >= X && MouseX < X + Radius && MouseY >= Y && MouseY < Y + Radius) { // action lower right
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionButtomRight ();
					clicked = false;
				}
			} else if (MouseX >= X - Radius && MouseX < X && MouseY <= Y && MouseY > Y - Radius) { // action upper left
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionTopLeft ();
					clicked = false;
				}
			} else if (MouseX >= X && MouseX < X + Radius && MouseY <= Y && MouseY > Y - Radius) { // action upper right
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionTopRight ();
					clicked = false;
				}
			} else {
				OnNoHoverAction ();
			}
				
		}

		/// <summary>
		/// Draw the specified surface.
		/// </summary>
		/// <param name="surface">Surface.</param>
		public virtual void Draw(Context surface, int PositionX, int PositionY) 
		{

			X = PositionX;
			Y = PositionY;
		
			surface.SetSourceRGBA (R, G, B, Alpha);
			surface.Arc (X,Y,Radius,0,Math.PI*2);
			surface.Stroke ();

		}

		/// <summary>
		/// Raises the hover action event.
		/// </summary>
		public virtual void OnHoverAction() 
		{

			R = 0.8f;
			G = 0.7f;
			B = 0.4f;

		}

		/// <summary>
		/// Raises the no hover action event.
		/// </summary>
		public virtual void OnNoHoverAction () 
		{

			R = 0.5f;
			G = 0.5f;
			B = 0.5f;

		}

		/// <summary>
		/// Raises the widget click action top left event.
		/// </summary>
		public virtual void OnWidgetClickActionTopLeft() 
		{

			OnAllClick ();

		}

		/// <summary>
		/// Raises the widget click action top right event.
		/// </summary>
		public virtual void OnWidgetClickActionTopRight() 
		{

			OnAllClick ();

		}

		/// <summary>
		/// Raises the widget click action buttom left event.
		/// </summary>
		public virtual void OnWidgetClickActionButtomLeft() 
		{

			OnAllClick ();

		}

		/// <summary>
		/// Raises the widget click action buttom right event.
		/// </summary>
		public virtual void OnWidgetClickActionButtomRight() 
		{

			OnAllClick ();

		}

		public virtual void OnAllClick() 
		{

			Console.WriteLine ("Widget Clicked");

		}

		/// <summary>
		/// Show this instance.
		/// </summary>
		public virtual void Show()
		{

			Alpha = 1;

		}

		/// <summary>
		/// Hide this instance.
		/// </summary>
		public virtual void Hide()
		{

			Alpha = 0;

		}
			
	}
}

