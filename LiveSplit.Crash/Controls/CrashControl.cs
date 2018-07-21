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
	public partial class CrashControl : UserControl
	{
		public CrashControl()
		{
			InitializeComponent();
		}

		public bool DisplayBoxes => boxCheckbox.Checked;
		public bool DisplayRelics => relicCheckbox.Checked;
		public bool DisplayEnabled => DisplayBoxes || DisplayRelics;
		public bool SwapOrder => swapCheckbox.Checked;

		public XmlNode SaveSettings(XmlDocument document)
		{
			XmlNode root = document.CreateElement("Settings");

			root.AppendChild(CreateNode(document, "DisplayBoxes", DisplayBoxes));
			root.AppendChild(CreateNode(document, "DisplayRelics", DisplayRelics));
			root.AppendChild(CreateNode(document, "SwapOrder", SwapOrder));

			return root;
		}

		private XmlNode CreateNode(XmlDocument document, string tag, bool value)
		{
			XmlNode node = document.CreateElement(tag);
			node.InnerText = value.ToString();

			return node;
		}

		public void LoadSettings(XmlNode node)
		{
			ParseNode(node, "DisplayBoxes", boxCheckbox);
			ParseNode(node, "DisplayRelics", relicCheckbox);
			ParseNode(node, "SwapOrder", swapCheckbox);
		}

		private void ParseNode(XmlNode node, string tag, CheckBox checkbox)
		{
			XmlNode child = node.SelectSingleNode(".//" + tag);

			if (child != null)
			{
				checkbox.Checked = bool.Parse(child.InnerText);
			}
		}

		private void displayCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			swapCheckbox.Enabled = DisplayBoxes && DisplayRelics;
		}
	}
}
