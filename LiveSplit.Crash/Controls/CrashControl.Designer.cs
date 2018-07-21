namespace LiveSplit.Crash.Controls
{
	partial class CrashControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.settingsBox = new System.Windows.Forms.GroupBox();
			this.swapCheckbox = new System.Windows.Forms.CheckBox();
			this.relicCheckbox = new System.Windows.Forms.CheckBox();
			this.boxCheckbox = new System.Windows.Forms.CheckBox();
			this.settingsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.swapCheckbox);
			this.settingsBox.Controls.Add(this.relicCheckbox);
			this.settingsBox.Controls.Add(this.boxCheckbox);
			this.settingsBox.Location = new System.Drawing.Point(10, 10);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Size = new System.Drawing.Size(456, 66);
			this.settingsBox.TabIndex = 1;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Settings";
			// 
			// swapCheckbox
			// 
			this.swapCheckbox.AutoSize = true;
			this.swapCheckbox.Enabled = false;
			this.swapCheckbox.Location = new System.Drawing.Point(160, 20);
			this.swapCheckbox.Name = "swapCheckbox";
			this.swapCheckbox.Size = new System.Drawing.Size(80, 17);
			this.swapCheckbox.TabIndex = 2;
			this.swapCheckbox.Text = "Swap order";
			this.swapCheckbox.UseVisualStyleBackColor = true;
			// 
			// relicCheckbox
			// 
			this.relicCheckbox.AutoSize = true;
			this.relicCheckbox.Enabled = false;
			this.relicCheckbox.Location = new System.Drawing.Point(7, 43);
			this.relicCheckbox.Name = "relicCheckbox";
			this.relicCheckbox.Size = new System.Drawing.Size(109, 17);
			this.relicCheckbox.TabIndex = 1;
			this.relicCheckbox.Text = "Display relic times";
			this.relicCheckbox.UseVisualStyleBackColor = true;
			this.relicCheckbox.CheckedChanged += new System.EventHandler(this.displayCheckbox_CheckedChanged);
			// 
			// boxCheckbox
			// 
			this.boxCheckbox.AutoSize = true;
			this.boxCheckbox.Enabled = false;
			this.boxCheckbox.Location = new System.Drawing.Point(7, 20);
			this.boxCheckbox.Name = "boxCheckbox";
			this.boxCheckbox.Size = new System.Drawing.Size(91, 17);
			this.boxCheckbox.TabIndex = 0;
			this.boxCheckbox.Text = "Display boxes";
			this.boxCheckbox.UseVisualStyleBackColor = true;
			this.boxCheckbox.CheckedChanged += new System.EventHandler(this.displayCheckbox_CheckedChanged);
			// 
			// CrashControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.settingsBox);
			this.Name = "CrashControl";
			this.Size = new System.Drawing.Size(467, 77);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.CheckBox relicCheckbox;
		private System.Windows.Forms.CheckBox boxCheckbox;
		private System.Windows.Forms.CheckBox swapCheckbox;
	}
}
