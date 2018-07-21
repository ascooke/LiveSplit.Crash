using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiveSplit.Crash.Controls;

namespace LiveSplit.Crash
{
	public class CrashTester
	{
		private const int Tick = 100;

		public static void Main(string[] args)
		{
			Console.WriteLine("Hi Hobz o/");

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

					Thread.Sleep((int)(1000f / Tick));
				}
			}
		}
	}
}
