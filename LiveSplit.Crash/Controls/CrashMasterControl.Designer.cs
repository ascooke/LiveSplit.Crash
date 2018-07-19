namespace LiveSplit.Crash.Controls
{
	partial class CrashMasterControl
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
			this.displayRelicsCheckbox = new System.Windows.Forms.CheckBox();
			this.displayBoxesCheckbox = new System.Windows.Forms.CheckBox();
			this.settingsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.swapCheckbox);
			this.settingsBox.Controls.Add(this.displayRelicsCheckbox);
			this.settingsBox.Controls.Add(this.displayBoxesCheckbox);
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
			// displayRelicsCheckbox
			// 
			this.displayRelicsCheckbox.AutoSize = true;
			this.displayRelicsCheckbox.Location = new System.Drawing.Point(7, 43);
			this.displayRelicsCheckbox.Name = "displayRelicsCheckbox";
			this.displayRelicsCheckbox.Size = new System.Drawing.Size(109, 17);
			this.displayRelicsCheckbox.TabIndex = 1;
			this.displayRelicsCheckbox.Text = "Display relic times";
			this.displayRelicsCheckbox.UseVisualStyleBackColor = true;
			this.displayRelicsCheckbox.CheckedChanged += new System.EventHandler(this.displayCheckbox_CheckedChanged);
			// 
			// displayBoxesCheckbox
			// 
			this.displayBoxesCheckbox.AutoSize = true;
			this.displayBoxesCheckbox.Location = new System.Drawing.Point(7, 20);
			this.displayBoxesCheckbox.Name = "displayBoxesCheckbox";
			this.displayBoxesCheckbox.Size = new System.Drawing.Size(91, 17);
			this.displayBoxesCheckbox.TabIndex = 0;
			this.displayBoxesCheckbox.Text = "Display boxes";
			this.displayBoxesCheckbox.UseVisualStyleBackColor = true;
			this.displayBoxesCheckbox.CheckedChanged += new System.EventHandler(this.displayCheckbox_CheckedChanged);
			// 
			// CrashMasterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.settingsBox);
			this.Name = "CrashMasterControl";
			this.Size = new System.Drawing.Size(467, 77);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.CheckBox displayRelicsCheckbox;
		private System.Windows.Forms.CheckBox displayBoxesCheckbox;
		private System.Windows.Forms.CheckBox swapCheckbox;
	}
}
