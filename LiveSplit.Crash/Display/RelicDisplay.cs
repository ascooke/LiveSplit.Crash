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
	public class RelicDisplay : AbstractDisplay
	{
		private SimpleLabel sapphireLabel;
		private SimpleLabel goldLabel;
		private SimpleLabel platinumLabel;

		public RelicDisplay()
		{
			sapphireLabel = new SimpleLabel
			{
				ForeColor = Color.DodgerBlue,
				IsMonospaced = true
			};

			goldLabel = new SimpleLabel
			{
				ForeColor = Color.Goldenrod,
				IsMonospaced = true
			};

			platinumLabel = new SimpleLabel
			{
				ForeColor = Color.Silver,
				IsMonospaced = true
			};
		}

		public void Draw(Graphics g, LiveSplitState state, float width, float height)
		{
			sapphireLabel.Text = "03:03.33";
			sapphireLabel.X = 0;
			goldLabel.Text = "02:02.22";
			goldLabel.X = 100;
			platinumLabel.Text = "01:01.11";
			platinumLabel.X = 200;

			UpdateLabel(g, sapphireLabel, state);
			UpdateLabel(g, goldLabel, state);
			UpdateLabel(g, platinumLabel, state);

			FillBackground(g, state, width, height);

			sapphireLabel.Draw(g);
			goldLabel.Draw(g);
			platinumLabel.Draw(g);
		}

		private void UpdateLabel(Graphics g, SimpleLabel label, LiveSplitState state)
		{
			var settings = state.LayoutSettings;

			label.Font = settings.TextFont;
			label.ShadowColor = settings.ShadowsColor;
			label.OutlineColor = settings.TextOutlineColor;
			label.Width = 100;
			label.Height = 20;
			//label.SetActualWidth(g);
		}
	}
}
