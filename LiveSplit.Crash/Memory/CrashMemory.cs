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
			Fade = new GamePointer<float>(0x1A69598, 0xA0, 0x40, 0xF8, 0x10, 0x3AC);
			Boxes = new GamePointer<int>(0x1A69A98, 0x70, 0x20, 0x198, 0x70, 0x7F8);
			Stage = new GamePointer<ulong>(0x1A21808, 0x78, 0x90, 0xC0, 0xA0, 0x460);
		}
		
		public GamePointer<float> Fade { get; }
		public GamePointer<int> Boxes { get; }
		public GamePointer<ulong> Stage { get; }

		protected override void OnHook(Process process)
		{
			Fade.Process = process;
			Boxes.Process = process;
			Stage.Process = process;
		}

		protected override void OnUnhook()
		{
			Fade.Process = null;
			Boxes.Process = null;
			Stage.Process = null;
		}

		public void Refresh()
		{
			Fade.Refresh();
			Boxes.Refresh();
			Stage.Refresh();
		}
	}
}
