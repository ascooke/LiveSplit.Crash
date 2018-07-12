using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Crash.Properties;

namespace LiveSplit.Crash.Controls.Buttons
{
	public class CrashItemButton : CrashToggleButton
	{
		private static Image[] images =
		{
			Resources.Crystal,
			Resources.ClearGem,
			Resources.RedGem,
			Resources.BlueGem,
			Resources.GreenGem,
			Resources.YellowGem,
			Resources.PurpleGem,
			Resources.Relic
		};

		public CrashItemButton(ItemTypes itemType)
		{
			ItemType = itemType;
			Image = images[(int)itemType];
			Size = new Size(32, 26);
		}

		public ItemTypes ItemType { get; }
	}
}
