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
			var keys = node.Attributes["Keys"];
			var crystals = node.Attributes["Crystals"];
			var coloredGem = node.Attributes["ColoredGem"];

			if (keys != null)
			{
				Keys = 1;
			}

			if (crystals != null)
			{
				Crystals = 1;
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
		public int Keys { get; }

		public ColoredGems ColoredGem { get; }

		public string Sapphire { get; }
		public string Gold { get; }
		public string Platinum { get; }

		public override string ToString()
		{
			return $"Crystals={Crystals}, Gems={Gems}, ColoredGem={ColoredGem}, Keys={Keys}, Boxes={Boxes}, " +
			       $"Sapphire={Sapphire}, Gold={Gold}, Platinum={Platinum}";
		}
	}
}
