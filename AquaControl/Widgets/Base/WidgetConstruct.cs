using System;

namespace AquaControl
{
	public static class WidgetConstruct
	{
	
		public static void ConstructWidgets ()
		{

			DatapointObject hest1 = new TestObject ();
			WidgetContainer.PutWidget (hest1);

			DatapointObject hest2 = new TestObject ();
			WidgetContainer.PutWidget (hest2);

			DatapointObject hest3 = new TestObject ();
			WidgetContainer.PutWidget (hest3);

			//DatapointObject graph = new KevinsObject ();
			//WidgetContainer.PutWidget (graph);

		}

	}
}

