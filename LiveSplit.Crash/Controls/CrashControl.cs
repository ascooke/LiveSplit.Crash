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
		private int storedGame = -1;
		private int storedCategory = -1;

		public CrashControl()
		{
			InitializeComponent();
		}

		public bool DisplayBoxes => boxCheckbox.Checked;
		public bool DisplayRelics => relicCheckbox.Checked;
		public bool DisplayEnabled => DisplayBoxes || DisplayRelics;
		public bool SwapOrder => swapCheckbox.Checked;
		public bool AutoDetectEnabled => detectCheckbox.Checked;

		public int Game => gameComboBox.SelectedIndex + 1;

		public Categories Category
		{
			get
			{
				string value = categoryComboBox.SelectedText;

				if (value == "Any%")
				{
					return Categories.AnyPercent;
				}
				
				switch (Game)
				{
					case 1: return categoryComboBox.SelectedIndex == 1 ? Categories.AllGems : Categories.OneOhFivePercent;
					case 2: return Categories.OneHundredPercent;
					case 3: return Categories.OneOhEightPercent;
					case 4: return Categories.TrilogyThreeFifteenPercent;
				}

				return Categories.Unknown;
			}
		}

		public XmlNode SaveSettings(XmlDocument document)
		{
			XmlNode root = document.CreateElement("Settings");

			root.AppendChild(CreateNode(document, "DisplayBoxes", DisplayBoxes));
			root.AppendChild(CreateNode(document, "DisplayRelics", DisplayRelics));
			root.AppendChild(CreateNode(document, "SwapOrder", SwapOrder));
			root.AppendChild(CreateNode(document, "AutoDetect", AutoDetectEnabled));

			if (!AutoDetectEnabled)
			{
				root.AppendChild(CreateNode(document, "Game", gameComboBox.SelectedIndex));
				root.AppendChild(CreateNode(document, "Category", categoryComboBox.SelectedIndex));
			}

			return root;
		}

		private XmlNode CreateNode(XmlDocument document, string tag, object value)
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
			ParseNode(node, "AutoDetect", detectCheckbox);

			if (!AutoDetectEnabled)
			{
				gameComboBox.SelectedIndex = int.Parse(node.SelectSingleNode(".//Game").InnerText);
				categoryComboBox.SelectedIndex = int.Parse(node.SelectSingleNode(".//Category").InnerText);
			}
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

		private void detectCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (detectCheckbox.Checked)
			{
				gameComboBox.Enabled = false;
				gameComboBox.SelectedIndex = -1;
				categoryComboBox.Enabled = false;

				// For some reason, setting selected index to -1 doesn't work as far as actually clearing the dropdown (nor does
				// setting selected text to an empty string).
				categoryComboBox.ResetText();

				return;
			}

			gameComboBox.Enabled = true;
			categoryComboBox.Enabled = true;

			if (storedGame == -1)
			{
				gameComboBox.SelectedIndex = 0;
				categoryComboBox.SelectedIndex = 0;
			}
			else
			{
				gameComboBox.SelectedIndex = storedGame;
				categoryComboBox.SelectedIndex = storedCategory;
			}
		}

		private void gameComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			categoryComboBox.Items.Clear();

			// This function is called when clearing the game list in response to re-checking the detection checkbox.
			if (gameComboBox.SelectedIndex == -1)
			{
				return;
			}

			storedGame = gameComboBox.SelectedIndex;

			switch (storedGame)
			{
				// Crash 1
				case 0:
					categoryComboBox.Items.AddRange(new object[]
					{
						"Any%",
						"All Gems",
						"105%"
					});

					break;

				// Crash 2
				case 1:
					categoryComboBox.Items.AddRange(new object[]
					{
						"Any%",
						"100%",
						"102%"
					});

					break;

				// Crash 3
				case 2:
					categoryComboBox.Items.AddRange(new object[]
					{
						"Any%",
						"108%"
					});

					break;

				// Trilogy
				case 3:
					categoryComboBox.Items.AddRange(new object[]
					{
						"Any%",
						"315%"
					});

					break;
			}
		}

		private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			storedCategory = categoryComboBox.SelectedIndex;
		}
	}
}
