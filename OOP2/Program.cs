using System;
using Nmqtt;

namespace OOP2
{


	public class Program
	{

		public MqttClient client = new Nmqtt.MqttClient("test.mosquitto.org", 1883, "Nmqtt_quickstart");

		public static void Main(string[] args)
		{


			byte[] msgData = new byte[] { 1, 2, 3 };

			this.client.PublishMessage ("bobby/chop/1/status/lol", msgData);

			GayKevin kevin = new GayKevin (2, 1);

			Console.Write ("HEJ KEVIN! Din penis er " + kevin.penisSize + "mm lang, og " + kevin.width + "mm bred.. noob!");



		}
	}
}

