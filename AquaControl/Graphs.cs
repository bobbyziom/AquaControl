using System;

namespace AquaControl
{
	public static class Graphs
	{

		/// <summary>
		/// Gets or sets the graph surface.
		/// </summary>
		/// <value>The graph surface.</value>
		public static Cairo.Context GraphSurface { get; set; }

		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		/// <value>The x.</value>
		public static int X { get; set; }

		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		/// <value>The y.</value>
		public static int Y { get; set; }

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		public static float Width { get; set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public static float Height { get; set; }

		/// <summary>
		/// Draw the specified surface, x and y.
		/// </summary>
		/// <param name="surface">Surface.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public static void Draw(Cairo.Context surface, int x, int y) 
		{

			GraphSurface = surface;

			X = x;
			Y = y;

			Width = DrawAssembly.ContentWidth;
			Height = DrawAssembly.ContentHeigth;



		}

	}
}

