using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LiveSplit.Crash.Data
{
	public class StageData
	{
		public StageData(XmlNode node)
		{
			var crystals = node.Attributes["Crystals"];
			var coloredGem = node.Attributes["ColoredGem"];

			if (crystals != null)
			{
				Crystals = int.Parse(crystals.Value);
			}

			Gems = int.Parse(node.Attributes["Gems"].Value);
			Boxes = int.Parse(node.Attributes["Boxes"].Value);
			Sapphire = node.Attributes["Sapphire"].Value;
			Gold = node.Attributes["Gold"].Value;
			Platinum = node.Attributes["Platinum"].Value;
			ColoredGem = coloredGem != null ? (ColoredGems)Enum.Parse(typeof(ColoredGems), coloredGem.Value) : ColoredGems.None;
		}

		public int Crystals { get; }
		public int Gems { get; }
		public int Boxes { get; }

		public ColoredGems ColoredGem { get; }

		public string Sapphire { get; }
		public string Gold { get; }
		public string Platinum { get; }
	}
}
