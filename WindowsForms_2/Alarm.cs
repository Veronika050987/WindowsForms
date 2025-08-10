using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_2
{
	public class Alarm
	{
		public DateTime AlarmTime { get; set; }
		public bool IsEnabled { get; set; }
		public string SoundPath { get; set; }

		public Alarm()
		{
			// Initialize any default values here
			AlarmTime = DateTime.Now;  // Default to current time
			IsEnabled = true;         // Default to enabled
			SoundPath = string.Empty;  // Default to empty string
		}
	}
}
