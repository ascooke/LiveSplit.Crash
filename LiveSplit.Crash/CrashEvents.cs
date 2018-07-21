using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Crash.Controls;
using LiveSplit.Crash.Data;
using LiveSplit.Crash.Memory;

namespace LiveSplit.Crash
{
	public class CrashEvents
	{
		private CrashMemory memory;
		private CrashControl settings;

		private int boxes;
		private float fade;
		private bool paused;

		private Stages stage = Stages.Invalid;

		public CrashEvents(CrashMemory memory, CrashControl settings)
		{
			this.memory = memory;
			this.settings = settings;
		}

		public event Action FadeStart;
		public event Action FadeEnd;
		public event Action LoadStart;
		public event Action LoadEnd;
		public event Action<Stages> StageChange;
		public event Action<int> BoxChange;

		public void Refresh()
		{
			float oldFade = fade;
			fade = memory.GetFade();
			
			if (oldFade == 0 && fade > 0)
			{
				FadeStart.Invoke();
			}
			else if (oldFade > 0 && fade == 0)
			{
				FadeEnd.Invoke();
			}

			Stages oldStage = stage;
			stage = memory.GetStage();

			if (stage != oldStage && stage != Stages.Invalid)
			{
				StageChange.Invoke(stage);
			}

			//if (settings.DisplayBoxes)
			{
				int oldBoxes = boxes;
				boxes = memory.GetBoxes();

				if (boxes != oldBoxes)
				{
					BoxChange.Invoke(boxes);
				}
			}

			bool oldPaused = paused;
			paused = memory.IsPaused();

			if (paused ^ oldPaused)
			{
				Console.WriteLine(paused ? "Paused." : "Unpaused.");
			}
		}
	}
}
