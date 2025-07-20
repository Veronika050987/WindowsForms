using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class MainForm : Form
	{
		private Label labelCurrentDate;
		private Label labelWeekDay;
		private Label labelFranceTime;
		public MainForm()
		{
			InitializeComponent();

			// Create label for date
			labelCurrentDate = new Label();
			labelCurrentDate.Location = new Point(LabelCurrentTime.Left, LabelCurrentTime.Bottom + 70);
			labelCurrentDate.AutoSize = true;
			Controls.Add(labelCurrentDate);
			labelCurrentDate.Visible = false;

			// Create label for WeekDay
			labelWeekDay = new Label();
			labelWeekDay.Location = new Point(LabelCurrentTime.Left, labelCurrentDate.Bottom + 10); // Под датой или под временем если даты нет
			labelWeekDay.AutoSize = true;
			Controls.Add(labelWeekDay);
			labelWeekDay.Visible = false;

			// Create label for France Time
			labelFranceTime = new Label();
			labelFranceTime.Location = new Point(LabelCurrentTime.Left, LabelCurrentTime.Bottom + 20); // Under weekday
			labelFranceTime.AutoSize = true;
			Controls.Add(labelFranceTime);
			labelFranceTime.Visible = false;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			timer.Start();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			LabelCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
			UpdateDateVisibility();
			UpdateWeekDayVisibility();
			UpdateTimeFranceVisibility();
		}

		private void DateShow_CheckedChanged(object sender, EventArgs e)
		{
			UpdateDateVisibility();
			UpdateWeekDayVisibility();
			UpdateTimeFranceVisibility();
		}

		private void WeekDayShow_CheckedChanged(object sender, EventArgs e)
		{
			UpdateWeekDayVisibility();
			UpdateTimeFranceVisibility();
		}

		private void TimeFrance_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTimeFranceVisibility();
		}

		private void UpdateDateVisibility()
		{
			if (DateShow.Checked)
			{
				labelCurrentDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
				labelCurrentDate.Visible = true;
			}
			else
			{
				labelCurrentDate.Visible = false;
			}
		}

		private void UpdateWeekDayVisibility()
		{
			bool showWeekDay = WeekDayShow.Checked; 
			bool showDate = DateShow.Checked; 

			if (showWeekDay)
			{
				labelWeekDay.Text = DateTime.Now.ToString("dddd");
				labelWeekDay.Visible = true;
				
				labelWeekDay.Location = new Point(LabelCurrentTime.Left, (showDate ? labelCurrentDate.Bottom : LabelCurrentTime.Bottom) + 70);

			}
			else
			{
				labelWeekDay.Visible = false;
			}
		}

		private void UpdateTimeFranceVisibility()
		{
			bool showFranceTime = TimeFrance.Checked;
			bool showWeekDay = WeekDayShow.Checked;
			bool showDate = DateShow.Checked;
			if (showFranceTime)
			{
				try
				{
					TimeZoneInfo franceZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
					DateTime franceTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, franceZone);
					labelFranceTime.Text = "France: " + franceTime.ToString("HH:mm:ss");
					labelFranceTime.Visible = true;
					labelFranceTime.Location = new Point(LabelCurrentTime.Left, (showWeekDay ? labelWeekDay.Bottom : (showDate ? labelCurrentDate.Bottom : LabelCurrentTime.Bottom)) + 70);

				}
				catch (TimeZoneNotFoundException)
				{
					labelFranceTime.Text = "Time zone not found!";
					labelFranceTime.Visible = true;
				}
			}
			else
			{
				labelFranceTime.Visible = false;
			}
		}
	}
}
