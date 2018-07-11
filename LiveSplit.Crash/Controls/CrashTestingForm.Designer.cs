namespace LiveSplit.Crash.Controls
{
	partial class CrashTestingForm
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
			this.crashMasterControl1 = new LiveSplit.Crash.Controls.CrashMasterControl();
			this.SuspendLayout();
			// 
			// crashMasterControl1
			// 
			this.crashMasterControl1.Location = new System.Drawing.Point(13, 13);
			this.crashMasterControl1.Name = "crashMasterControl1";
			this.crashMasterControl1.Size = new System.Drawing.Size(507, 274);
			this.crashMasterControl1.TabIndex = 0;
			// 
			// CrashTestingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.crashMasterControl1);
			this.Name = "CrashTestingForm";
			this.Text = "TestingForm";
			this.ResumeLayout(false);

		}

		#endregion

		private CrashMasterControl crashMasterControl1;
	}
}