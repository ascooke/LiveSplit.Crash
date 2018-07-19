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
		private TimerModel timer;
		private CrashMemory memory;
		private CrashEvents events;
		private CrashMasterControl settings;
		private RelicDisplay relicDisplay;
		private BoxDisplay boxDisplay;
		private StageData[] stageArray;

		private bool onTitle;
		private bool inStage;
		private bool processHooked;

		public CrashComponent()
		{
			memory = new CrashMemory();
			settings = new CrashMasterControl();
			events = new CrashEvents(memory);
			events.LoadStart += OnLoadStart;
			events.LoadEnd += OnLoadEnd;
			events.StageChange += OnStageChange;
			events.BoxChange += OnBoxChange;

			relicDisplay = new RelicDisplay();
			boxDisplay = new BoxDisplay();

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
					height += 31;
				}

				if (settings.DisplayRelics)
				{
					height += 31;
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

			float height = VerticalHeight;

			if (boxes && relics)
			{
				if (settings.SwapOrder)
				{
					boxDisplay.VerticalOffset = height / 2;
				}
				else
				{
					relicDisplay.VerticalOffset = height / 2;
				}
			}

			if (settings.DisplayBoxes)
			{
				boxDisplay.Draw(g, state, width, height);
			}

			if (settings.DisplayRelics)
			{
				relicDisplay.Draw(g, state, width, height);
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
			StageData data = stageArray[(int)stage];

			if (data == null)
			{
				inStage = false;
				boxDisplay.Active = false;
				relicDisplay.Clear();

				Console.WriteLine($"Entering stage {stage}.");

				return;
			}

			Console.WriteLine($"Entering stage {stage} (Boxes={data.Boxes}, Sapphire={data.Sapphire}, Gold={data.Gold}, Platinum={data.Platinum}).");

			inStage = true;
			boxDisplay.Active = true;
			boxDisplay.BoxTarget = data.Boxes;
			relicDisplay.Sapphire = data.Sapphire;
			relicDisplay.Gold = data.Gold;
			relicDisplay.Platinum = data.Platinum;
		}

		private void OnBoxChange(int boxes)
		{
			Console.WriteLine($"Box change ({boxes}).");

			boxDisplay.BoxCount = boxes;
		}

		private void OnStart(object sender, EventArgs e)
		{
			timer.InitializeGameTime();
		}

		private void OnReset(object sender, TimerPhase phase)
		{
			onTitle = true;
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
