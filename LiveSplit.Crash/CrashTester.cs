using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiveSplit.Crash.Controls;
using LiveSplit.Crash.Memory;

namespace LiveSplit.Crash
{
	public class CrashTester
	{
		private const int Framerate = 10;

		public static void Main(string[] args)
		{
			bool formTesting = false;

			if (formTesting)
			{
				CrashTestingForm form = new CrashTestingForm();
				form.ShowDialog();
			}
			else
			{
				CrashComponent component = new CrashComponent();

				while (true)
				{
					component.Autosplit();

					Thread.Sleep((int)(1000f / Framerate));
				}
			}
		}
	}
}
