﻿using System;

namespace AquaControl
{
	public static class GraphContainer
	{

		/// <summary>
		/// The widget array.
		/// </summary>
		public static Graph[] graphArray;

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

			if (TotalGraphCount != 0) {

				graphArray = new Graph[TotalGraphCount];

			}

			for (int i = 0; i < TotalGraphCount; i++) {

				graphArray [i] = new Graph ();

			}

		}

		/// <summary>
		/// Assigns the xively datastream string by graph identifier.
		/// </summary>
		/// <param name="id">Graph Identifier.</param>
		/// <param name="xivelyStringId">Xively string identifier.</param>
		public static void AssignXivelyDatastreamStringById(int id, string xivelyStringId)
		{

			graphArray [id].DataStreamId = xivelyStringId;

		}

		/// <summary>
		/// Shows the graph by identifier.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static void ShowGraphById(int id) 
		{

			graphArray [id].Alpha = 1;


		}

		/// <summary>
		/// Hides the graph by identifier.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static void HideGraphById(int id) 
		{

			graphArray [id].Alpha = 0;

		}


		/// <summary>
		/// Find out if graph is shown or hidden.
		/// </summary>
		/// <returns><c>true</c> graph is shown; otherwise, <c>false</c>.</returns>
		/// <param name="id">Identifier.</param>
		public static bool IsShownById(int id) {

			if (graphArray [id].Alpha == 1) {

				return true;

			} else {

				return false;

			}

		}
			
	}
}
