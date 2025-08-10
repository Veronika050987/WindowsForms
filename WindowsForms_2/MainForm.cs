using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;  // For sound playback
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_2
{
	public partial class MainForm : Form
	{
		ChooseFont chooseFont;
		ColorDialog cdBackColor;
		ColorDialog cdForeColor;

		private AlarmsForm alarmsForm;

		public MainForm()
		{
			InitializeComponent();
			ShowControls(cmShowControls.Checked);
			ShowConsole(cmDebugConsole.Checked = true);
			chooseFont = new ChooseFont();
			cdBackColor = new ColorDialog();
			cdForeColor = new ColorDialog();
			this.Location = new Point //clocks on the rigth side
				(
					Screen.PrimaryScreen.Bounds.Width - this.Width,
					100
				);
			chooseFont.StartPosition = FormStartPosition.Manual;//position font near clocks
			chooseFont.Location = new Point
				(
					this.Location.X - chooseFont.Width,
					100
				);
			// Initialize the alarms form
			alarmsForm = new AlarmsForm();
			alarmsForm.FormClosed += AlarmsForm_FormClosed;

			// Set up timer for alarms
			Timer alarmTimer = new Timer();
			alarmTimer.Interval = 1000;  // Check every second
			alarmTimer.Tick += AlarmTimer_Tick;
			alarmTimer.Start();

			LoadSettings();
		}

		private void AlarmsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Handle the alarms form closed event, cleanup or re-initialize as needed
			alarmsForm = null; // This is important
		}

		private void AlarmTimer_Tick(object sender, EventArgs e)
		{
			CheckAlarms();
		}

		private void CheckAlarms()
		{
			if (alarmsForm != null) // check if form exists
			{
				DateTime now = DateTime.Now;

				foreach (Alarm alarm in alarmsForm.Alarms)
				{
					if (alarm.IsEnabled && now >= alarm.AlarmTime)
					{
						PlayAlarmSound(alarm.SoundPath);
						alarm.IsEnabled = false; // Disable Alarm
					}
				}

				alarmsForm.RefreshDataGridView(); // Refresh the DataGridView on the AlarmsForm
			}
		}

		private void PlayAlarmSound(string soundPath)
		{
			try
			{
				if (string.IsNullOrEmpty(soundPath) || !File.Exists(soundPath))
				{
					SystemSounds.Asterisk.Play(); // Default sound
				}
				else
				{
					SoundPlayer player = new SoundPlayer(soundPath);
					player.Play();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				SystemSounds.Asterisk.Play(); // Play default sound
			}
		}

		void ShowControls(bool visible)
		{			
			cbShowDate.Visible = visible;
			cbShowWeekday.Visible = visible;
			btnHideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
			this.labelCurrentTime.BackColor = visible ? this.BackColor : Color.DeepSkyBlue;
		}

		void ShowConsole(bool visible)
		{
			//bool console = visible ? AllocConsole() : FreeConsole();
			//if(console)Console.WriteLine(console);
			if (visible)
				AllocConsole();
			else
				FreeConsole();
		}

		void SaveSettings()
		{
			StreamWriter settings = new StreamWriter("Settings.ini");

			settings.WriteLine($"{this.Location.X}x{this.Location.Y}");	//1. Location
			settings.WriteLine(cmTopmost.Checked);						//2. Topmost
			settings.WriteLine(cmShowControls.Checked);					//3.
			settings.WriteLine(cmDebugConsole.Checked);					//4.
			settings.WriteLine(cmShowDate.Checked);						//5.
			settings.WriteLine(cmShowWeekday.Checked);					//6.
			settings.WriteLine(cmLoadOnWindowsStartup.Checked);			//7.
			settings.WriteLine(cdBackColor.Color.ToArgb());				//8.
			settings.WriteLine(cdForeColor.Color.ToArgb());				//9.
			settings.WriteLine(chooseFont.Filename);					//10.
			settings.Close();
		}
		void LoadSettings()
		{
			StreamReader settings = new StreamReader("Settings.ini");			
			string location = settings.ReadLine();							//1. Location
			this.Location = new Point
				(
					Convert.ToInt32(location.Split('x').First()),
					Convert.ToInt32(location.Split('x').Last())

				);

			cmTopmost.Checked = bool.Parse(settings.ReadLine());			//2.
			cmShowControls.Checked = bool.Parse(settings.ReadLine());		//3.
			cmDebugConsole.Checked = bool.Parse(settings.ReadLine());		//4.
			cmShowDate.Checked = bool.Parse(settings.ReadLine());			//5.
			cmShowWeekday.Checked = bool.Parse(settings.ReadLine());		//6.
			cmLoadOnWindowsStartup.Checked = bool.Parse(settings.ReadLine());//7.
			cdBackColor.Color = labelCurrentTime.BackColor = Color.FromArgb(Convert.ToInt32(settings.ReadLine()));//8.
			cdForeColor.Color = labelCurrentTime.ForeColor = Color.FromArgb(Convert.ToInt32(settings.ReadLine()));//9.
			string font_name = settings.ReadLine();											  //10.
			chooseFont = new ChooseFont(this, font_name, 32);
			labelCurrentTime.Font = chooseFont.Font;				
			settings.Close();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
			//to show AM and PM

			if(cbShowDate.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";

			if (cbShowWeekday.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.DayOfWeek}";

			notifyIcon.Text = labelCurrentTime.Text;
			//if(cmDebugConsole.Checked) Console.WriteLine(notifyIcon.Text);
		}		

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			ShowControls(cmShowControls.Checked = false);
		}

		private void labelCurrentTime_DoubleClick(object sender, EventArgs e)
		{
			ShowControls(cmShowControls.Checked = true);
		}

		private void cmClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmTopmost_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = cmTopmost.Checked;
		}

		private void cmShowControls_CheckedChanged(object sender, EventArgs e)
		{
			ShowControls(cmShowControls.Checked);
		}

		////////////////////////////////////
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		private void cmDebugConsole_CheckedChanged(object sender, EventArgs e)
		{
			ShowConsole(cmDebugConsole.Checked);
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			if (this.TopMost) return;
			this.TopMost = true;
			this.TopMost = false;
		}

		private void cmShowDate_CheckedChanged(object sender, EventArgs e)
		{
			cbShowDate.Checked = cmShowDate.Checked;
		}

		private void cmShowWeekday_CheckedChanged(object sender, EventArgs e)
		{
			cbShowWeekday.Checked = cmShowWeekday.Checked;
		}

		private void cmBackColor_Click(object sender, EventArgs e)
		{
			cdBackColor.ShowDialog();
					//mеthod ShowDialog always opens modal window
					//if(cdBackColor.ShowDialog() == DialogResult.OK)
			labelCurrentTime.BackColor = cdBackColor.Color;
		}

		private void cmForeColor_Click(object sender, EventArgs e)
		{
			cdForeColor.ShowDialog();
			labelCurrentTime.ForeColor = cdForeColor.Color;
		}

		private void cmFont_Click(object sender, EventArgs e)
		{
			chooseFont.Location = new Point
			(
				this.Location.X - chooseFont.Width,
				this.Location.Y
			);
			chooseFont.ShowDialog();
			labelCurrentTime.Font = chooseFont.Font;
		}

		//Alarms click event
		private void cmAlarms_Click(object sender, EventArgs e)
		{
			// Ensure the alarms form is not null or disposed
			if (alarmsForm == null || alarmsForm.IsDisposed)
			{
				alarmsForm = new AlarmsForm();
				alarmsForm.FormClosed += AlarmsForm_FormClosed;
			}
			alarmsForm.Show();  // Show form
			alarmsForm.Activate(); // Bring to front
		}

		private void cmLoadOnWindowsStartup_CheckedChanged(object sender, EventArgs e)
		{
			string key_name = "Clock_PD411";
			RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//opens branch for writing
			if (cmLoadOnWindowsStartup.Checked) key.SetValue(key_name, Application.ExecutablePath);
			else key.DeleteValue(key_name, false);//no exeptions if there is no key
			key.Dispose();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}
	}
}