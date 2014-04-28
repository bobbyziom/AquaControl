using System;

namespace AquaControl
{
	public static class WidgetConstruct
	{
	
		public static void ConstructWidgets ()
		{

			WidgetContainer.PutWidget (new InternetAvailableObject ());

			WidgetContainer.PutWidget (new ClockWidget ());

			WidgetContainer.PutWidget (new PumpWidget ());

			WidgetContainer.PutWidget (new PreferencesWidget ());

			WidgetContainer.PutWidget (new PHWidget ());

			WidgetContainer.PutWidget (new HumidityWidget ());

			WidgetContainer.PutWidget (new Swipe ()); // NEEDS TO BE HERE

			WidgetContainer.PutWidget (new lightIntensity ());

			WidgetContainer.PutWidget (new SwipeBack ());

			WidgetContainer.PutWidget (new WaterTemp ());
		

		}

	}
}

