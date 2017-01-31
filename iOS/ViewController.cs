using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using UIKit;

namespace MagnetFinder.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var sensor = new Sensor(progressX, progressY, progressZ);
			sensor.StartSensors();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();


			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
