using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.Crash
{
	public class CrashComponentFactory : IComponentFactory
	{
		public string UpdateName => ComponentName;
		public string XMLURL => "LiveSplit.Crash.Updates.xml";
		public string UpdateURL => "https://raw.githubusercontent.com/Grimelios/LiveSplit.Crash/master/";

		public Version Version => Version.Parse("1.0.0");

		public string ComponentName => "Crash NST Autosplitter (Memory-Based) v" + Version;
		public string Description => "Configurable memory-based autosplitter for Crash Bandicoot N. Sane Trilogy. Works for all three games.";

		public ComponentCategory Category => ComponentCategory.Control;

		public IComponent Create(LiveSplitState state)
		{
			return new CrashComponent();
		}
	}
}
