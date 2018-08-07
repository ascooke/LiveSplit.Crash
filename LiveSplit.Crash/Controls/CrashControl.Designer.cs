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
			this.categoryBox = new System.Windows.Forms.GroupBox();
			this.categoryComboBox = new System.Windows.Forms.ComboBox();
			this.detectCheckbox = new System.Windows.Forms.CheckBox();
			this.gameComboBox = new System.Windows.Forms.ComboBox();
			this.settingsBox.SuspendLayout();
			this.categoryBox.SuspendLayout();
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
			this.boxCheckbox.Location = new System.Drawing.Point(7, 20);
			this.boxCheckbox.Name = "boxCheckbox";
			this.boxCheckbox.Size = new System.Drawing.Size(91, 17);
			this.boxCheckbox.TabIndex = 0;
			this.boxCheckbox.Text = "Display boxes";
			this.boxCheckbox.UseVisualStyleBackColor = true;
			this.boxCheckbox.CheckedChanged += new System.EventHandler(this.displayCheckbox_CheckedChanged);
			// 
			// categoryBox
			// 
			this.categoryBox.Controls.Add(this.categoryComboBox);
			this.categoryBox.Controls.Add(this.detectCheckbox);
			this.categoryBox.Controls.Add(this.gameComboBox);
			this.categoryBox.Location = new System.Drawing.Point(10, 83);
			this.categoryBox.Name = "categoryBox";
			this.categoryBox.Size = new System.Drawing.Size(456, 72);
			this.categoryBox.TabIndex = 2;
			this.categoryBox.TabStop = false;
			this.categoryBox.Text = "Category";
			// 
			// categoryComboBox
			// 
			this.categoryComboBox.Enabled = false;
			this.categoryComboBox.FormattingEnabled = true;
			this.categoryComboBox.Location = new System.Drawing.Point(134, 43);
			this.categoryComboBox.Name = "categoryComboBox";
			this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
			this.categoryComboBox.TabIndex = 2;
			this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
			// 
			// detectCheckbox
			// 
			this.detectCheckbox.AutoSize = true;
			this.detectCheckbox.Checked = true;
			this.detectCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.detectCheckbox.Location = new System.Drawing.Point(7, 20);
			this.detectCheckbox.Name = "detectCheckbox";
			this.detectCheckbox.Size = new System.Drawing.Size(165, 17);
			this.detectCheckbox.TabIndex = 1;
			this.detectCheckbox.Text = "Automatically detect category";
			this.detectCheckbox.UseVisualStyleBackColor = true;
			this.detectCheckbox.CheckedChanged += new System.EventHandler(this.detectCheckbox_CheckedChanged);
			// 
			// gameComboBox
			// 
			this.gameComboBox.Enabled = false;
			this.gameComboBox.FormattingEnabled = true;
			this.gameComboBox.Items.AddRange(new object[] {
            "Crash 1",
            "Crash 2",
            "Crash 3",
            "Trilogy"});
			this.gameComboBox.Location = new System.Drawing.Point(6, 43);
			this.gameComboBox.Name = "gameComboBox";
			this.gameComboBox.Size = new System.Drawing.Size(121, 21);
			this.gameComboBox.TabIndex = 0;
			this.gameComboBox.SelectedIndexChanged += new System.EventHandler(this.gameComboBox_SelectedIndexChanged);
			// 
			// CrashControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.categoryBox);
			this.Controls.Add(this.settingsBox);
			this.Name = "CrashControl";
			this.Size = new System.Drawing.Size(467, 156);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.categoryBox.ResumeLayout(false);
			this.categoryBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.CheckBox relicCheckbox;
		private System.Windows.Forms.CheckBox boxCheckbox;
		private System.Windows.Forms.CheckBox swapCheckbox;
		private System.Windows.Forms.GroupBox categoryBox;
		private System.Windows.Forms.ComboBox categoryComboBox;
		private System.Windows.Forms.CheckBox detectCheckbox;
		private System.Windows.Forms.ComboBox gameComboBox;
	}
}
