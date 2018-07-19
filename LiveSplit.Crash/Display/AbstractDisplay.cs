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
	public abstract class AbstractDisplay
	{
		private SimpleLabel label;

		protected AbstractDisplay(string label)
		{
			this.label = new SimpleLabel
			{
				Text = label,
				HorizontalAlignment = StringAlignment.Near,
				VerticalAlignment = StringAlignment.Center
			};
		}

		public float VerticalOffset { get; set; }

		protected void FillBackground(Graphics g, LiveSplitState state, float width, float height)
		{
			Color backgroundColor = state.LayoutSettings.BackgroundColor;

			if (backgroundColor.ToArgb() != Color.Transparent.ToArgb())
			{
				g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, width, height);
			}
		}

		public virtual void Draw(Graphics g, LiveSplitState state, float width, float height)
		{
			FillBackground(g, state, width, height);

			var settings = state.LayoutSettings;

			label.Font = settings.TextFont;
			label.ForeColor = settings.TextColor;
			label.ShadowColor = settings.ShadowsColor;
			label.OutlineColor = settings.TextOutlineColor;
			label.X = 5;
			label.Y = VerticalOffset;
			label.Width = width - 10;
			label.Height = 31;
			label.Draw(g);
		}
	}
}
