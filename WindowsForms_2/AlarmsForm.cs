using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_2
{
	public partial class AlarmsForm : Form
	{
		public List<Alarm> Alarms { get; set; } = new List<Alarm>();

		public AlarmsForm()
		{
			InitializeComponent();
			LoadAlarms(); // load Alarm data when opening form

			dataGridViewAlarms.AutoGenerateColumns = false;
			// Set up DataGridView columns
			dataGridViewAlarms.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Time", 
				DataPropertyName = "AlarmTime", Width = 120 });
			dataGridViewAlarms.Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = "Enabled", 
				DataPropertyName = "IsEnabled", Width = 60 });
			dataGridViewAlarms.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Sound", 
				DataPropertyName = "SoundPath", Width = 200 });

			dataGridViewAlarms.DataSource = Alarms; // Set datasource
		}

		// Load existing Alarm data
		private void LoadAlarms()
		{
			try
			{
				if (File.Exists("Alarms.txt"))
				{
					string[] lines = File.ReadAllLines("Alarms.txt");
					foreach (string line in lines)
					{
						string[] parts = line.Split('|');
						if (parts.Length == 3)
						{
							DateTime alarmTime = DateTime.Parse(parts[0]);
							bool isEnabled = bool.Parse(parts[1]);
							string soundPath = parts[2];

							Alarms.Add(new Alarm { AlarmTime = alarmTime, IsEnabled = isEnabled, 
								SoundPath = soundPath });
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading alarms: " + ex.Message);
			}
		}

		// Save Alarm data
		private void SaveAlarms()
		{
			try
			{
				List<string> lines = new List<string>();
				foreach (Alarm alarm in Alarms)
				{
					lines.Add($"{alarm.AlarmTime}|{alarm.IsEnabled}|{alarm.SoundPath}");
				}
				File.WriteAllLines("Alarms.txt", lines);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving alarms: " + ex.Message);
			}
		}

		private void btnAddAlarm_Click(object sender, EventArgs e)
		{
			AddAlarmForm addAlarmForm = new AddAlarmForm();
			if (addAlarmForm.ShowDialog() == DialogResult.OK)
			{
				Alarms.Add(addAlarmForm.NewAlarm);
				RefreshDataGridView(); // Refresh Gridview to display new items.
				SaveAlarms(); // Save data
			}
		}

		// Helper method to refresh the DataGridView
		public void RefreshDataGridView()
		{
			dataGridViewAlarms.Refresh();
		}

		private void btnBrowseSound_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (dataGridViewAlarms.SelectedRows.Count > 0)
				{
					Alarm selectedAlarm = (Alarm)dataGridViewAlarms.SelectedRows[0].DataBoundItem;
					selectedAlarm.SoundPath = openFileDialog.FileName;
					RefreshDataGridView(); // refresh to show new item.
					SaveAlarms();
				}
			}
		}

		private void AlarmsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveAlarms(); // Save Alarm data before closing.
		}
	}
}