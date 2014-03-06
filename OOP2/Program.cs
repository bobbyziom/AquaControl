using System;
using Nmqtt;

namespace OOP2
{

	public class Program
	{
	
		public static void Main(string[] args)
		{
			// mqtt test:
			Console.WriteLine ("connecting....");

			// connecting to server:
			var client = new Nmqtt.MqttClient("test.mosquitto.org", 1883, "Nmqtt_quickstart");
			ConnectionState connectionState = client.Connect();

			Console.WriteLine (connectionState);

			// set up subscription
			IObservable<MqttReceivedMessage<byte[]>> observation = client.ListenTo("Nmqtt_quickstart_topic", MqttQos.AtMostOnce);

			// making data to send
			byte[] msgData = new byte[] { 1, 2, 3 };

			// send data to topic
			client.PublishMessage ("bobby/chop/1/status/lol", msgData);

			// print data sent to console
			Console.WriteLine ("  data sent!");


		}
	}
}

