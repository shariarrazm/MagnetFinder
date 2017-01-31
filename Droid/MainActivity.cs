using Android.App;
using Android.Widget;
using Android.OS;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using System;

namespace MagnetFinder.Droid
{
	[Activity(Label = "Magnet Finder", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var progressBarX = FindViewById<ProgressBar>(Resource.Id.progressX);
			var progressBarY = FindViewById<ProgressBar>(Resource.Id.progressY);
			var progressBarZ = FindViewById<ProgressBar>(Resource.Id.progressZ);

			var sensor = new Sensor(progressBarX, progressBarY, progressBarZ);
			sensor.StartSensors();
		}

		}
	}
