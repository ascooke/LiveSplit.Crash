using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Crash.Data;
using LiveSplit.Crash.Memory;

namespace LiveSplit.Crash
{
	public class CrashEvents
	{
		private CrashMemory memory;

		private int boxes;
		private float fade;

		private Stages stage = Stages.None;

		public CrashEvents(CrashMemory memory)
		{
			this.memory = memory;
		}

		public event Action LoadStart;
		public event Action LoadEnd;
		public event Action<StageData> StageEnter;
		public event Action StageLeave;
		public event Action<int> BoxChange;

		public void Refresh()
		{
			float oldFade = fade;
			fade = memory.GetFade();

			// Fade start
			if (oldFade == 0 && fade > 0)
			{
				LoadStart.Invoke();
			}
			// Fade end
			else if (oldFade > 0 && fade == 0)
			{
				LoadEnd.Invoke();
			}

			Stages oldStage = stage;
			stage = memory.GetStage();

			if (stage != oldStage)
			{
				if (stage != Stages.None)
				{
					Console.WriteLine($"Entering stage {stage}.");

					StageEnter.Invoke(null);
				}
				else
				{
					//Console.WriteLine($"Leaving stage {oldStage}.");

					//StageLeave.Invoke();
				}
			}
		}
	}
}
