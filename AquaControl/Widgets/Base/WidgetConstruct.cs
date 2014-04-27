using System;

namespace AquaControl
{
	public static class WidgetConstruct
	{
	
		public static void ConstructWidgets ()
		{

			BaseObject hest1 = new InternetAvailableObject ();
			WidgetContainer.PutWidget (hest1);

			BaseObject hest2 = new ClockWidget ();
			WidgetContainer.PutWidget (hest2);

			BaseObject Pump = new PumpWidget ();
			WidgetContainer.PutWidget (Pump);

			BaseObject pref = new PreferencesWidget ();
			WidgetContainer.PutWidget (pref);

			BaseObject PHwater = new PHWidget ();
			WidgetContainer.PutWidget (PHwater);

			BaseObject hum = new HumidityWidget ();
			WidgetContainer.PutWidget (hum);

<<<<<<< HEAD
			BaseObject Swipe = new Swipe ();
			WidgetContainer.PutWidget (Swipe);

=======
			BaseObject airTemp = new AirTempWidget ();
			WidgetContainer.PutWidget (airTemp);

			BaseObject bulb = new lightIntensity ();
			WidgetContainer.PutWidget (bulb);
>>>>>>> FETCH_HEAD
		}

	}
}

