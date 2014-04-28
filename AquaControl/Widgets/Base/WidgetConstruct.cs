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

			// Fixed position
			BaseObject Swipe = new Swipe ();
			WidgetContainer.PutWidget (Swipe);

			BaseObject bulb = new lightIntensity ();
			WidgetContainer.PutWidget (bulb);

			// Fixed position
			BaseObject swipeback = new SwipeBack ();
			WidgetContainer.PutWidget (swipeback);

			BaseObject test = new ClockWidget ();
			WidgetContainer.PutWidget (test);

//			BaseObject test2 = new ClockWidget ();
//			WidgetContainer.PutWidget (test2);
//
//			BaseObject test3 = new ClockWidget ();
//			WidgetContainer.PutWidget (test3);
//
//			BaseObject test4 = new ClockWidget ();
//			WidgetContainer.PutWidget (test4);



		}

	}
}

