using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Controls.Buttons
{
	public class CrashGameButton : CrashToggleButton
	{
		public void Initialize(int index, Image logo, CrashGameButton other1, CrashGameButton other2)
		{
			Index = index;
			Logo = logo;
			OtherButtons = new []
			{
				other1,
				other2
			};
		}

		public Image Logo { get; private set; }
		public CrashGameButton[] OtherButtons { get; private set; }

		public int Index { get; private set; }
	}
}
