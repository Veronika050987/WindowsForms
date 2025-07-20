namespace WindowsForms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.LabelCurrentTime = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.DateShow = new System.Windows.Forms.CheckBox();
			this.WeekDayShow = new System.Windows.Forms.CheckBox();
			this.TimeFrance = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// LabelCurrentTime
			// 
			this.LabelCurrentTime.AutoSize = true;
			this.LabelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LabelCurrentTime.Location = new System.Drawing.Point(26, 22);
			this.LabelCurrentTime.Name = "LabelCurrentTime";
			this.LabelCurrentTime.Size = new System.Drawing.Size(310, 61);
			this.LabelCurrentTime.TabIndex = 0;
			this.LabelCurrentTime.Text = "currentTime";
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// DateShow
			// 
			this.DateShow.AutoSize = true;
			this.DateShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DateShow.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.DateShow.Location = new System.Drawing.Point(37, 89);
			this.DateShow.Name = "DateShow";
			this.DateShow.Size = new System.Drawing.Size(91, 20);
			this.DateShow.TabIndex = 1;
			this.DateShow.Text = "DateShow";
			this.DateShow.UseVisualStyleBackColor = true;
			this.DateShow.CheckedChanged += new System.EventHandler(this.DateShow_CheckedChanged);
			// 
			// WeekDayShow
			// 
			this.WeekDayShow.AutoSize = true;
			this.WeekDayShow.ForeColor = System.Drawing.Color.Blue;
			this.WeekDayShow.Location = new System.Drawing.Point(37, 116);
			this.WeekDayShow.Name = "WeekDayShow";
			this.WeekDayShow.Size = new System.Drawing.Size(123, 20);
			this.WeekDayShow.TabIndex = 2;
			this.WeekDayShow.Text = "WeekDayShow";
			this.WeekDayShow.UseVisualStyleBackColor = true;
			// 
			// TimeFrance
			// 
			this.TimeFrance.AutoSize = true;
			this.TimeFrance.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.TimeFrance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.TimeFrance.Location = new System.Drawing.Point(37, 143);
			this.TimeFrance.Name = "TimeFrance";
			this.TimeFrance.Size = new System.Drawing.Size(102, 20);
			this.TimeFrance.TabIndex = 3;
			this.TimeFrance.Text = "TimeFrance";
			this.TimeFrance.UseVisualStyleBackColor = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.TimeFrance);
			this.Controls.Add(this.WeekDayShow);
			this.Controls.Add(this.DateShow);
			this.Controls.Add(this.LabelCurrentTime);
			this.ForeColor = System.Drawing.Color.DarkMagenta;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Clock";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelCurrentTime;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox DateShow;
		private System.Windows.Forms.CheckBox WeekDayShow;
		private System.Windows.Forms.CheckBox TimeFrance;
	}
}

