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
			this.gameControl = new LiveSplit.Crash.Controls.CrashGameControl();
			this.anyPercentHelpButton = new System.Windows.Forms.Button();
			this.anyPercentCheckbox = new System.Windows.Forms.CheckBox();
			this.splitsBox = new System.Windows.Forms.GroupBox();
			this.splitCountLabel = new System.Windows.Forms.Label();
			this.saveSplitsButton = new System.Windows.Forms.Button();
			this.addSplitButton = new System.Windows.Forms.Button();
			this.crashLogo = new System.Windows.Forms.PictureBox();
			this.settingsBox.SuspendLayout();
			this.splitsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.crashLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.crashLogo);
			this.settingsBox.Controls.Add(this.gameControl);
			this.settingsBox.Controls.Add(this.anyPercentHelpButton);
			this.settingsBox.Controls.Add(this.anyPercentCheckbox);
			this.settingsBox.Location = new System.Drawing.Point(7, 4);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Size = new System.Drawing.Size(462, 93);
			this.settingsBox.TabIndex = 3;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Settings";
			// 
			// gameControl
			// 
			this.gameControl.Location = new System.Drawing.Point(4, 16);
			this.gameControl.Name = "gameControl";
			this.gameControl.Size = new System.Drawing.Size(224, 40);
			this.gameControl.TabIndex = 2;
			// 
			// anyPercentHelpButton
			// 
			this.anyPercentHelpButton.Image = global::LiveSplit.Crash.Properties.Resources.Question;
			this.anyPercentHelpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.anyPercentHelpButton.Location = new System.Drawing.Point(92, 59);
			this.anyPercentHelpButton.Name = "anyPercentHelpButton";
			this.anyPercentHelpButton.Size = new System.Drawing.Size(135, 24);
			this.anyPercentHelpButton.TabIndex = 1;
			this.anyPercentHelpButton.Text = "What does this mean?";
			this.anyPercentHelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.anyPercentHelpButton.UseVisualStyleBackColor = true;
			// 
			// anyPercentCheckbox
			// 
			this.anyPercentCheckbox.AutoSize = true;
			this.anyPercentCheckbox.Location = new System.Drawing.Point(9, 63);
			this.anyPercentCheckbox.Name = "anyPercentCheckbox";
			this.anyPercentCheckbox.Size = new System.Drawing.Size(82, 17);
			this.anyPercentCheckbox.TabIndex = 0;
			this.anyPercentCheckbox.Text = "Any% Mode";
			this.anyPercentCheckbox.UseVisualStyleBackColor = true;
			// 
			// splitsBox
			// 
			this.splitsBox.Controls.Add(this.splitCountLabel);
			this.splitsBox.Controls.Add(this.saveSplitsButton);
			this.splitsBox.Controls.Add(this.addSplitButton);
			this.splitsBox.Location = new System.Drawing.Point(7, 103);
			this.splitsBox.Name = "splitsBox";
			this.splitsBox.Size = new System.Drawing.Size(462, 252);
			this.splitsBox.TabIndex = 4;
			this.splitsBox.TabStop = false;
			this.splitsBox.Text = "Splits";
			// 
			// splitCountLabel
			// 
			this.splitCountLabel.AutoSize = true;
			this.splitCountLabel.Location = new System.Drawing.Point(164, 26);
			this.splitCountLabel.Name = "splitCountLabel";
			this.splitCountLabel.Size = new System.Drawing.Size(51, 13);
			this.splitCountLabel.TabIndex = 2;
			this.splitCountLabel.Text = "100 splits";
			// 
			// saveSplitsButton
			// 
			this.saveSplitsButton.Location = new System.Drawing.Point(86, 20);
			this.saveSplitsButton.Name = "saveSplitsButton";
			this.saveSplitsButton.Size = new System.Drawing.Size(72, 24);
			this.saveSplitsButton.TabIndex = 1;
			this.saveSplitsButton.Text = "Save Splits";
			this.saveSplitsButton.UseVisualStyleBackColor = true;
			// 
			// addSplitButton
			// 
			this.addSplitButton.Image = global::LiveSplit.Crash.Properties.Resources.Add;
			this.addSplitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.addSplitButton.Location = new System.Drawing.Point(7, 20);
			this.addSplitButton.Name = "addSplitButton";
			this.addSplitButton.Size = new System.Drawing.Size(72, 24);
			this.addSplitButton.TabIndex = 0;
			this.addSplitButton.Text = "Add Split";
			this.addSplitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.addSplitButton.UseVisualStyleBackColor = true;
			this.addSplitButton.Click += new System.EventHandler(this.addSplitButton_Click);
			// 
			// crashLogo
			// 
			this.crashLogo.InitialImage = null;
			this.crashLogo.Location = new System.Drawing.Point(234, 19);
			this.crashLogo.Name = "crashLogo";
			this.crashLogo.Size = new System.Drawing.Size(120, 64);
			this.crashLogo.TabIndex = 3;
			this.crashLogo.TabStop = false;
			// 
			// CrashControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitsBox);
			this.Controls.Add(this.settingsBox);
			this.Name = "CrashControl";
			this.Size = new System.Drawing.Size(718, 468);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.splitsBox.ResumeLayout(false);
			this.splitsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.crashLogo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.Button anyPercentHelpButton;
		private System.Windows.Forms.CheckBox anyPercentCheckbox;
		private System.Windows.Forms.GroupBox splitsBox;
		private System.Windows.Forms.Button addSplitButton;
		private System.Windows.Forms.Button saveSplitsButton;
		private System.Windows.Forms.Label splitCountLabel;
		private CrashGameControl gameControl;
		private System.Windows.Forms.PictureBox crashLogo;
	}
}
