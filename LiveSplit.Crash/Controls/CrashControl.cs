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
		public CrashControl()
		{
			InitializeComponent();
			UpdateImage(Resources.Crash1);
		}

		public void UpdateImage(Image image)
		{
			int centerX = (gameControl.Bounds.Right + settingsBox.Bounds.Right - 4) / 2;
			int centerY = settingsBox.Bounds.Y + settingsBox.Bounds.Height / 2;

			crashLogo.Image = image;
			crashLogo.Location = new Point(centerX - image.Width / 2, centerY - image.Height / 2);
		}
	}
}
