using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.Crash.Controls.Buttons;
using LiveSplit.Crash.Properties;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashGameControl : UserControl
	{
		private int selectedIndex;

		public CrashGameControl()
		{
			InitializeComponent();

			crash1Button.Initialize(0, Resources.Crash1, crash2Button, crash3Button);
			crash2Button.Initialize(1, Resources.Crash2, crash1Button, crash3Button);
			crash3Button.Initialize(2, Resources.Crash3, crash1Button, crash2Button);

			// This button must be checked after setting user data on each button.
			crash1Button.Checked = true;
		}

		private void crashButton_CheckedChanged(object sender, EventArgs e)
		{
			CrashGameButton button = (CrashGameButton)sender;

			if (button.Checked)
			{
				selectedIndex = button.Index;

				foreach (var other in button.OtherButtons)
				{
					if (other.Checked)
					{
						other.Checked = false;
						other.BackColor = Color.FloralWhite;
					}
				}

				if (Parent != null)
				{
					var box = (GroupBox)Parent;
					var parent = (CrashControl)box.Parent;

					parent.UpdateImage(button.Logo);
				}
			}
			else if (button.Index == selectedIndex)
			{
				button.Checked = true;
			}
		}
	}
}
