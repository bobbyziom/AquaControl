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

			BaseObject hest3 = new InternetAvailableObject ();
			WidgetContainer.PutWidget (hest3);

			BaseObject pref = new PreferencesWidget ();
			WidgetContainer.PutWidget (pref);

			BaseObject PHwater = new PHWidget ();
			WidgetContainer.PutWidget (PHwater);

		}

	}
}

