namespace WindowsForms_2
{
	partial class AlarmsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmsForm));
			this.dataGridViewAlarms = new System.Windows.Forms.DataGridView();
			this.btnAddAlarm = new System.Windows.Forms.Button();
			this.btnBrowseSound = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarms)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewAlarms
			// 
			this.dataGridViewAlarms.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAlarms.Location = new System.Drawing.Point(110, 21);
			this.dataGridViewAlarms.Name = "dataGridViewAlarms";
			this.dataGridViewAlarms.RowHeadersWidth = 51;
			this.dataGridViewAlarms.RowTemplate.Height = 24;
			this.dataGridViewAlarms.Size = new System.Drawing.Size(240, 150);
			this.dataGridViewAlarms.TabIndex = 0;
			// 
			// btnAddAlarm
			// 
			this.btnAddAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btnAddAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnAddAlarm.Location = new System.Drawing.Point(26, 239);
			this.btnAddAlarm.Name = "btnAddAlarm";
			this.btnAddAlarm.Size = new System.Drawing.Size(189, 43);
			this.btnAddAlarm.TabIndex = 1;
			this.btnAddAlarm.Text = "Add alarm";
			this.btnAddAlarm.UseVisualStyleBackColor = false;
			// 
			// btnBrowseSound
			// 
			this.btnBrowseSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.btnBrowseSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnBrowseSound.Location = new System.Drawing.Point(236, 239);
			this.btnBrowseSound.Name = "btnBrowseSound";
			this.btnBrowseSound.Size = new System.Drawing.Size(189, 43);
			this.btnBrowseSound.TabIndex = 2;
			this.btnBrowseSound.Text = "Browse sound";
			this.btnBrowseSound.UseVisualStyleBackColor = false;
			// 
			// AlarmsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 341);
			this.Controls.Add(this.btnBrowseSound);
			this.Controls.Add(this.btnAddAlarm);
			this.Controls.Add(this.dataGridViewAlarms);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AlarmsForm";
			this.Text = "AlarmsForm";
			this.Load += new System.EventHandler(this.AlarmsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarms)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewAlarms;
		private System.Windows.Forms.Button btnAddAlarm;
		private System.Windows.Forms.Button btnBrowseSound;
	}
}