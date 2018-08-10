using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

		public Version Version
		{
			get
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;

				return Version.Parse($"{version.Major}.{version.Minor}.{version.Build}");
			}
		}

		public string ComponentName => "Crash NST Autosplitter (Memory-Based) v" + Version;
		public string Description => "Configurable memory-based autosplitter for Crash Bandicoot N. Sane Trilogy. Works for all three games.";

		public ComponentCategory Category => ComponentCategory.Control;

		public IComponent Create(LiveSplitState state)
		{
			return new CrashComponent();
		}
	}
}
