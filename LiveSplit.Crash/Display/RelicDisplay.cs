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

		public RelicDisplay() : base("Relics")
		{
			sapphireLabel = new SimpleLabel
			{
				ForeColor = Color.DodgerBlue,
				IsMonospaced = true,
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Center
			};

			goldLabel = new SimpleLabel
			{
				ForeColor = Color.Goldenrod,
				IsMonospaced = true,
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Center
			};

			platinumLabel = new SimpleLabel
			{
				ForeColor = Color.Silver,
				IsMonospaced = true,
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Center
			};
		}

		public string Sapphire { set => sapphireLabel.Text = value; }
		public string Gold { set => goldLabel.Text = value; }
		public string Platinum { set => platinumLabel.Text = value; }

		public override void Draw(Graphics g, LiveSplitState state, float width, float height)
		{
			base.Draw(g, state, width, height);

			sapphireLabel.Text = "3:03.33";
			goldLabel.Text = "2:02.22";
			platinumLabel.Text = "1:01.11";

			float spacing = 50;

			UpdateLabel(sapphireLabel, state, width, height, spacing * 2);
			UpdateLabel(goldLabel, state, width, height, spacing);
			UpdateLabel(platinumLabel, state, width, height, 0);

			sapphireLabel.Draw(g);
			goldLabel.Draw(g);
			platinumLabel.Draw(g);
		}

		private void UpdateLabel(SimpleLabel label, LiveSplitState state, float width, float height, float spacing)
		{
			var settings = state.LayoutSettings;

			label.Font = settings.TextFont;
			label.ShadowColor = settings.ShadowsColor;
			label.OutlineColor = settings.TextOutlineColor;
			label.X = 5;
			label.Y = VerticalOffset;
			label.Width = width - 12 - spacing;
			label.Height = 31;
		}
	}
}
