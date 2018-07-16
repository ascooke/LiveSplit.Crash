using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Model;
using LiveSplit.UI;

namespace LiveSplit.Crash.Display
{
	public class BoxDisplay : AbstractDisplay
	{
		private SimpleLabel label;

		public BoxDisplay()
		{
			label = new SimpleLabel
			{
				IsMonospaced = true
			};
		}

		public int BoxCount { get; set; }
		public int BoxTarget { get; set; }

		public override void Draw(Graphics g, LiveSplitState state, float width, float height)
		{
			FillBackground(g, state, width, height);

			var settings = state.LayoutSettings;

			label.Font = settings.TextFont;
			label.ShadowColor = settings.ShadowsColor;
			label.OutlineColor = settings.TextOutlineColor;
			label.Text = BoxCount + "/" + BoxTarget;
			label.Draw(g);
		}
	}
}
