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
		private SimpleLabel value;

		public BoxDisplay() : base("Boxes")
		{
			value = new SimpleLabel
			{
				IsMonospaced = true,
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Center
			};
		}

		public int BoxCount { get; set; }
		public int BoxTarget { get; set; }

		public bool Active { get; set; }

		public override void Draw(Graphics g, LiveSplitState state, float width, float height)
		{
			base.Draw(g, state, width, height);

			var settings = state.LayoutSettings;

			value.Font = settings.TextFont;
			value.ForeColor = settings.TextColor;
			value.ShadowColor = settings.ShadowsColor;
			value.OutlineColor = settings.TextOutlineColor;
			value.Text = Active ? BoxCount + "/" + BoxTarget : "";
			value.X = 5;
			value.Y = VerticalOffset;
			value.Width = width - 12;
			value.Height = 31;
			value.Draw(g);
		}
	}
}
