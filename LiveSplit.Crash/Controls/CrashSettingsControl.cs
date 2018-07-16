using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashSettingsControl : UserControl
	{
		public CrashSettingsControl()
		{
			InitializeComponent();
		}

		public bool DisplayBoxes => displayBoxesCheckbox.Checked;
		public bool DisplayRelics => displayRelicsCheckbox.Checked;
		public bool DisplayEnabled => DisplayBoxes || DisplayRelics;

		private void addGameButton_Click(object sender, EventArgs e)
		{
			AddGame();
		}

		private void AddGame()
		{
			var control = new CrashControl();

			Controls.Add(control);
			addGameButton.Location = new Point(addGameButton.Location.X, control.Bounds.Bottom + 4);
		}

		public XmlNode SaveSettings(XmlDocument document)
		{
			XmlNode root = document.CreateElement("Settings");

			XmlNode boxNode = document.CreateElement("DisplayBoxes");
			boxNode.InnerText = DisplayBoxes.ToString();
			root.AppendChild(boxNode);

			XmlNode relicNode = document.CreateElement("DisplayRelics");
			relicNode.InnerText = DisplayRelics.ToString();
			root.AppendChild(relicNode);

			return root;
		}

		public void LoadSettings(XmlNode node)
		{
			XmlNode boxNode = node.SelectSingleNode(".//DisplayBoxes");

			if (boxNode != null)
			{
				displayBoxesCheckbox.Checked = bool.Parse(boxNode.InnerText);
			}

			XmlNode relicNode = node.SelectSingleNode(".//DisplayRelics");

			if (relicNode != null)
			{
				displayRelicsCheckbox.Checked = bool.Parse(relicNode.InnerText);
			}
		}
	}
}
