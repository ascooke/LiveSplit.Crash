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
	public partial class CrashGameControl : UserControl
	{
		private int selectedIndex;

		public CrashGameControl()
		{
			InitializeComponent();

			crash1Button.UserData = new GameData(0, Resources.Crash1, crash2Button, crash3Button);
			crash2Button.UserData = new GameData(1, Resources.Crash2, crash1Button, crash3Button);
			crash3Button.UserData = new GameData(2, Resources.Crash3, crash1Button, crash2Button);

			// This button must be checked after setting user data on each button.
			crash1Button.Checked = true;
		}

		private void crashButton_CheckedChanged(object sender, EventArgs e)
		{
			CrashToggleButton button = (CrashToggleButton)sender;
			GameData data = (GameData)button.UserData;

			if (button.Checked)
			{
				selectedIndex = data.Index;

				foreach (var other in data.OtherButtons)
				{
					if (other.Checked)
					{
						other.Checked = false;
					}
				}

				if (Parent != null)
				{
					var box = (GroupBox)Parent;
					var parent = (CrashControl)box.Parent;

					parent.UpdateImage(data.Image);
				}
			}
			else if (data.Index == selectedIndex)
			{
				button.Checked = true;
			}
		}

		private class GameData
		{
			public GameData(int index, Image image, CrashToggleButton other1, CrashToggleButton other2)
			{
				Index = index;
				Image = image;
				OtherButtons = new []
				{
					other1,
					other2
				};
			}

			public Image Image { get; }
			public CrashToggleButton[] OtherButtons { get; }

			public int Index { get; }
		}
	}
}
