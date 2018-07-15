using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Crash.Controls;
using LiveSplit.Crash.Memory;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.Crash
{
	public class CrashComponent : IComponent
	{
		private TimerModel timer;
		private CrashMemory memory;
		private CrashEvents events;

		private bool processHooked;
		private bool simpleMode;

		public CrashComponent()
		{
			memory = new CrashMemory();
			events = new CrashEvents(memory);
			events.LoadStart += OnLoadStart;
			events.LoadEnd += OnLoadEnd;
		}

		public string ComponentName => "Crash Bandicoot NST Autosplitter (Memory-Based)";

		public float HorizontalWidth => 0;
		public float MinimumHeight => 0;
		public float VerticalHeight => 0;
		public float MinimumWidth => 0;
		public float PaddingTop => 0;
		public float PaddingBottom => 0;
		public float PaddingLeft => 0;
		public float PaddingRight => 0;

		public IDictionary<string, Action> ContextMenuControls => null;

		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
		{
		}

		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
		{
		}

		public Control GetSettingsControl(LayoutMode mode)
		{
			return new CrashMasterControl();
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			return null;
		}

		public void SetSettings(XmlNode settings)
		{
		}

		private void OnLoadStart()
		{
			Console.WriteLine("Load start.");
			//timer.CurrentState.IsGameTimePaused = true;
		}

		private void OnLoadEnd()
		{
			Console.WriteLine("Load end.");
			//timer.CurrentState.IsGameTimePaused = false;
		}

		private void OnStart(object sender, EventArgs e)
		{
			timer.InitializeGameTime();
		}

		private void OnReset(object sender, TimerPhase phase)
		{
		}

		public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
		{
			if (timer == null)
			{
				timer = new TimerModel
				{
					CurrentState = state
				};

				timer.CurrentState.OnStart += OnStart;
				timer.CurrentState.OnReset += OnReset;
			}
			
			Autosplit();
		}

		// This function is public for use in the tester class.
		public void Autosplit()
		{
			bool processPreviouslyHooked = processHooked;
			
			processHooked = memory.HookProcess();

			if (processHooked ^ processPreviouslyHooked)
			{
				if (!processHooked)
				{
					return;
				}
			}

			events.Refresh();
			//timer.CurrentState.SetGameTime(timer.CurrentState.GameTimePauseTime);
		}

		public void Dispose()
		{
		}
	}
}
