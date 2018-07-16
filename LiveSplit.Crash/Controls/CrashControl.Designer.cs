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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrashControl));
			this.settingsBox = new System.Windows.Forms.GroupBox();
			this.crashLogo = new System.Windows.Forms.PictureBox();
			this.anyPercentHelpButton = new System.Windows.Forms.Button();
			this.simpleModeCheckbox = new System.Windows.Forms.CheckBox();
			this.splitsBox = new System.Windows.Forms.GroupBox();
			this.itemsLabel = new System.Windows.Forms.Label();
			this.stageLabel = new System.Windows.Forms.Label();
			this.splitsPanel = new System.Windows.Forms.Panel();
			this.splitCountLabel = new System.Windows.Forms.Label();
			this.saveSplitsButton = new System.Windows.Forms.Button();
			this.addSplitButton = new System.Windows.Forms.Button();
			this.simpleModeNotification = new System.Windows.Forms.Label();
			this.gameControl = new LiveSplit.Crash.Controls.CrashGameControl();
			this.settingsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.crashLogo)).BeginInit();
			this.splitsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.crashLogo);
			this.settingsBox.Controls.Add(this.gameControl);
			this.settingsBox.Controls.Add(this.anyPercentHelpButton);
			this.settingsBox.Controls.Add(this.simpleModeCheckbox);
			this.settingsBox.Location = new System.Drawing.Point(7, 4);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Size = new System.Drawing.Size(442, 93);
			this.settingsBox.TabIndex = 3;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Settings";
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
			// anyPercentHelpButton
			// 
			this.anyPercentHelpButton.Image = ((System.Drawing.Image)(resources.GetObject("anyPercentHelpButton.Image")));
			this.anyPercentHelpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.anyPercentHelpButton.Location = new System.Drawing.Point(94, 59);
			this.anyPercentHelpButton.Name = "anyPercentHelpButton";
			this.anyPercentHelpButton.Size = new System.Drawing.Size(133, 24);
			this.anyPercentHelpButton.TabIndex = 1;
			this.anyPercentHelpButton.Text = "What does this mean?";
			this.anyPercentHelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.anyPercentHelpButton.UseVisualStyleBackColor = true;
			// 
			// simpleModeCheckbox
			// 
			this.simpleModeCheckbox.AutoSize = true;
			this.simpleModeCheckbox.Checked = true;
			this.simpleModeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.simpleModeCheckbox.Location = new System.Drawing.Point(8, 63);
			this.simpleModeCheckbox.Name = "simpleModeCheckbox";
			this.simpleModeCheckbox.Size = new System.Drawing.Size(87, 17);
			this.simpleModeCheckbox.TabIndex = 0;
			this.simpleModeCheckbox.Text = "Simple Mode";
			this.simpleModeCheckbox.UseVisualStyleBackColor = true;
			this.simpleModeCheckbox.CheckedChanged += new System.EventHandler(this.simpleModeCheckbox_CheckedChanged);
			// 
			// splitsBox
			// 
			this.splitsBox.Controls.Add(this.simpleModeNotification);
			this.splitsBox.Controls.Add(this.itemsLabel);
			this.splitsBox.Controls.Add(this.stageLabel);
			this.splitsBox.Controls.Add(this.splitsPanel);
			this.splitsBox.Controls.Add(this.splitCountLabel);
			this.splitsBox.Controls.Add(this.saveSplitsButton);
			this.splitsBox.Controls.Add(this.addSplitButton);
			this.splitsBox.Location = new System.Drawing.Point(7, 103);
			this.splitsBox.Name = "splitsBox";
			this.splitsBox.Size = new System.Drawing.Size(442, 362);
			this.splitsBox.TabIndex = 4;
			this.splitsBox.TabStop = false;
			this.splitsBox.Text = "Splits";
			// 
			// itemsLabel
			// 
			this.itemsLabel.AutoSize = true;
			this.itemsLabel.Location = new System.Drawing.Point(156, 53);
			this.itemsLabel.Name = "itemsLabel";
			this.itemsLabel.Size = new System.Drawing.Size(32, 13);
			this.itemsLabel.TabIndex = 5;
			this.itemsLabel.Text = "Items";
			this.itemsLabel.Visible = false;
			// 
			// stageLabel
			// 
			this.stageLabel.AutoSize = true;
			this.stageLabel.Location = new System.Drawing.Point(31, 53);
			this.stageLabel.Name = "stageLabel";
			this.stageLabel.Size = new System.Drawing.Size(35, 13);
			this.stageLabel.TabIndex = 4;
			this.stageLabel.Text = "Stage";
			this.stageLabel.Visible = false;
			// 
			// splitsPanel
			// 
			this.splitsPanel.Location = new System.Drawing.Point(9, 68);
			this.splitsPanel.Name = "splitsPanel";
			this.splitsPanel.Size = new System.Drawing.Size(431, 288);
			this.splitsPanel.TabIndex = 3;
			this.splitsPanel.Visible = false;
			// 
			// splitCountLabel
			// 
			this.splitCountLabel.AutoSize = true;
			this.splitCountLabel.Location = new System.Drawing.Point(164, 26);
			this.splitCountLabel.Name = "splitCountLabel";
			this.splitCountLabel.Size = new System.Drawing.Size(39, 13);
			this.splitCountLabel.TabIndex = 2;
			this.splitCountLabel.Text = "0 splits";
			this.splitCountLabel.Visible = false;
			// 
			// saveSplitsButton
			// 
			this.saveSplitsButton.Enabled = false;
			this.saveSplitsButton.Location = new System.Drawing.Point(86, 20);
			this.saveSplitsButton.Name = "saveSplitsButton";
			this.saveSplitsButton.Size = new System.Drawing.Size(72, 24);
			this.saveSplitsButton.TabIndex = 1;
			this.saveSplitsButton.Text = "Save Splits";
			this.saveSplitsButton.UseVisualStyleBackColor = true;
			// 
			// addSplitButton
			// 
			this.addSplitButton.Enabled = false;
			this.addSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("addSplitButton.Image")));
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
			// simpleModeNotification
			// 
			this.simpleModeNotification.AutoSize = true;
			this.simpleModeNotification.Location = new System.Drawing.Point(205, 26);
			this.simpleModeNotification.Name = "simpleModeNotification";
			this.simpleModeNotification.Size = new System.Drawing.Size(191, 13);
			this.simpleModeNotification.TabIndex = 6;
			this.simpleModeNotification.Text = "This section is disabled in simple mode.";
			// 
			// gameControl
			// 
			this.gameControl.Location = new System.Drawing.Point(4, 19);
			this.gameControl.Name = "gameControl";
			this.gameControl.Size = new System.Drawing.Size(227, 40);
			this.gameControl.TabIndex = 4;
			// 
			// CrashControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitsBox);
			this.Controls.Add(this.settingsBox);
			this.Name = "CrashControl";
			this.Size = new System.Drawing.Size(456, 468);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.crashLogo)).EndInit();
			this.splitsBox.ResumeLayout(false);
			this.splitsBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.Button anyPercentHelpButton;
		private System.Windows.Forms.CheckBox simpleModeCheckbox;
		private System.Windows.Forms.GroupBox splitsBox;
		private System.Windows.Forms.Button addSplitButton;
		private System.Windows.Forms.Button saveSplitsButton;
		private System.Windows.Forms.Label splitCountLabel;
		private CrashGameControl gameControl;
		private System.Windows.Forms.PictureBox crashLogo;
		private System.Windows.Forms.Panel splitsPanel;
		private System.Windows.Forms.Label itemsLabel;
		private System.Windows.Forms.Label stageLabel;
		private System.Windows.Forms.Label simpleModeNotification;
	}
}
