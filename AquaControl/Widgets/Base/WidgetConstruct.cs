using System;

namespace AquaControl
{
	public static class WidgetConstruct
	{
	
		public static void ConstructWidgets ()
		{

			BaseObject hest1 = new InternetAvailableObject ();
			WidgetContainer.PutWidget (hest1);

			BaseObject hest2 = new BaseObject ();
			WidgetContainer.PutWidget (hest2);

			//<<<<<<< HEAD
			//=======
			BaseObject Pump = new PumpWidget ();
			WidgetContainer.PutWidget (Pump);

			//>>>>>>> FETCH_HEAD
			BaseObject pref = new PreferencesWidget ();
			WidgetContainer.PutWidget (pref);

			BaseObject PHwater = new PHWidget ();
			WidgetContainer.PutWidget (PHwater);

			BaseObject hum = new HumidityWidget ();
			WidgetContainer.PutWidget (hum);

		}

	}
}

