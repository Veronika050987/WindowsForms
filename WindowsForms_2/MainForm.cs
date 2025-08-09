using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_2
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		void ShowControls(bool visible)
		{			
			cbShowDate.Visible = visible;
			cbShowWeekday.Visible = visible;
			btnHideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedDialog : FormBorderStyle.None;
			this.labelCurrentTime.BackColor = visible ? this.BackColor : Color.DeepSkyBlue;
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
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			ShowControls(false);
		}

		private void labelCurrentTime_DoubleClick(object sender, EventArgs e)
		{
			ShowControls(true);
		}

		private void cmClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
