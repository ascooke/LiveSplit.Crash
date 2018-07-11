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
using LiveSplit.Crash.Data;

namespace LiveSplit.Crash.Controls
{
	public partial class Crash2SplitControl : UserControl
	{
		private static StageData[] dataArray;

		static Crash2SplitControl()
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

				dataArray[i] = new StageData(crystals, gems, coloredGem);
			}
		}

		public Crash2SplitControl()
		{
			InitializeComponent();
		}

		private void stageComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (stageComboBox.SelectedItem.ToString() == "-")
			{
				return;
			}

			Controls.Clear();
			Controls.Add(stageComboBox);

			int index = stageComboBox.SelectedIndex;
			int effectiveIndex = index - index / 7;

			// Every 6th entry is a boss.
			if (effectiveIndex > 0 && effectiveIndex % 6 == 5)
			{
				return;
			}

			StageData data = dataArray[effectiveIndex - effectiveIndex / 6];

			var typeList = new List<CollectibleTypes>();

			if (data.Crystals == 1)
			{
				typeList.Add(CollectibleTypes.Crystal);
			}

			for (int i = 0; i < data.Gems; i++)
			{
				typeList.Add(CollectibleTypes.ClearGem);
			}

			if (data.ColoredGem != ColoredGems.None)
			{
				typeList.Add((CollectibleTypes)((int)data.ColoredGem + 2));
			}

			int startX = stageComboBox.Bounds.Right + 4;

			for (int i = 0; i < typeList.Count; i++)
			{
				Controls.Add(new CrashCollectibleButton(typeList[i])
				{
					Location = new Point(startX + i * 36, 0)
				});
			}
		}
	}
}
