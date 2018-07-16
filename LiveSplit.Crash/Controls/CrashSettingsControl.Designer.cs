namespace LiveSplit.Crash.Controls
{
	partial class CrashSettingsControl
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
			this.addGameButton = new System.Windows.Forms.Button();
			this.settingsBox = new System.Windows.Forms.GroupBox();
			this.displayRelicsCheckbox = new System.Windows.Forms.CheckBox();
			this.displayBoxesCheckbox = new System.Windows.Forms.CheckBox();
			this.gamesBox = new System.Windows.Forms.GroupBox();
			this.settingsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// addGameButton
			// 
			this.addGameButton.Image = global::LiveSplit.Crash.Properties.Resources.Add;
			this.addGameButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.addGameButton.Location = new System.Drawing.Point(4, 182);
			this.addGameButton.Name = "addGameButton";
			this.addGameButton.Size = new System.Drawing.Size(80, 32);
			this.addGameButton.TabIndex = 0;
			this.addGameButton.Text = "Add Game";
			this.addGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.addGameButton.UseVisualStyleBackColor = true;
			this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.displayRelicsCheckbox);
			this.settingsBox.Controls.Add(this.displayBoxesCheckbox);
			this.settingsBox.Location = new System.Drawing.Point(4, 4);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Size = new System.Drawing.Size(442, 66);
			this.settingsBox.TabIndex = 1;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Settings";
			// 
			// displayRelicsCheckbox
			// 
			this.displayRelicsCheckbox.AutoSize = true;
			this.displayRelicsCheckbox.Checked = true;
			this.displayRelicsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.displayRelicsCheckbox.Location = new System.Drawing.Point(7, 43);
			this.displayRelicsCheckbox.Name = "displayRelicsCheckbox";
			this.displayRelicsCheckbox.Size = new System.Drawing.Size(109, 17);
			this.displayRelicsCheckbox.TabIndex = 1;
			this.displayRelicsCheckbox.Text = "Display relic times";
			this.displayRelicsCheckbox.UseVisualStyleBackColor = true;
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
			// 
			// gamesBox
			// 
			this.gamesBox.Location = new System.Drawing.Point(4, 76);
			this.gamesBox.Name = "gamesBox";
			this.gamesBox.Size = new System.Drawing.Size(442, 100);
			this.gamesBox.TabIndex = 2;
			this.gamesBox.TabStop = false;
			this.gamesBox.Text = "Games";
			// 
			// CrashSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gamesBox);
			this.Controls.Add(this.settingsBox);
			this.Controls.Add(this.addGameButton);
			this.Name = "CrashSettingsControl";
			this.Size = new System.Drawing.Size(451, 545);
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button addGameButton;
		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.CheckBox displayRelicsCheckbox;
		private System.Windows.Forms.CheckBox displayBoxesCheckbox;
		private System.Windows.Forms.GroupBox gamesBox;
	}
}
