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
	public partial class CrashMasterControl : UserControl
	{
		public CrashMasterControl()
		{
			InitializeComponent();
		}

		public bool DisplayBoxes => displayBoxesCheckbox.Checked;
		public bool DisplayRelics => displayRelicsCheckbox.Checked;
		public bool DisplayEnabled => DisplayBoxes || DisplayRelics;
		public bool SwapOrder => swapCheckbox.Checked;

		public XmlNode SaveSettings(XmlDocument document)
		{
			XmlNode root = document.CreateElement("Settings");

			XmlNode boxNode = document.CreateElement("DisplayBoxes");
			boxNode.InnerText = DisplayBoxes.ToString();
			root.AppendChild(boxNode);

			XmlNode relicNode = document.CreateElement("DisplayRelics");
			relicNode.InnerText = DisplayRelics.ToString();
			root.AppendChild(relicNode);

			XmlNode swapNode = document.CreateElement("SwapOrder");
			swapNode.InnerText = SwapOrder.ToString();
			root.AppendChild(swapNode);

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

			XmlNode swapNode = node.SelectSingleNode(".//SwapOrder");

			if (swapNode != null)
			{
				swapCheckbox.Checked = bool.Parse(swapNode.InnerText);
			}
		}

		private void displayCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			swapCheckbox.Enabled = DisplayBoxes && DisplayRelics;
		}
	}
}
