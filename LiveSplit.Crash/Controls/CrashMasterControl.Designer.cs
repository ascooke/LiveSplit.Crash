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
			this.crash2Control1 = new LiveSplit.Crash.Controls.Crash2Control();
			this.SuspendLayout();
			// 
			// crash2Control1
			// 
			this.crash2Control1.Location = new System.Drawing.Point(4, 4);
			this.crash2Control1.Name = "crash2Control1";
			this.crash2Control1.Size = new System.Drawing.Size(418, 219);
			this.crash2Control1.TabIndex = 0;
			// 
			// CrashMasterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.crash2Control1);
			this.Name = "CrashMasterControl";
			this.Size = new System.Drawing.Size(507, 274);
			this.ResumeLayout(false);

		}

		#endregion

		private Crash2Control crash2Control1;
	}
}
