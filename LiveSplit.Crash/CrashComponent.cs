using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Crash.Controls;
using LiveSplit.Crash.Data;
using LiveSplit.Crash.Display;
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
		private CrashSettingsControl settings;
		private RelicDisplay relicDisplay;
		private BoxDisplay boxDisplay;

		private bool processHooked;
		private bool simpleMode;

		public CrashComponent()
		{
			memory = new CrashMemory();
			events = new CrashEvents(memory);
			events.LoadStart += OnLoadStart;
			events.LoadEnd += OnLoadEnd;
			events.StageEnter += OnStageEnter;
			events.StageLeave += OnStageLeave;
			events.BoxChange += OnBoxChange;

			settings = new CrashSettingsControl();
		}

		public string ComponentName => "Crash Bandicoot NST Autosplitter (Memory-Based)";

		public float HorizontalWidth => 0;
		public float VerticalHeight
		{
			get
			{
				int height = 0;

				if (settings.DisplayBoxes)
				{
					height += 30;
				}

				if (settings.DisplayRelics)
				{
					height += 30;
				}

				return height;
			}
		}

		public float MinimumWidth => 0;
		public float MinimumHeight => 0;
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
			if (settings.DisplayBoxes)
			{
				boxDisplay.Draw(g, state, width, VerticalHeight);
			}

			if (settings.DisplayRelics)
			{
				relicDisplay.Draw(g, state, width, VerticalHeight);
			}
		}

		public Control GetSettingsControl(LayoutMode mode)
		{
			return settings;
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			return settings.SaveSettings(document);
		}

		public void SetSettings(XmlNode settings)
		{
			this.settings.LoadSettings(settings);
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

		private void OnStageEnter(StageData data)
		{
			return;

			boxDisplay.BoxTarget = data.Boxes;
			relicDisplay.Sapphire = data.Sapphire;
			relicDisplay.Gold = data.Gold;
			relicDisplay.Platinum = data.Platinum;
		}

		private void OnStageLeave()
		{
		}

		private void OnBoxChange(int boxes)
		{
			boxDisplay.BoxCount = boxes;
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

			if (settings.DisplayEnabled)
			{
				if (relicDisplay == null)
				{
					boxDisplay = new BoxDisplay();
					relicDisplay = new RelicDisplay();
				}

				invalidator?.Invalidate(0, 0, width, height);
			}
		}

		// This function is public for use in the tester class.
		public void Autosplit()
		{
			bool processPreviouslyHooked = processHooked;
			
			processHooked = memory.HookProcess();

			if (!processHooked && processPreviouslyHooked)
			{
				return;
			}

			events.Refresh();
			//timer.CurrentState.SetGameTime(timer.CurrentState.GameTimePauseTime);
		}

		public void Dispose()
		{
		}
	}
}
