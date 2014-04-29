using System;
using System.Collections.Generic;

namespace AquaControl
{
	public static class GraphContainer
	{

		/// <summary>
		/// The widget array.
		/// </summary>
		public static List<Graph> GraphBucket;

		/// <summary>
		/// Gets or sets the total widget count.
		/// </summary>
		/// <value>The total widget count.</value>
		public static int TotalGraphCount = 0;

		/// <summary>
		/// Assigns the and get graph identifier.
		/// </summary>
		/// <returns>The and get graph identifier.</returns>
		public static int AssignAndGetGraphId()
		{

			int id = TotalGraphCount;

			TotalGraphCount++;

			return id;

		}

		/// <summary>
		/// Creates the graphs.
		/// </summary>
		public static void CreateGraphs()
		{

			GraphBucket = new List<Graph> ();

			for (int i = 0; i < TotalGraphCount; i++) {

				GraphBucket.Add(new Graph ());
				GraphBucket [i].Id = i;

			}

		}

		/// <summary>
		/// Assigns the xively datastream string by graph identifier.
		/// </summary>
		/// <param name="id">Graph Identifier.</param>
		/// <param name="xivelyStringId">Xively string identifier.</param>
		public static void AssignXivelyDatastreamStringById(int id, string xivelyStringId)
		{

			GraphBucket [id].DataStreamId = xivelyStringId;

		}

		public static void SetGraphColorById(int id, float r, float g, float b)
		{

			GraphBucket [id].R = r;
			GraphBucket [id].G = g;
			GraphBucket [id].B = b;

		}

		/// <summary>
		/// Shows the graph by identifier.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static void ShowGraphById(int id) 
		{

			GraphBucket [id].Alpha = 1;


		}

		/// <summary>
		/// Hides the graph by identifier.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static void HideGraphById(int id) 
		{

			GraphBucket [id].Alpha = 0;

		}


		/// <summary>
		/// Find out if graph is shown or hidden.
		/// </summary>
		/// <returns><c>true</c> graph is shown; otherwise, <c>false</c>.</returns>
		/// <param name="id">Identifier.</param>
		public static bool IsShownById(int id) {

			if (GraphBucket [id].Alpha == 1) {

				return true;

			} else {

				return false;

			}

		}
			
	}
}

