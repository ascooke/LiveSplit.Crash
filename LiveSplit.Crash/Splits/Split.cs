using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Splits
{
	public class Split
	{
		public int Crystals { get; set; } = -1;
		public int Gems { get; set; } = -1;

		public ColoredGems ColoredGem { get; set; } = ColoredGems.None;

		public bool Boss { get; set; }
	}
}
