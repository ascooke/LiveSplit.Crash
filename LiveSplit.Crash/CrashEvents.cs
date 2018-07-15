using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Crash.Memory;

namespace LiveSplit.Crash
{
	public class CrashEvents
	{
		private CrashMemory memory;

		private float fade;

		public CrashEvents(CrashMemory memory)
		{
			this.memory = memory;
		}

		public event Action LoadStart;
		public event Action LoadEnd;

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
		}
	}
}
