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
			CrashTestingForm form = new CrashTestingForm();
			form.ShowDialog();

			/*
			CrashComponent component = new CrashComponent();

			Console.WriteLine("Component created.\n");

			while (true)
			{
				component.Autosplit();

				Thread.Sleep((int)(1000f / Tick));
			}
			*/
		}
	}
}
