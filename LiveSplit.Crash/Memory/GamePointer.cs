using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Memory
{
	public class GamePointer<T> : IGamePointer where T : struct, IEquatable<T>
	{
		private int[] offsets;
		private T currentValue;

		public GamePointer(bool refreshEnabled, params int[] offsets)
		{
			this.offsets = offsets;

			RefreshEnabled = refreshEnabled;
		}

		// Setting the process publicly is easier than passing it into functions repeatedly.
		public Process Process { get; set; }
		public bool RefreshEnabled { get; set; }
		public event Action<T, T> OnValueChange;

		public T Read()
		{
			return Process.Read<T>(Process.MainModule.BaseAddress, offsets);
		}

		public void Refresh()
		{
			T newValue = Read();

			if (!newValue.Equals(currentValue))
			{
				OnValueChange?.Invoke(currentValue, newValue);
				currentValue = newValue;
			}
		}
	}
}
