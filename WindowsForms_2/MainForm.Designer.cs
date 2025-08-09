namespace WindowsForms_2
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
			this.labelCurrentTime = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.cbShowDate = new System.Windows.Forms.CheckBox();
			this.cbShowWeekday = new System.Windows.Forms.CheckBox();
			this.btnHideControls = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmTopmost = new System.Windows.Forms.ToolStripMenuItem();
			this.cmShowControls = new System.Windows.Forms.ToolStripMenuItem();
			this.cmDebugConsole = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmShowDate = new System.Windows.Forms.ToolStripMenuItem();
			this.cmShowWeekday = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmFont = new System.Windows.Forms.ToolStripMenuItem();
			this.cmBackColor = new System.Windows.Forms.ToolStripMenuItem();
			this.cmForeColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cmClose = new System.Windows.Forms.ToolStripMenuItem();
			this.cmMainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelCurrentTime
			// 
			this.labelCurrentTime.AutoSize = true;
			this.labelCurrentTime.BackColor = System.Drawing.SystemColors.Control;
			this.labelCurrentTime.ContextMenuStrip = this.cmMainMenu;
			this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentTime.Location = new System.Drawing.Point(12, 9);
			this.labelCurrentTime.Name = "labelCurrentTime";
			this.labelCurrentTime.Size = new System.Drawing.Size(310, 61);
			this.labelCurrentTime.TabIndex = 0;
			this.labelCurrentTime.Text = "currentTime";
			this.labelCurrentTime.DoubleClick += new System.EventHandler(this.labelCurrentTime_DoubleClick);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// cbShowDate
			// 
			this.cbShowDate.AutoSize = true;
			this.cbShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowDate.Location = new System.Drawing.Point(23, 204);
			this.cbShowDate.Name = "cbShowDate";
			this.cbShowDate.Size = new System.Drawing.Size(178, 40);
			this.cbShowDate.TabIndex = 1;
			this.cbShowDate.Text = "Show date";
			this.cbShowDate.UseVisualStyleBackColor = true;
			// 
			// cbShowWeekday
			// 
			this.cbShowWeekday.AutoSize = true;
			this.cbShowWeekday.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowWeekday.Location = new System.Drawing.Point(23, 269);
			this.cbShowWeekday.Name = "cbShowWeekday";
			this.cbShowWeekday.Size = new System.Drawing.Size(238, 40);
			this.cbShowWeekday.TabIndex = 2;
			this.cbShowWeekday.Text = "Show weekday";
			this.cbShowWeekday.UseVisualStyleBackColor = true;
			// 
			// btnHideControls
			// 
			this.btnHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnHideControls.Location = new System.Drawing.Point(23, 352);
			this.btnHideControls.Name = "btnHideControls";
			this.btnHideControls.Size = new System.Drawing.Size(356, 89);
			this.btnHideControls.TabIndex = 3;
			this.btnHideControls.Text = "Hide controls";
			this.btnHideControls.UseVisualStyleBackColor = true;
			this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.cmMainMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// cmMainMenu
			// 
			this.cmMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTopmost,
            this.cmShowControls,
            this.cmDebugConsole,
            this.toolStripSeparator1,
            this.cmShowDate,
            this.cmShowWeekday,
            this.toolStripSeparator2,
            this.cmFont,
            this.cmBackColor,
            this.cmForeColor,
            this.toolStripSeparator3,
            this.cmClose});
			this.cmMainMenu.Name = "cmMainMenu";
			this.cmMainMenu.Size = new System.Drawing.Size(198, 238);
			// 
			// cmTopmost
			// 
			this.cmTopmost.CheckOnClick = true;
			this.cmTopmost.Name = "cmTopmost";
			this.cmTopmost.Size = new System.Drawing.Size(210, 24);
			this.cmTopmost.Text = "Topmost";
			this.cmTopmost.CheckedChanged += new System.EventHandler(this.cmTopmost_CheckedChanged);
			// 
			// cmShowControls
			// 
			this.cmShowControls.CheckOnClick = true;
			this.cmShowControls.Name = "cmShowControls";
			this.cmShowControls.Size = new System.Drawing.Size(210, 24);
			this.cmShowControls.Text = "Show controls";
			this.cmShowControls.CheckedChanged += new System.EventHandler(this.cmShowControls_CheckedChanged);
			// 
			// cmDebugConsole
			// 
			this.cmDebugConsole.CheckOnClick = true;
			this.cmDebugConsole.Name = "cmDebugConsole";
			this.cmDebugConsole.Size = new System.Drawing.Size(210, 24);
			this.cmDebugConsole.Text = "Console";
			this.cmDebugConsole.CheckedChanged += new System.EventHandler(this.cmDebugConsole_CheckedChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
			// 
			// cmShowDate
			// 
			this.cmShowDate.CheckOnClick = true;
			this.cmShowDate.Name = "cmShowDate";
			this.cmShowDate.Size = new System.Drawing.Size(210, 24);
			this.cmShowDate.Text = "Show date";
			this.cmShowDate.CheckedChanged += new System.EventHandler(this.cmShowDate_CheckedChanged);
			// 
			// cmShowWeekday
			// 
			this.cmShowWeekday.CheckOnClick = true;
			this.cmShowWeekday.Name = "cmShowWeekday";
			this.cmShowWeekday.Size = new System.Drawing.Size(210, 24);
			this.cmShowWeekday.Text = "Show weekday";
			this.cmShowWeekday.CheckedChanged += new System.EventHandler(this.cmShowWeekday_CheckedChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
			// 
			// cmFont
			// 
			this.cmFont.Name = "cmFont";
			this.cmFont.Size = new System.Drawing.Size(210, 24);
			this.cmFont.Text = "Font";
			this.cmFont.Click += new System.EventHandler(this.cmFont_Click);
			// 
			// cmBackColor
			// 
			this.cmBackColor.Name = "cmBackColor";
			this.cmBackColor.Size = new System.Drawing.Size(210, 24);
			this.cmBackColor.Text = "Background Color";
			this.cmBackColor.Click += new System.EventHandler(this.cmBackColor_Click);
			// 
			// cmForeColor
			// 
			this.cmForeColor.Name = "cmForeColor";
			this.cmForeColor.Size = new System.Drawing.Size(210, 24);
			this.cmForeColor.Text = "Foreground color";
			this.cmForeColor.Click += new System.EventHandler(this.cmForeColor_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
			// 
			// cmClose
			// 
			this.cmClose.Name = "cmClose";
			this.cmClose.Size = new System.Drawing.Size(210, 24);
			this.cmClose.Text = "Close";
			this.cmClose.Click += new System.EventHandler(this.cmClose_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 498);
			this.Controls.Add(this.btnHideControls);
			this.Controls.Add(this.cbShowWeekday);
			this.Controls.Add(this.cbShowDate);
			this.Controls.Add(this.labelCurrentTime);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Clock";
			this.cmMainMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelCurrentTime;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox cbShowDate;
		private System.Windows.Forms.CheckBox cbShowWeekday;
		private System.Windows.Forms.Button btnHideControls;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip cmMainMenu;
		private System.Windows.Forms.ToolStripMenuItem cmTopmost;
		private System.Windows.Forms.ToolStripMenuItem cmShowControls;
		private System.Windows.Forms.ToolStripMenuItem cmDebugConsole;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem cmShowDate;
		private System.Windows.Forms.ToolStripMenuItem cmShowWeekday;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem cmFont;
		private System.Windows.Forms.ToolStripMenuItem cmBackColor;
		private System.Windows.Forms.ToolStripMenuItem cmForeColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cmClose;
	}
}

