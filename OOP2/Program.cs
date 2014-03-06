using System;
using Nmqtt;

namespace OOP2
{


	public class Program
	{

		MqttClient client = new Nmqtt.MqttClient("test.mosquitto.org", 1883, "Nmqtt_quickstart");

		public static void Main(string[] args)
		{


			IObservable<MqttRecivedMessage<byte[]> observable = client.ListenTo("Nmqtt_quickstart_topic", MqttQos.AtMostOnce);

			GayKevin kevin = new GayKevin (2, 1);

			Console.Write ("HEJ KEVIN! Din penis er " + kevin.penisSize + "mm lang, og " + kevin.width + "mm bred.. noob!");



		}
	}
}

