using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
			Fade = new GamePointer<float>("Fade", true, 0x1A69598, 0xA0, 0x40, 0xF8, 0x10, 0x3AC);
			Boxes = new GamePointer<int>("Box", true, 0x1A69A98, 0x70, 0x20, 0x198, 0x70, 0x7F8);
			Title = new GamePointer<int>("Title", false, 0x1AB15D0, 0x50, 0x28, 0x30, 0x88, 0x50);
			Stage = new GamePointer<ulong>("Stage", true, 0x1A21808, 0x78, 0x90, 0xC0, 0xA0, 0x460);
			Paused = new GamePointer<bool>("Pause", false, 0x1A08548, 0x38, 0x70, 0x90, 0x218, 0x358);
			EnteringGame = new GamePointer<bool>("Entering Game", false, 0x1A91610, 0x50, 0x50, 0x28, 0x18, 0x520);

			// Pointers are ordered alphabetically to make logging a bit nicer. There's no performance difference regardless.
			pointers = new IGamePointer[]
			{
				Boxes,
				EnteringGame,
				Fade,
				Paused,
				Stage,
				Title
			};
		}
		
		public GamePointer<float> Fade { get; }
		public GamePointer<int> Boxes { get; }
		public GamePointer<int> Title { get; }
		public GamePointer<ulong> Stage { get; }
		public GamePointer<bool> Paused { get; }
		public GamePointer<bool> EnteringGame { get; }

		protected override void OnHook(Process process)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine($"[Memory] Process hooked ({DateTime.Now}).");

			for (int i = 0; i < pointers.Length; i++)
			{
				IGamePointer p = pointers[i];
				p.Process = process;
				p.Validate();

				string value = $"[Memory] {p.Name} pointer {(p.IsPointerValid ? "valid" : "invalid")}.";

				if (i == pointers.Length - 1)
				{
					builder.Append(value);
				}
				else
				{
					builder.AppendLine(value);
				}
			}

			Logging.Write(builder.ToString());
		}

		protected override void OnUnhook()
		{
			Logging.Write("[Memory] Process unhooked.");

			foreach (IGamePointer p in pointers)
			{
				p.Process = null;
			}
		}

		public void Refresh()
		{
			foreach (IGamePointer p in pointers)
			{
				if (p.IsPointerValid && p.IsRefreshEnabled)
				{
					p.Refresh();
				}
			}
		}
	}
}
