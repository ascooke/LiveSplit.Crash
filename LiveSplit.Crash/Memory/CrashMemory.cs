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
		private IGamePointer[] pointers;

		public CrashMemory() : base("CrashBandicootNSaneTrilogy")
		{
			Fade = new GamePointer<float>(true, 0x1A69598, 0xA0, 0x40, 0xF8, 0x10, 0x3AC);
			Boxes = new GamePointer<int>(true, 0x1A69A98, 0x70, 0x20, 0x198, 0x70, 0x7F8);
			Title = new GamePointer<int>(false, 0x1AB15D0, 0x50, 0x28, 0x30, 0x88, 0x50);
			Stage = new GamePointer<ulong>(true, 0x1A21808, 0x78, 0x90, 0xC0, 0xA0, 0x460);
			Paused = new GamePointer<bool>(false, 0x1A08548, 0x38, 0x70, 0x90, 0x218, 0x358);
			Credits = new GamePointer<bool>(false, 0x1AAE738, 0xF0, 0x228, 0x3E0, 0x18, 0x4F0);

			pointers = new IGamePointer[]
			{
				Fade,
				Boxes,
				Title,
				Stage,
				Paused,
				Credits
			};
		}
		
		public GamePointer<float> Fade { get; }
		public GamePointer<int> Boxes { get; }
		public GamePointer<int> Title { get; }
		public GamePointer<ulong> Stage { get; }
		public GamePointer<bool> Paused { get; }
		public GamePointer<bool> Credits { get; }

		protected override void OnHook(Process process)
		{
			foreach (IGamePointer p in pointers)
			{
				p.Process = process;
			}
		}

		protected override void OnUnhook()
		{
			foreach (IGamePointer p in pointers)
			{
				p.Process = null;
			}
		}

		public void Refresh()
		{
			foreach (IGamePointer p in pointers)
			{
				if (p.RefreshEnabled)
				{
					p.Refresh();
				}
			}
		}
	}
}
