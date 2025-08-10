using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_2
{
	public partial class AddAlarmForm : Form
	{
		public Alarm NewAlarm { get; set; }

		public AddAlarmForm()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			NewAlarm = new Alarm
			{
				AlarmTime = dateTimePickerAlarmTime.Value,
				IsEnabled = true,  // Set as Enabled when creating
				SoundPath = string.Empty // No Sound by Default
			};
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
