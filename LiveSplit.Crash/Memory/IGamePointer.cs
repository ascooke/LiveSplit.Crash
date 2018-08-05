using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash.Memory
{
	// This inteface is a convenience in order to group pointers together in the memory class. It's basically just a subset of
	// GamePointer functionality.
	public interface IGamePointer
	{
		Process Process { get; set; }

		bool RefreshEnabled { get; set; }

		void Refresh();
	}
}
