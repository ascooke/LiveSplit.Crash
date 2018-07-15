using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.Crash.Properties;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashControl : UserControl
	{
		private const int SplitSpacing = 28;
		private const int SimpleHeight = 53;
		
		private ControlCollection splitControls;

		public CrashControl()
		{
			InitializeComponent();
			UpdateImage(Resources.Crash1);
			
			splitControls = splitsPanel.Controls;
			splitsBox.Height = SimpleHeight;
		}

		public void UpdateImage(Image image)
		{
			int centerX = (gameControl.Bounds.Right + settingsBox.Bounds.Right - 4) / 2;
			int centerY = settingsBox.Bounds.Y + settingsBox.Bounds.Height / 2;

			crashLogo.Image = image;
			crashLogo.Location = new Point(centerX - image.Width / 2, centerY - image.Height / 2);
		}

		public void RemoveSplit(int index)
		{
			splitControls.RemoveAt(index);

			for (int i = index; i < splitControls.Count; i++)
			{
				var split = (CrashSplitControl)splitControls[i];

				Point location = split.Location;
				location.Y -= SplitSpacing;
				split.Location = location;
				split.Index--;
			}

			if (splitControls.Count > 0)
			{
				if (index == 0)
				{
					((CrashSplitControl)splitControls[0]).UpButton.Enabled = false;
				}
				else if (index == splitControls.Count)
				{
					((CrashSplitControl)splitControls[index - 1]).DownButton.Enabled = false;
				}
			}

			UpdateCount();
		}

		public void MoveUp(int index)
		{
			Swap((CrashSplitControl)splitControls[index], (CrashSplitControl)splitControls[index - 1]);
		}

		public void MoveDown(int index)
		{
			Swap((CrashSplitControl)splitControls[index], (CrashSplitControl)splitControls[index + 1]);
		}

		private void Swap(CrashSplitControl split1, CrashSplitControl split2)
		{
			Point tempLocation = split1.Location;
			split1.Location = split2.Location;
			split2.Location = tempLocation;

			bool tempUp = split1.UpButton.Enabled;
			split1.UpButton.Enabled = split2.UpButton.Enabled;
			split2.UpButton.Enabled = tempUp;

			bool tempDown = split1.DownButton.Enabled;
			split1.DownButton.Enabled = split2.DownButton.Enabled;
			split2.DownButton.Enabled = tempDown;

			int index1 = split1.Index;
			int index2 = split2.Index;
			
			split1.Index = index2;
			split2.Index = index1;

			splitControls.SetChildIndex(split1, index2);
			splitControls.SetChildIndex(split2, index1);
		}

		private void addSplitButton_Click(object sender, EventArgs e)
		{
			int index = splitControls.Count;

			splitControls.Add(new CrashSplitControl(index, this)
			{
				Location = new Point(-5, index * SplitSpacing)
			});

			if (index > 0)
			{
				((CrashSplitControl)splitControls[index - 1]).DownButton.Enabled = true;
			}

			UpdateCount();
		}

		private void UpdateCount()
		{
			int count = splitControls.Count;

			splitCountLabel.Text = count + (count == 1 ? " split" : " splits");
		}

		private void simpleModeCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			bool simpleMode = simpleModeCheckbox.Checked;

			addSplitButton.Enabled = !simpleMode;
			saveSplitsButton.Enabled = !simpleMode;
			splitCountLabel.Visible = !simpleMode;
			simpleModeNotification.Visible = simpleMode;
			splitsPanel.Visible = !simpleMode;
			splitsBox.Height = simpleMode ? SimpleHeight : 400;
		}
	}
}
