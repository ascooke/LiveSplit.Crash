using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Memory
{
	public class StringPointer
	{
		private int[] offsets;
		private string currentValue;

		public StringPointer(params int[] offsets)
		{
			this.offsets = offsets;
		}

		// Setting the process publicly is easier than passing it into functions repeatedly.
		public Process Process { get; set; }
		public event Action<string, string> OnValueChange;

		public string Read()
		{
			return Process.ReadAscii(Process.MainModule.BaseAddress, offsets);
		}

		public void Refresh()
		{
			string newValue = Read();

			if (currentValue != newValue)
			{
				currentValue = newValue;
				OnValueChange?.Invoke(currentValue, newValue);
			}
		}
	}
}
