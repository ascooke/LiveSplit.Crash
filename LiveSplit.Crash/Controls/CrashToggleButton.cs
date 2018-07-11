using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Crash.Controls
{
	public class CrashToggleButton : CheckBox
	{
		public CrashToggleButton()
		{
			Appearance = Appearance.Button;
			TextAlign = ContentAlignment.MiddleCenter;
			AutoSize = false;
		}

		public object UserData { get; set; }
	}
}
