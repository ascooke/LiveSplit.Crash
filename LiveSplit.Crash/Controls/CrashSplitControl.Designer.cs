namespace LiveSplit.Crash.Controls
{
	partial class CrashSplitControl
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
			this.indexLabel = new System.Windows.Forms.Label();
			this.upButton = new System.Windows.Forms.Button();
			this.downButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
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
			this.stageComboBox.Location = new System.Drawing.Point(27, 5);
			this.stageComboBox.Name = "stageComboBox";
			this.stageComboBox.Size = new System.Drawing.Size(121, 21);
			this.stageComboBox.TabIndex = 0;
			this.stageComboBox.SelectedIndexChanged += new System.EventHandler(this.stageComboBox_SelectedIndexChanged);
			// 
			// indexLabel
			// 
			this.indexLabel.AutoSize = true;
			this.indexLabel.Location = new System.Drawing.Point(4, 9);
			this.indexLabel.Name = "indexLabel";
			this.indexLabel.Size = new System.Drawing.Size(22, 13);
			this.indexLabel.TabIndex = 1;
			this.indexLabel.Text = "99.";
			// 
			// upButton
			// 
			this.upButton.Image = global::LiveSplit.Crash.Properties.Resources.Up;
			this.upButton.Location = new System.Drawing.Point(329, 4);
			this.upButton.Name = "upButton";
			this.upButton.Size = new System.Drawing.Size(38, 23);
			this.upButton.TabIndex = 2;
			this.upButton.UseVisualStyleBackColor = true;
			// 
			// downButton
			// 
			this.downButton.Image = global::LiveSplit.Crash.Properties.Resources.Down;
			this.downButton.Location = new System.Drawing.Point(370, 4);
			this.downButton.Name = "downButton";
			this.downButton.Size = new System.Drawing.Size(38, 23);
			this.downButton.TabIndex = 3;
			this.downButton.UseVisualStyleBackColor = true;
			// 
			// deleteButton
			// 
			this.deleteButton.Image = global::LiveSplit.Crash.Properties.Resources.Delete;
			this.deleteButton.Location = new System.Drawing.Point(411, 4);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(38, 23);
			this.deleteButton.TabIndex = 4;
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// CrashSplitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.downButton);
			this.Controls.Add(this.upButton);
			this.Controls.Add(this.indexLabel);
			this.Controls.Add(this.stageComboBox);
			this.Name = "CrashSplitControl";
			this.Size = new System.Drawing.Size(453, 32);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CrashComboBox stageComboBox;
		private System.Windows.Forms.Label indexLabel;
		private System.Windows.Forms.Button upButton;
		private System.Windows.Forms.Button downButton;
		private System.Windows.Forms.Button deleteButton;
	}
}
