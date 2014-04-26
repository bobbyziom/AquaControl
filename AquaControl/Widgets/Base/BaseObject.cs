using System;
using Cairo;

namespace AquaControl
{
	public class BaseObject
	{
	
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
		/// Gets or sets widget width.
		/// </summary>
		/// <value>The width.</value>
		public int Width { get { return Width; } set { Radius = value/2; Height = value; } }

		/// <summary>
		/// Gets or sets widget height.
		/// </summary>
		/// <value>The height.</value>
		public int Height { get { return Height; } set { Radius = value/2; Width = value; } }

		/// <summary>
		/// Gets or sets the x widget coordinate.
		/// </summary>
		/// <value>The x.</value>
		public int X { get; set; }

		/// <summary>
		/// Gets or sets the Y widget coordinate.
		/// </summary>
		/// <value>The Y.</value>
		public int Y { get; set; }

		/// <summary>
		/// Gets or sets the radius of the widget.
		/// </summary>
		/// <value>The radius.</value>
		public int Radius { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="oose_testster.DatapointObject"/> class.
		/// </summary>
		public BaseObject ()
		{

			Console.WriteLine ("Base Object Construct");

			Radius = 50;

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
		public void CheckMouseHover(double x, double y, ref bool clicked) 
		{

			// action lower left
			if (x >= X - Radius && x < X && y >= Y && y < Y + Radius) {
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionButtomLeft ();
					clicked = false;
				}
			} else if (x >= X && x < X + Radius && y >= Y && y < Y + Radius) { // action lower right
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionButtomRight ();
					clicked = false;
				}
			} else if (x >= X - Radius && x < X && y <= Y && y > Y - Radius) { // action upper left
				OnHoverAction ();
				if (clicked) {
					OnWidgetClickActionTopLeft ();
					clicked = false;
				}
			} else if (x >= X && x < X + Radius && y <= Y && y > Y - Radius) { // action upper right
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
		public virtual void Draw(Context surface, int x, int y) 
		{

			X = x;
			Y = y;
		
			surface.SetSourceRGB (R, G, B);
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

			Console.WriteLine ("TopLeft");

		}

		/// <summary>
		/// Raises the widget click action top right event.
		/// </summary>
		public virtual void OnWidgetClickActionTopRight() 
		{

			Console.WriteLine ("TopRight");

		}

		/// <summary>
		/// Raises the widget click action buttom left event.
		/// </summary>
		public virtual void OnWidgetClickActionButtomLeft() 
		{

			Console.WriteLine ("ButtomLeft");

		}

		/// <summary>
		/// Raises the widget click action buttom right event.
		/// </summary>
		public virtual void OnWidgetClickActionButtomRight() 
		{

			Console.WriteLine ("ButtomRight");

		}
			
	}
}

