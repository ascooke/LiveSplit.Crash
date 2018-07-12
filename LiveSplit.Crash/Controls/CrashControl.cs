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
		// There are three persistent controls in the splits box (two buttons and the number of splits).
		private const int IndexOffset = 3;
		private const int SplitSpacing = 30;

		private Point splitBase;

		public CrashControl()
		{
			InitializeComponent();
			UpdateImage(Resources.Crash1);

			splitBase = new Point(Location.X + 3, addSplitButton.Bounds.Bottom + 7);
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
			Controls.RemoveAt(index + IndexOffset);

			for (int i = index + IndexOffset; i < Controls.Count; i++)
			{
				var split = (CrashSplitControl)Controls[i];

				Point location = split.Location;
				location.Y -= SplitSpacing;
				split.Location = location;
				split.Index--;
			}
		}

		private void addSplitButton_Click(object sender, EventArgs e)
		{
			int index = splitsBox.Controls.Count - IndexOffset;

			splitsBox.Controls.Add(new CrashSplitControl(index, this)
			{
				Location = new Point(splitBase.X, splitBase.Y + (splitsBox.Controls.Count - IndexOffset) * SplitSpacing)
			});
		}
	}
}
