using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Data
{
	public class StageData
	{
		public StageData(int crystals, int gems, ColoredGems coloredGem)
		{
			Crystals = crystals;
			Gems = gems;
			ColoredGem = coloredGem;
		}

		public int Crystals { get; }
		public int Gems { get; }

		public ColoredGems ColoredGem { get; }
	}
}
