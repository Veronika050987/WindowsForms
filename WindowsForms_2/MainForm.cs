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

		private void timer_Tick(object sender, EventArgs e)
		{
			labelCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
			//to show AM and PM

			if(cbShowDate.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";

			if (cbShowWeekday.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.DayOfWeek}";
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{

		}
	}
}
