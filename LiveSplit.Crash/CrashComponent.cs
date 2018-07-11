using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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

		private bool processHooked;
		private bool anyPercentMode;

		private int crystals = -1;
		private int gems = -1;
		private int lives = -1;
		private int bossesKilled = 0;

		private float fade = 0;

		private Crash2Stages stage = Crash2Stages.None;

		public CrashComponent()
		{
			memory = new CrashMemory();
		}

		public string ComponentName => "Crash Bandicoot N. Sane Trilogy Autosplitter";

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
			return null;
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			return null;
		}

		public void SetSettings(XmlNode settings)
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
					Console.WriteLine("Process unhooked.");

					return;
				}

				Console.WriteLine("Process hooked.");
			}

			int newCrystals = memory.GetCrystals();

			if (crystals != newCrystals)
			{
				Console.WriteLine($"Crystals changed ({crystals} -> {newCrystals}).");

				crystals = newCrystals;
			}

			int newGems = memory.GetGems();

			if (gems != newGems)
			{
				Console.WriteLine($"Gems changed ({gems} -> {newGems}).");

				gems = newGems;
			}

			int newLives = memory.GetLives();

			if (lives != newLives)
			{
				Console.WriteLine($"Lives changed ({lives} -> {newLives}).");

				lives = newLives;
			}

			float oldFade = fade;
			fade = memory.GetFade();

			if (oldFade == 0 && fade > 0)
			{
				Console.WriteLine("Fade started.");
			}
			else if (oldFade > 0 && fade == 0)
			{
				Console.WriteLine("Fade ended.");
			}

			Crash2Stages oldStage = stage;
			stage = memory.GetStage();

			if (stage != oldStage)
			{
				Console.WriteLine($"Entering stage {stage}.");
			}
		}

		public void Dispose()
		{
		}
	}
}
