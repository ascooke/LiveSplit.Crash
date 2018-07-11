using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Crash.Controls.Buttons
{
	public abstract class CrashToggleButton : CheckBox
	{
		protected CrashToggleButton()
		{
			Appearance = Appearance.Button;
			TextAlign = ContentAlignment.MiddleCenter;
			AutoSize = false;
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 2;

			ResetColors();
		}

		public object UserData { get; set; }

		protected override void OnCheckedChanged(EventArgs e)
		{
			if (Checked)
			{
				BackColor = Color.FromArgb(255, 102, 216, 255);
				FlatAppearance.BorderColor = Color.FromArgb(255, 0, 171, 229);
				FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 145, 234, 255);
				FlatAppearance.MouseDownBackColor = BackColor;
			}
			else
			{
				ResetColors();
			}

			base.OnCheckedChanged(e);
		}

		private void ResetColors()
		{
			BackColor = Color.FloralWhite;
			FlatAppearance.BorderColor = Color.FromArgb(255, 190, 190, 190);
			FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 230, 230, 230);
			FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 215, 215, 215);
		}
	}
}
