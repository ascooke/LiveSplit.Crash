namespace LiveSplit.Crash.Controls
{
	partial class Crash2SplitControl
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
			this.stageComboBox = new LiveSplit.Crash.Controls.CrashComboBox();
			this.SuspendLayout();
			// 
			// stageComboBox
			// 
			this.stageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.stageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.stageComboBox.Items.AddRange(new object[] {
            "Turtle Woods",
            "Snow Go",
            "Hang Eight",
            "The Pits",
            "Crash Dash",
            "Ripper Roo",
            "-",
            "Air Crash",
            "Snow Biz",
            "Bear It",
            "Crash Crush",
            "The Eel Deal",
            "Komodo Brothers",
            "-",
            "Plant Food",
            "Sewer or Later",
            "Bear Down",
            "Road to Ruin",
            "Un-Bearable",
            "Tiny Tiger",
            "-",
            "Hangin\' Out",
            "Diggin\' It",
            "Cold Hard Crash",
            "Ruination",
            "Bee-Having",
            "Dr. N. Gin",
            "-",
            "Piston It Away",
            "Rock It",
            "Night Fight",
            "Pack Attack",
            "Spaced Out",
            "Dr. Neo Cortex",
            "-",
            "Totally Bear",
            "Totally Fly"});
			this.stageComboBox.Location = new System.Drawing.Point(4, 4);
			this.stageComboBox.Name = "stageComboBox";
			this.stageComboBox.Size = new System.Drawing.Size(121, 21);
			this.stageComboBox.TabIndex = 0;
			this.stageComboBox.SelectedIndexChanged += new System.EventHandler(this.stageComboBox_SelectedIndexChanged);
			// 
			// Crash2SplitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.stageComboBox);
			this.Name = "Crash2SplitControl";
			this.Size = new System.Drawing.Size(622, 139);
			this.ResumeLayout(false);

		}

		#endregion

		private CrashComboBox stageComboBox;
	}
}
