using System;
#if __IOS__
using UIKit;
#endif

#if __ANDROID__
using Android.Widget;
#endif

using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;

namespace MagnetFinder
{
	public class Sensor
	{
		
			Double maxX = 0;
			double maxY = 0;
			double maxZ = 0;

			double minX = 0;
			double minY = 0;
			double minZ = 0;

#if __IOS__


			UIProgressView progressX;
			UIProgressView progressY;
			UIProgressView progressZ;

			public Sensor(UIProgressView progX, UIProgressView progY, UIProgressView progZ)
			{
			progressX = progX;
			progressY = progY;
			progressZ = progZ;
			}
#endif


#if __ANDROID__

			ProgressBar progressBarX;
			ProgressBar progressBarY;
			ProgressBar progressBarZ;

			public Sensor(ProgressBar barX, ProgressBar barY, ProgressBar barZ)
		{

			progressBarX = barX;
			progressBarY = barY;
			progressBarZ = barZ;

		}

#endif


		public void StartSensors() { 

			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer);

			CrossDeviceMotion.Current.SensorValueChanged += (sender, e) =>
			{

				switch (e.SensorType)
				{

					case MotionSensorType.Magnetometer:
						var values = (MotionVector)e.Value;
						LimitsTestAction(values);

						#if __IOS__
						progressX.Progress = (float)(values.X / 300);
						progressY.Progress = (float)(values.Y / 500);
						progressZ.Progress = (float)(values.Z / -1100);
						#endif

						#if __ANDROID__
						progressBarX.Progress = (int)values.X;
						progressBarY.Progress = (int)values.Y;
						progressBarZ.Progress = (int)values.Z;
						#endif


						break;
					default:
						break;

				}
			};
		}

			void LimitsTestAction(MotionVector a)
		{

			var xVal = a.X;
			var yVal = a.Y;
			var zVal = a.Z;

			//Max
			if (xVal > maxX)
			{
				maxX = xVal;
				Console.WriteLine("X max: " + maxX);
			}

			if (yVal > maxY)
			{
				maxY = yVal;
				Console.WriteLine("Y max: " + maxY);
			}

			if (zVal > maxZ)
			{
				maxZ = zVal;
				Console.WriteLine("Z max: " + maxZ);
			}



			//Min


			if (xVal > minX)
			{
				minX = xVal;
				Console.WriteLine("X min: " + minX);
			}

			if (yVal < minY)
			{
				minY = yVal;
				Console.WriteLine("Y min: " + minY);
			}

			if (zVal < minZ)
			{
				minZ = zVal;
				Console.WriteLine("Z min: " + minZ);
			}
		}

	}
}

