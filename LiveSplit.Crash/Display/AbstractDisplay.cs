using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Model;

namespace LiveSplit.Crash.Display
{
	public abstract class AbstractDisplay
	{
		protected void FillBackground(Graphics g, LiveSplitState state, float width, float height)
		{
			Color backgroundColor = state.LayoutSettings.BackgroundColor;

			if (backgroundColor.ToArgb() != Color.Transparent.ToArgb())
			{
				g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, width, height);
			}
		}
	}
}
