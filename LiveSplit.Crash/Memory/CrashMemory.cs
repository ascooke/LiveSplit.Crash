using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.Crash.Controls;

namespace LiveSplit.Crash.Memory
{
	public class CrashMemory : GameMemory
	{
		public CrashMemory() : base("CrashBandicootNSaneTrilogy")
		{
			Fade = new GamePointer<float>();
			Boxes = new GamePointer<int>();
			Pause = new GamePointer<bool>();
			Stage = new StringPointer();
		}

		public GamePointer<float> Fade { get; }
		public GamePointer<int> Boxes { get; }
		public GamePointer<bool> Pause { get; }
		public StringPointer Stage { get; }

		protected override void OnHook(Process process)
		{
			Fade.Process = process;
			Boxes.Process = process;
			Pause.Process = process;
			Stage.Process = process;
		}

		protected override void OnUnhook()
		{
			Fade.Process = null;
			Boxes.Process = null;
			Pause.Process = null;
			Stage.Process = null;
		}

		public void Refresh()
		{
			Fade.Refresh();
			Boxes.Refresh();
			Pause.Refresh();
			Stage.Refresh();
		}
	}
}
