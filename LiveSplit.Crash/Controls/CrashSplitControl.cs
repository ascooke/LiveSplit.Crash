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
using LiveSplit.Crash.Controls.Buttons;
using LiveSplit.Crash.Data;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashSplitControl : UserControl
	{
		private static StageData[] dataArray;

		static CrashSplitControl()
		{
			XmlDocument document = new XmlDocument();
			document.Load("Xml/Crash2.xml");
			
			var elements = document.DocumentElement.GetElementsByTagName("Stage");

			dataArray = new StageData[elements.Count];

			for (int i = 0; i < elements.Count; i++)
			{
				var element = elements[i];
				var crystalAttribute = element.Attributes["Crystals"];
				var gemAttribute = element.Attributes["Gems"];
				var coloredGemAttribute = element.Attributes["ColoredGem"];

				int crystals = crystalAttribute != null ? int.Parse(crystalAttribute.Value) : 0;
				int gems = gemAttribute != null ? int.Parse(gemAttribute.Value) : 0;

				ColoredGems coloredGem = coloredGemAttribute != null
					? (ColoredGems)Enum.Parse(typeof(ColoredGems), coloredGemAttribute.Value)
					: ColoredGems.None;

				//dataArray[i] = new StageData(crystals, gems, coloredGem);
			}
		}

		private int index;
		private int selectedIndex = -1;

		private CrashControl parent;

		public CrashSplitControl(int index, CrashControl parent)
		{
			this.parent = parent;

			InitializeComponent();
			Index = index;
			upButton.Enabled = index > 0;
		}

		public int Index
		{
			get => index;
			set
			{
				index = value;
				indexLabel.Text = index + 1 + ".";
			}
		}

		public Button UpButton => upButton;
		public Button DownButton => downButton;

		private void stageComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int newIndex = stageComboBox.SelectedIndex;

			if (selectedIndex == newIndex)
			{
				return;
			}

			// Each split has five controls that are always present (index, combo box, and three buttons).
			int removalCount = Controls.Count - 5;

			for (int i = 0; i < removalCount; i++)
			{
				Controls.RemoveAt(Controls.Count - 1);
			}

			if (stageComboBox.SelectedItem.ToString() == "-")
			{
				return;
			}

			selectedIndex = newIndex;

			int effectiveIndex = newIndex - newIndex / 7;

			// Every 6th entry is a boss.
			if (effectiveIndex > 0 && effectiveIndex % 6 == 5)
			{
				return;
			}

			StageData data = dataArray[effectiveIndex - effectiveIndex / 6];

			var typeList = new List<ItemTypes>();

			if (data.Crystals == 1)
			{
				typeList.Add(ItemTypes.Crystal);
			}

			for (int i = 0; i < data.Gems; i++)
			{
				typeList.Add(ItemTypes.ClearGem);
			}

			if (data.ColoredGem != ColoredGems.None)
			{
				typeList.Add((ItemTypes)((int)data.ColoredGem + 2));
			}

			typeList.Add(ItemTypes.Relic);

			int startX = stageComboBox.Bounds.Right + 4;

			for (int i = 0; i < typeList.Count; i++)
			{
				Controls.Add(new CrashItemButton(typeList[i])
				{
					Location = new Point(startX + i * 36, 2)
				});
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			parent.RemoveSplit(index);
		}

		private void upButton_Click(object sender, EventArgs e)
		{
			parent.MoveUp(index);
		}

		private void downButton_Click(object sender, EventArgs e)
		{
			parent.MoveDown(index);
		}
	}
}
