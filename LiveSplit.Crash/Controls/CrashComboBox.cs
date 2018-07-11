using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashComboBox : ComboBox
	{
		private int previousIndex = -1;

		public CrashComboBox()
		{
			InitializeComponent();
			DrawMode = DrawMode.OwnerDrawFixed;
			DropDownStyle = ComboBoxStyle.DropDownList;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			// See https://stackoverflow.com/questions/10335753/is-there-any-way-to-visually-divide-the-items-in-a-combobox.
			e.DrawBackground();

			if (e.State == DrawItemState.Focus)
			{
				e.DrawFocusRectangle();
			}

			if (e.Index == -1)
			{
				return;
			}

			string value = Items[e.Index].ToString();

			if (value == "-")
			{
				int y = e.Bounds.Y + e.Bounds.Height / 2;

				e.Graphics.DrawLine(SystemPens.ButtonShadow, e.Bounds.X, y, e.Bounds.Right, y);
			}
			else
			{
				using (var brush = new SolidBrush(e.ForeColor))
				{
					e.Graphics.DrawString(value, e.Font, brush, e.Bounds);
				}
			}

			base.OnDrawItem(e);
		}

		protected override void OnSelectedValueChanged(EventArgs e)
		{
			if (SelectedItem != null && SelectedItem.ToString() == "-")
			{
				SelectedIndex = previousIndex;
				SelectedItem = previousIndex >= 0 ? Items[previousIndex] : null;
			}
			else
			{
				previousIndex = SelectedIndex;
			}

			base.OnSelectedValueChanged(e);
		}
	}
}
