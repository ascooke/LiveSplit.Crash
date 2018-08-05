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
			Lives = new GamePointer<int>(true, 0x1A08548, 0x38, 0x70, 0x90, 0xA0, 0x748);
			Stage = new GamePointer<ulong>(true, 0x1A21808, 0x78, 0x90, 0xC0, 0xA0, 0x460);
			Alive = new GamePointer<bool>(true, 0x1A08550, 0x70, 0x4B0, 0x268, 0xB8, 0x3F8);
			Paused = new GamePointer<bool>(true, 0x1A08548, 0x38, 0x70, 0x90, 0x218, 0x358);

			pointers = new IGamePointer[]
			{
				Fade,
				Boxes,
				Lives,
				Stage,
				Paused,
				Alive,
				Paused
			};
		}
		
		public GamePointer<float> Fade { get; }
		public GamePointer<int> Boxes { get; }
		public GamePointer<int> Lives { get; }
		public GamePointer<ulong> Stage { get; }
		public GamePointer<bool> Alive { get; }
		public GamePointer<bool> Paused { get; }

		protected override void OnHook(Process process)
		{
			Console.WriteLine("Process hooked");

			foreach (IGamePointer p in pointers)
			{
				p.Process = process;
			}
		}

		protected override void OnUnhook()
		{
			Console.WriteLine("Process unhooked");

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
