using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		private const int RetrySeconds = 5;

		private TimerModel timer;
		private CrashMemory memory;
		private CrashEvents events;
		private CrashControl settings;
		private RelicDisplay relicDisplay;
		private BoxDisplay boxDisplay;
		private StageData[] stageArray;
		private DateTime lastTry;

		private bool onTitle;
		private bool inHub;
		private bool inStage;
		private bool firstAttempt = true;
		private bool processHooked;

		public CrashComponent()
		{
			settings = new CrashControl();
			memory = new CrashMemory();
			events = new CrashEvents(memory, settings);
			events.FadeStart += OnFadeStart;
			events.FadeEnd += OnFadeEnd;
			events.LoadStart += OnLoadStart;
			events.LoadEnd += OnLoadEnd;
			events.StageChange += OnStageChange;
			events.BoxChange += OnBoxChange;

			StageData[] crash1Data = LoadStageData("Crash1.xml");
			StageData[] crash2Data = LoadStageData("Crash2.xml");
			StageData[] crash3Data = LoadStageData("Crash3.xml");

			stageArray = new StageData[Enum.GetValues(typeof(Stages)).Length];

			for (int i = 0; i < crash1Data.Length; i++)
			{
				stageArray[i + (int)Stages.NSanityBeach] = crash1Data[i];
			}

			for (int i = 0; i < crash2Data.Length; i++)
			{
				stageArray[i + (int)Stages.TurtleWoods] = crash2Data[i];
			}

			for (int i = 0; i < crash3Data.Length; i++)
			{
				stageArray[i + (int)Stages.ToadVillage] = crash3Data[i];
			}

			Console.WriteLine("Component created.");
		}

		public string ComponentName => "Crash NST Autosplitter (Memory-Based)";

		public float HorizontalWidth => 0;
		public float VerticalHeight
		{
			get
			{
				int height = 0;

				if (settings.DisplayBoxes)
				{
					height += 25;
				}

				if (settings.DisplayRelics)
				{
					height += 25;
				}

				return height;
			}
		}

		public float MinimumWidth => 0;
		public float MinimumHeight
		{
			get
			{
				int minimumHeight = 0;

				if (settings.DisplayBoxes)
				{
					minimumHeight += 25;
				}

				if (settings.DisplayRelics)
				{
					minimumHeight += 25;
				}

				return minimumHeight;
			}
		}

		public float PaddingTop => 0;
		public float PaddingBottom => 0;
		public float PaddingLeft => 7;
		public float PaddingRight => 7;

		public IDictionary<string, Action> ContextMenuControls => null;

		private StageData[] LoadStageData(string filename)
		{
			// See https://stackoverflow.com/questions/2820384/reading-embedded-xml-file-c-sharp.
			string result;

			using (Stream stream = GetType().Assembly.GetManifestResourceStream("LiveSplit.Crash.Xml." + filename))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					result = reader.ReadToEnd();
				}
			}

			XmlDocument document = new XmlDocument();
			document.LoadXml(result);

			var nodes = document.DocumentElement.GetElementsByTagName("Stage");

			StageData[] dataArray = new StageData[nodes.Count];

			for (int i = 0; i < nodes.Count; i++)
			{
				dataArray[i] = new StageData(nodes[i]);
			}

			return dataArray;
		}

		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
		{
		}

		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
		{
			bool boxes = settings.DisplayBoxes;
			bool relics = settings.DisplayRelics;

			if (!boxes && !relics)
			{
				return;
			}

			boxDisplay.VerticalOffset = 0;
			relicDisplay.VerticalOffset = 0;

			float height = 25;

			if (boxes && relics)
			{
				if (settings.SwapOrder)
				{
					boxDisplay.VerticalOffset = height;
				}
				else
				{
					relicDisplay.VerticalOffset = height;
				}
			}

			FillBackground(g, state, width, VerticalHeight);

			if (settings.DisplayBoxes)
			{
				boxDisplay.Draw(g, state, width, height);
			}

			if (settings.DisplayRelics)
			{
				relicDisplay.Draw(g, state, width, height);
			}
		}

		private void FillBackground(Graphics g, LiveSplitState state, float width, float height)
		{
			Color backgroundColor = state.LayoutSettings.BackgroundColor;

			if (backgroundColor.ToArgb() != Color.Transparent.ToArgb())
			{
				g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, width, height);
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

		private void OnFadeStart()
		{
			Console.WriteLine("Fade start.");

			return;

			if (onTitle && timer.CurrentState.CurrentPhase == TimerPhase.NotRunning)
			{
				timer.Start();
				timer.CurrentState.IsGameTimePaused = true;
			}
		}

		private void OnFadeEnd()
		{
			Console.WriteLine("Fade end.");
		}

		private void OnLoadStart()
		{
			Console.WriteLine("Load start.");
			//timer.CurrentState.IsGameTimePaused = true;

			if (inStage && !memory.IsPaused())
			{
				Console.WriteLine("Split.");
				//timer.Split();
			}
		}

		private void OnLoadEnd()
		{
			Console.WriteLine("Load end.");
			//timer.CurrentState.IsGameTimePaused = false;
		}

		private void OnStageChange(Stages stage)
		{
			if (stage == Stages.Title)
			{
				onTitle = true;
				inHub = false;

				Console.WriteLine("Exiting to title.");

				return;
			}

			if (stage == Stages.None)
			{
				return;
			}

			onTitle = false;

			StageData data = stageArray[(int)stage];

			if (data == null)
			{
				inStage = false;
				inHub = true;

				if (boxDisplay != null)
				{
					boxDisplay.Active = false;
				}

				relicDisplay?.Clear();

				Console.WriteLine($"Entering hub {stage}.");

				return;
			}

			Console.WriteLine($"Entering stage {stage} ({data})");

			inStage = true;
			inHub = false;

			if (boxDisplay != null)
			{
				boxDisplay.Active = true;
				boxDisplay.BoxTarget = data.Boxes;
			}

			if (relicDisplay != null)
			{
				relicDisplay.Sapphire = data.Sapphire;
				relicDisplay.Gold = data.Gold;
				relicDisplay.Platinum = data.Platinum;
			}
		}

		private void OnBoxChange(int boxes)
		{
			Console.WriteLine($"Box change ({boxes}).");

			if (boxDisplay != null)
			{
				boxDisplay.BoxCount = boxes;
			}
		}

		private void OnStart(object sender, EventArgs e)
		{
			timer.InitializeGameTime();
		}

		private void OnReset(object sender, TimerPhase phase)
		{
			onTitle = true;
			inHub = false;
			inStage = false;
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
				// Displays are created here so that if display is disabled, the memory isn't wasted.
				if (boxDisplay == null)
				{
					boxDisplay = new BoxDisplay();
				}

				if (relicDisplay == null)
				{
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

			if (processHooked ^ processPreviouslyHooked)
			{
				Console.WriteLine(processHooked ? "Process hooked." : "Process unhooked.");

				if (!processHooked)
				{
					memory.ClearPointers();

					if (boxDisplay != null)
					{
						boxDisplay.Active = false;
					}

					relicDisplay?.Clear();

					return;
				}
			}

			if (!processHooked)
			{
				return;
			}

			if (!memory.PointersAcquired && (firstAttempt || lastTry.AddSeconds(RetrySeconds) <= DateTime.Now))
			{
				firstAttempt = false;

				if (!memory.AcquirePointers())
				{
					lastTry = DateTime.Now;

					Console.WriteLine($"Retrying in {RetrySeconds} seconds.");

					return;
				}
			}

			if (!memory.PointersAcquired)
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
