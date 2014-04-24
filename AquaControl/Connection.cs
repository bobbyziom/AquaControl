using System;
using System.Net.NetworkInformation;
using System.Timers;

namespace AquaControl
{
	public static class Connection
	{

		private static Timer _update;

		/// <summary>
		/// Gets or sets a value indicating whether program is connected.
		/// </summary>
		/// <value><c>true</c> if this instance is connected; otherwise, <c>false</c>.</value>
		public static bool IsAlive { get; set; }

		/// <summary>
		/// Gets or sets the test ping internet address.
		/// </summary>
		/// <value>The test adrdess.</value>
		public static string TestAdress { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="oose_testster.Connection"/> class. </p>
		/// Setting default address to: www.google.com </br>
		/// Checking connection every 60000 ms.
		/// </summary>
		public static void StartCheck() 
		{

			TestAdress = "www.google.com";

			_update = new Timer (2000);
			_update.Start ();
			_update.AutoReset = true;
			_update.Elapsed += new ElapsedEventHandler(OnTimerTick);

		}

		/// <summary>
		/// Pings the host.
		/// </summary>
		/// <returns><c>true</c>, if host was pinged, <c>false</c> otherwise.</returns>
		/// <param name="address">Address.</param>
		private static bool PingHost(string address)
		{

			bool pingable = false;
			Ping pinger = new Ping();

			try
			{
				PingReply reply = pinger.Send(address);

				pingable = reply.Status == IPStatus.Success;
			}
			catch (PingException)
			{
				return false;
			}

			return pingable;

		}

		/// <summary>
		/// Raises the timer tick event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private static void OnTimerTick(object sender, EventArgs e)
		{

			IsAlive = PingHost (TestAdress);

			// widget test
//			Random random = new Random();
//			int randomNumber = random.Next(0, 100);
//
//			Console.WriteLine ("Random number: " + randomNumber);
//
//			if (randomNumber > 50) {
//				IsAlive = true;
//			} else {
//				IsAlive = false;
//			}

			// debug
			Console.WriteLine (IsAlive);

		}
			
	}
}

