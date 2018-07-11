namespace LiveSplit.Crash.Controls
{
	partial class Crash2Control
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
			this.categoryBox = new System.Windows.Forms.GroupBox();
			this.anyPercentCheckbox = new System.Windows.Forms.CheckBox();
			this.anyPercentHelpButton = new System.Windows.Forms.Button();
			this.Splits = new System.Windows.Forms.GroupBox();
			this.addSplitButton = new System.Windows.Forms.Button();
			this.saveSplitsButton = new System.Windows.Forms.Button();
			this.splitCountLabel = new System.Windows.Forms.Label();
			this.categoryBox.SuspendLayout();
			this.Splits.SuspendLayout();
			this.SuspendLayout();
			// 
			// categoryBox
			// 
			this.categoryBox.Controls.Add(this.anyPercentHelpButton);
			this.categoryBox.Controls.Add(this.anyPercentCheckbox);
			this.categoryBox.Location = new System.Drawing.Point(3, 3);
			this.categoryBox.Name = "categoryBox";
			this.categoryBox.Size = new System.Drawing.Size(412, 48);
			this.categoryBox.TabIndex = 3;
			this.categoryBox.TabStop = false;
			this.categoryBox.Text = "Settings";
			// 
			// anyPercentCheckbox
			// 
			this.anyPercentCheckbox.AutoSize = true;
			this.anyPercentCheckbox.Location = new System.Drawing.Point(7, 20);
			this.anyPercentCheckbox.Name = "anyPercentCheckbox";
			this.anyPercentCheckbox.Size = new System.Drawing.Size(82, 17);
			this.anyPercentCheckbox.TabIndex = 0;
			this.anyPercentCheckbox.Text = "Any% Mode";
			this.anyPercentCheckbox.UseVisualStyleBackColor = true;
			// 
			// anyPercentHelpButton
			// 
			this.anyPercentHelpButton.Image = global::LiveSplit.Crash.Properties.Resources.Question;
			this.anyPercentHelpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.anyPercentHelpButton.Location = new System.Drawing.Point(95, 15);
			this.anyPercentHelpButton.Name = "anyPercentHelpButton";
			this.anyPercentHelpButton.Size = new System.Drawing.Size(135, 24);
			this.anyPercentHelpButton.TabIndex = 1;
			this.anyPercentHelpButton.Text = "What does this mean?";
			this.anyPercentHelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.anyPercentHelpButton.UseVisualStyleBackColor = true;
			// 
			// Splits
			// 
			this.Splits.Controls.Add(this.splitCountLabel);
			this.Splits.Controls.Add(this.saveSplitsButton);
			this.Splits.Controls.Add(this.addSplitButton);
			this.Splits.Location = new System.Drawing.Point(4, 58);
			this.Splits.Name = "Splits";
			this.Splits.Size = new System.Drawing.Size(411, 158);
			this.Splits.TabIndex = 4;
			this.Splits.TabStop = false;
			this.Splits.Text = "Splits";
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
			// splitCountLabel
			// 
			this.splitCountLabel.AutoSize = true;
			this.splitCountLabel.Location = new System.Drawing.Point(164, 26);
			this.splitCountLabel.Name = "splitCountLabel";
			this.splitCountLabel.Size = new System.Drawing.Size(51, 13);
			this.splitCountLabel.TabIndex = 2;
			this.splitCountLabel.Text = "100 splits";
			// 
			// Crash2Control
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Splits);
			this.Controls.Add(this.categoryBox);
			this.Name = "Crash2Control";
			this.Size = new System.Drawing.Size(418, 219);
			this.categoryBox.ResumeLayout(false);
			this.categoryBox.PerformLayout();
			this.Splits.ResumeLayout(false);
			this.Splits.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox categoryBox;
		private System.Windows.Forms.Button anyPercentHelpButton;
		private System.Windows.Forms.CheckBox anyPercentCheckbox;
		private System.Windows.Forms.GroupBox Splits;
		private System.Windows.Forms.Button addSplitButton;
		private System.Windows.Forms.Button saveSplitsButton;
		private System.Windows.Forms.Label splitCountLabel;
	}
}
