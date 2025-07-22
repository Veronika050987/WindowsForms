using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO; // for StreamWriter

namespace WindowsForms_1
{
	public partial class MainForm : Form
	{
		private bool consoleAllocated = false; // flag for console
		private StreamWriter consoleWriter = null; // to add StreamWriter
		private Font currentTimeFont = new Font("Microsoft Sans Serif", 32);
		//private FontDialog fontDialog = new FontDialog(); // FontDialog

		private Color currentTimeTextColor = Color.Black; // Default text color
		private Color currentTimeBackColor = Color.Empty; // Default background color (transparent if FormBorderStyle is None)
		private Image currentTimeBackgroundImage = null; // Add image background
		private ColorDialog colorDialog = new ColorDialog(); // ColorDialog

		private OpenFileDialog imageFileDialog = new OpenFileDialog();

		public MainForm()
		{
			InitializeComponent();
			ShowControls(cmShowControls.Checked);
			labelCurrentTime.Font = currentTimeFont; // Apply default font
			UpdateTimeLabelLocation();
		}

		void ShowControls(bool visible)
		{
			cbShowDate.Visible = visible;
			cbShowWeekDay.Visible = visible;
			btnHideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedDialog : FormBorderStyle.None;
			this.labelCurrentTime.BackColor = visible ? this.BackColor : Color.DeepSkyBlue;
		}

		void ShowConsole(bool visible)
		{
			try
			{
				if (visible && !consoleAllocated)
				{
					consoleAllocated = AllocConsole();
					if (!consoleAllocated)
					{
						MessageBox.Show("Failed to allocate console!", "Error", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						return; // exit if console is not given
					}

					try
					{
						// StreamWriter initialisation after AllocConsole
						consoleWriter = new StreamWriter(Console.OpenStandardOutput());
						consoleWriter.AutoFlush = true; // Attention!
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Failed to create StreamWriter: {ex.Message}", "Error", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						FreeConsole();
						consoleAllocated = false;
						return;
					}
				}
				else if (!visible && consoleAllocated)
				{
					if (consoleWriter != null)
					{
						consoleWriter.Close();
						consoleWriter = null;
					}

					bool freed = FreeConsole();
					if (freed)
					{
						consoleAllocated = false;
					}
					else
					{
						MessageBox.Show("Failed to free console!", "Error", MessageBoxButtons.OK, 
							MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error showing/hiding console: {ex.Message}", "Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
			if (cbShowWeekDay.Checked)
				labelCurrentTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIcon.Text = labelCurrentTime.Text;

			if (cmDebugConsole.Checked && consoleAllocated && consoleWriter != null)
			{
				try
				{
					consoleWriter.WriteLine(notifyIcon.Text); // using StreamWriter
				}
				catch (IOException ex)
				{
					Console.Error.WriteLine($"Error writing to console: {ex.Message}"); 
					// Handle potential IO exception
				}
			}
		}

		private void UpdateDateTimeLabels()
		{
			// Always update current time
			labelCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");

			// Update date if checkbox is checked
			cbShowDate.Visible = cbShowDate.Checked;
			cbShowDate.Text = cbShowDate.Checked ? DateTime.Now.ToString("yyyy.MM.dd") : "";

			// Update weekday if checkbox is checked
			cbShowWeekDay.Visible = cbShowWeekDay.Checked;
			cbShowWeekDay.Text = cbShowWeekDay.Checked ? DateTime.Now.DayOfWeek.ToString() : "";

			// Adjust label positions
			cbShowDate.Location = new Point(labelCurrentTime.Left, labelCurrentTime.Bottom);
			cbShowWeekDay.Location = new Point(labelCurrentTime.Left, cbShowDate.Checked ? 
				cbShowDate.Bottom : labelCurrentTime.Bottom);
		}


		private void UpdateTimeLabelLocation()
		{
			int x = this.ClientSize.Width - labelCurrentTime.Width - 10;  // 10 pixels from the right edge
			int y = 10;  // 10 pixels from the top edge

			// Update the location
			labelCurrentTime.Location = new Point(x, y);
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

		private void cbShowControl_CheckedChanged(object sender, EventArgs e)
		{
			ShowControls(cmShowControls.Checked);
		}
		//////////////////////////////////////
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

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			UpdateTimeLabelLocation();
		}

		private void cmFont_DoubleClick(object sender, EventArgs e)
		{
			fontDialog.Font = currentTimeFont; //Set a default font from currentTimeFont
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				currentTimeFont = fontDialog.Font;
				labelCurrentTime.Font = currentTimeFont; //Apply font to label
				UpdateTimeLabelLocation(); //Update labels position after font changed
			}
		}
	}
}