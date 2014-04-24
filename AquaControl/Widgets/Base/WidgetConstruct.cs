using System;

namespace AquaControl
{
	public static class WidgetConstruct
	{
	
		public static void ConstructWidgets ()
		{

			DatapointObject hest1 = new TestObject ();
			WidgetContainer.PutWidget (hest1);

			DatapointObject hest2 = new DatapointObject ();
			WidgetContainer.PutWidget (hest2);

			DatapointObject hest3 = new TestObject ();
			WidgetContainer.PutWidget (hest3);

			DatapointObject pref = new PreferencesWidget ();
			WidgetContainer.PutWidget (pref);

			DatapointObject PHwater = new PHWidget ();
			WidgetContainer.PutWidget (PHwater);

		}

	}
}

