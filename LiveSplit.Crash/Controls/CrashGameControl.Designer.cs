namespace LiveSplit.Crash.Controls
{
	partial class CrashGameControl
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
			this.crash3Button = new LiveSplit.Crash.Controls.CrashToggleButton();
			this.crash2Button = new LiveSplit.Crash.Controls.CrashToggleButton();
			this.crash1Button = new LiveSplit.Crash.Controls.CrashToggleButton();
			this.SuspendLayout();
			// 
			// crash3Button
			// 
			this.crash3Button.Appearance = System.Windows.Forms.Appearance.Button;
			this.crash3Button.Location = new System.Drawing.Point(154, 4);
			this.crash3Button.Name = "crash3Button";
			this.crash3Button.Size = new System.Drawing.Size(69, 32);
			this.crash3Button.TabIndex = 2;
			this.crash3Button.Text = "Crash 3";
			this.crash3Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.crash3Button.UserData = null;
			this.crash3Button.UseVisualStyleBackColor = true;
			this.crash3Button.CheckedChanged += new System.EventHandler(this.crashButton_CheckedChanged);
			// 
			// crash2Button
			// 
			this.crash2Button.Appearance = System.Windows.Forms.Appearance.Button;
			this.crash2Button.Location = new System.Drawing.Point(79, 4);
			this.crash2Button.Name = "crash2Button";
			this.crash2Button.Size = new System.Drawing.Size(69, 32);
			this.crash2Button.TabIndex = 1;
			this.crash2Button.Text = "Crash 2";
			this.crash2Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.crash2Button.UserData = null;
			this.crash2Button.UseVisualStyleBackColor = true;
			this.crash2Button.CheckedChanged += new System.EventHandler(this.crashButton_CheckedChanged);
			// 
			// crash1Button
			// 
			this.crash1Button.Appearance = System.Windows.Forms.Appearance.Button;
			this.crash1Button.Location = new System.Drawing.Point(4, 4);
			this.crash1Button.Name = "crash1Button";
			this.crash1Button.Size = new System.Drawing.Size(69, 32);
			this.crash1Button.TabIndex = 0;
			this.crash1Button.Text = "Crash 1";
			this.crash1Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.crash1Button.UserData = null;
			this.crash1Button.UseVisualStyleBackColor = true;
			this.crash1Button.CheckedChanged += new System.EventHandler(this.crashButton_CheckedChanged);
			// 
			// CrashGameControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.crash3Button);
			this.Controls.Add(this.crash2Button);
			this.Controls.Add(this.crash1Button);
			this.Name = "CrashGameControl";
			this.Size = new System.Drawing.Size(227, 40);
			this.ResumeLayout(false);

		}

		#endregion

		private CrashToggleButton crash1Button;
		private CrashToggleButton crash2Button;
		private CrashToggleButton crash3Button;
	}
}
