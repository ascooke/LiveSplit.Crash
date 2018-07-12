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
		
		private ControlCollection splitControls;

		public CrashControl()
		{
			InitializeComponent();
			UpdateImage(Resources.Crash1);
			
			splitControls = splitsPanel.Controls;
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

			UpdateCount();
		}

		private void addSplitButton_Click(object sender, EventArgs e)
		{
			int index = splitControls.Count;

			splitControls.Add(new CrashSplitControl(index, this)
			{
				Location = new Point(-5, index * SplitSpacing)
			});

			UpdateCount();
		}

		private void UpdateCount()
		{
			int count = splitControls.Count;

			splitCountLabel.Text = count + (count == 1 ? " split" : " splits");
		}
	}
}
