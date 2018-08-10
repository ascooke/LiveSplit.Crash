using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
		private const int RetryTime = 10;
		
		private TimerModel timer;
		private CrashMemory memory;
		private CrashControl settings;
		private BoxDisplay boxDisplay;
		private RelicDisplay relicDisplay;
		private StageData[] stageArray;
		private Dictionary<string, Stages> stageMap;
		private HashSet<Stages> hubSet;
		private DateTime transitionTime;
		
		private bool firstLoad;
		private bool startedFromTitle;
		private bool loading;
		private bool inHub;
		private bool inBoss;
		private bool inStage;

		public CrashComponent()
		{
			settings = new CrashControl();
			memory = new CrashMemory();
			memory.Fade.OnValueChange += OnFadeChange;
			memory.Stage.OnValueChange += OnStageChange;
			memory.Boxes.OnValueChange += (oldBoxes, newBoxes) =>
			{
				if (settings.DisplayBoxes)
				{
					boxDisplay.BoxCount = newBoxes;
				}
			};

			hubSet = new HashSet<Stages>
			{
				Stages.TheWumpaIslands,
				Stages.NSanityIsland,
				Stages.CortexIsland,
				Stages.TheWarpRoom,
				Stages.TheTimeTwister
			};

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

			stageMap = new Dictionary<string, Stages>
			{
				// Crash 1
				{ "N. SANITY BEACH", Stages.NSanityBeach },
				{ "JUNGLE ROLLERS", Stages.JungleRollers },
				{ "THE GREAT GATE", Stages.TheGreatGate },
				{ "BOULDERS", Stages.Boulders },
				{ "UPSTREAM", Stages.Upstream },
				{ "ROLLING STONES", Stages.RollingStones },
				{ "HOG WILD", Stages.HogWild },
				{ "NATIVE FORTRESS", Stages.NativeFortress },
				{ "UP THE CREEK", Stages.UpTheCreek },
				{ "THE LOST CITY", Stages.TheLostCity },
				{ "TEMPLE RUINS", Stages.TempleRuins },
				{ "ROAD TO NOWHERE", Stages.RoadToNowhere },
				{ "BOULDER DASH", Stages.BoulderDash },
				{ "WHOLE HOG", Stages.WholeHog },
				{ "SUNSET VISTA", Stages.SunsetVista },
				{ "HEAVY MACHINERY", Stages.HeavyMachinery },
				{ "CORTEX POWER", Stages.CortexPower },
				{ "GENERATOR ROOM", Stages.GeneratorRoom },
				{ "TOXIC WASTE", Stages.ToxicWaste },
				{ "THE HIGH ROAD", Stages.TheHighRoad },
				{ "SLIPPERY CLIMB", Stages.SlipperyClimb },
				{ "LIGHTS OUT", Stages.LightsOut },
				{ "FUMBLING IN THE DARK", Stages.FumblingInTheDark },
				{ "JAWS OF DARKNESS", Stages.JawsOfDarkness },
				{ "CASTLE MACHINERY", Stages.CastleMachinery },
				{ "THE LAB", Stages.TheLab },
				{ "THE GREAT HALL", Stages.TheGreatHall },
				{ "STORMY ASCENT", Stages.StormyAscent },
				{ "PAPU PAPU", Stages.PapuPapu },
				{ "KOALA KONG", Stages.KoalaKong },
				//{ "RIPPER ROO", Stages.RipperRoo1 },
				{ "PINSTRIPE POTOROO", Stages.PinstripePotoroo },
				{ "DR. NITRUS BRIO", Stages.DrNitrusBrio },
				//{ "DR. NEO CORTEX", Stages.DrNeoCortex1 },

				// Crash 2
				{ "TURTLE WOODS", Stages.TurtleWoods },
				{ "SNOW GO", Stages.SnowGo },
				{ "HANG EIGHT", Stages.HangEight },
				{ "THE PITS", Stages.ThePits },
				{ "CRASH DASH", Stages.CrashDash },
				{ "AIR CRASH", Stages.AirCrash },
				{ "SNOW BIZ", Stages.SnowBiz },
				{ "BEAR IT", Stages.BearIt },
				{ "CRASH CRUSH", Stages.CrashCrush },
				{ "THE EEL DEAL", Stages.TheEelDeal },
				{ "PLANT FOOD", Stages.PlantFood },
				{ "SEWER OR LATER", Stages.SewerOrLater },
				{ "BEAR DOWN", Stages.BearDown },
				{ "ROAD TO RUIN", Stages.RoadToRuin },
				{ "UN-BEARABLE", Stages.UnBearable },
				{ "HANGIN' OUT", Stages.HanginOut },
				{ "DIGGIN' IT", Stages.DigginIt },
				{ "COLD HARD CRASH", Stages.ColdHardCrash },
				{ "RUINATION", Stages.Ruination },
				{ "BEE-HAVING", Stages.BeeHaving },
				{ "PISTON IT AWAY", Stages.PistonItAway },
				{ "ROCK IT", Stages.RockIt },
				{ "NIGHT FIGHT", Stages.NightFight },
				{ "PACK ATTACK", Stages.PackAttack },
				{ "SPACED OUT", Stages.SpacedOut },
				{ "TOTALLY BEAR", Stages.TotallyBear },
				{ "TOTALLY FLY", Stages.TotallyFly },
				{ "RIPPER ROO", Stages.RipperRoo1 },
				{ "KOMODO BROTHERS", Stages.KomodoBrothers },
				{ "TINY TIGER", Stages.TinyTiger1 },
				{ "DR. N. GIN", Stages.DrNGin1 },
				{ "DR. NEO CORTEX", Stages.DrNeoCortex2 },

				// Crash 3
				{ "TOAD VILLAGE", Stages.ToadVillage },
				{ "UNDER PRESSURE", Stages.UnderPressure },
				{ "ORIENT EXPRESS", Stages.OrientExpress },
				{ "BONE YARD", Stages.BoneYard },
				{ "MAKIN' WAVES", Stages.MakinWaves },
				{ "GEE WIZ", Stages.GeeWiz },
				{ "HANG'EM HIGH", Stages.HangEmHigh },
				{ "HOG RIDE", Stages. HogRide},
				{ "TOMB TIME", Stages.TombTime },
				{ "MIDNIGHT RUN", Stages.MidnightRun },
				{ "DINO MIGHT!", Stages.DinoMight },
				{ "DEEP TROUBLE", Stages.DeepTrouble },
				{ "HIGH TIME", Stages.HighTime },
				{ "ROAD CRASH", Stages.RoadCrash },
				{ "DOUBLE HEADER", Stages.DoubleHeader },
				{ "SPHYNXINATOR", Stages.Sphynxinator },
				{ "BYE BYE BLIMPS", Stages.ByeByeBlimps },
				{ "TELL NO TALES", Stages.TellNoTales },
				{ "FUTURE FRENZY", Stages.FutureFrenzy },
				{ "TOMB WADER", Stages.TombWader },
				{ "GONE TOMORROW", Stages.GoneTomorrow },
				{ "ORANGE ASPHALT", Stages.OrangeAsphalt },
				{ "FLAMING PASSION", Stages.FlamingPassion },
				{ "MAD BOMBERS", Stages.MadBombers },
				{ "BUG LITE", Stages.BugLite },
				{ "SKI CRAZED", Stages.SkiCrazed },
				{ "AREA 51?", Stages.Area51 },
				{ "RINGS OF POWER", Stages.RingsOfPower },
				{ "HOT COCO", Stages.HotCoco },
				{ "EGGIPUS REX", Stages.EggipusRex },
				//{ "TINY TIGER", Stages.TinyTiger2 },
				{ "DINGODILE", Stages.Dingodile },
				{ "DR. N. TROPY", Stages.DrNTropy },
				//{ "DR. N. GIN", Stages.DrNGin2 },
				{ "UKA UKA", Stages.UkaUka },
				{ "FUTURE TENSE", Stages.FutureTense },

				// Hubs
				{ "N. SANITY ISLANDS", Stages.NSanityIsland },
				{ "THE WUMPA ISLANDS", Stages.TheWumpaIslands },
				{ "CORTEX ISLANDS", Stages.CortexIsland },
				{ "THE WARP ROOM", Stages.TheWarpRoom },
				{ "THE TIME TWISTER", Stages.TheTimeTwister }
			};
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

		private void OnFadeChange(float oldFade, float newFade)
		{
			// Fade start
			if (oldFade == 0 && newFade > 0)
			{
				OnFadeStart();
			}
			// Fade end (note that this only registers the end of fades TO black, not fades FROM black).
			else if (newFade == 1 && oldFade < 1)
			{
				OnFadeEnd();
			}
		}

		private void OnFadeStart()
		{
			// There are only two instances where fading in is valuable to the autosplitter. The first is starting a new game (at
			// which point the fade begins immediately) and the second is a quick fade following the opening cutscene for each game.
			if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning && memory.EnteringGame.Read())
			{
				timer.Start();

				return;
			}

			// This all accounts for restarting IGT following the opening cutscene. It's a special case because there's no fade from
			// the load screen into each opening cutscene.
			if (firstLoad)
			{
				firstLoad = false;

				if (startedFromTitle)
				{
					timer.CurrentState.IsGameTimePaused = false;
				}
			}
		}

		private void OnFadeEnd()
		{
			transitionTime = DateTime.Now;

			if (firstLoad && startedFromTitle)
			{
				timer.CurrentState.IsGameTimePaused = true;
			}
		}

		private void OnStageChange(ulong oldAddress, ulong newAddress)
		{
			string value = memory.Process.ReadAscii((IntPtr)newAddress);

			if (!stageMap.TryGetValue(value, out Stages stage))
			{
				if (loading)
				{
					loading = false;
					timer.CurrentState.IsGameTimePaused = false;
				}

				return;
			}

			loading = true;

			timer.CurrentState.IsGameTimePaused = true;
			timer.CurrentState.SetGameTime(timer.CurrentState.GameTimePauseTime - (DateTime.Now - transitionTime));

			StageData data = stageArray[(int)stage];
			
			// Data being null means you're entering either a hub or a boss.
			if (data == null)
			{
				inHub = hubSet.Contains(stage);

				// In Crash 2, after the opening cutscene (following starting a new game), the player enters a hub without first being
				// in a regular stage. The timer should not split in this case.
				if (inHub && (inStage || inBoss))
				{
					timer.Split();
				}

				inBoss = !inHub;
				inStage = false;

				if (settings.DisplayBoxes)
				{
					boxDisplay.Active = false;
				}

				relicDisplay?.Clear();

				return;
			}

			inStage = true;
			inBoss = false;
			inHub = false;

			if (settings.DisplayBoxes)
			{
				boxDisplay.Active = true;
				boxDisplay.BoxTarget = data.Boxes;
			}

			if (settings.DisplayRelics)
			{
				relicDisplay.Sapphire = data.Sapphire;
				relicDisplay.Gold = data.Gold;
				relicDisplay.Platinum = data.Platinum;
			}
		}

		public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
		{
			if (timer == null)
			{
				timer = new TimerModel
				{
					CurrentState = state
				};

				timer.CurrentState.OnStart += (sender, e) =>
				{
					firstLoad = true;

					if (!startedFromTitle)
					{
						startedFromTitle = memory.EnteringGame.Read();
					}

					timer.InitializeGameTime();
				};

				timer.CurrentState.OnReset += (sender, value) =>
				{
					firstLoad = false;
					startedFromTitle = false;
				};
			}
			
			Autosplit();

			if (memory.ProcessHooked && settings.DisplayEnabled)
			{
				invalidator?.Invalidate(0, 0, width, height);
			}
		}

		// This function is public for use in the tester class.
		public void Autosplit()
		{
			bool processPreviouslyHooked = memory.ProcessHooked;
			bool processHooked = memory.HookProcess();

			if (!processHooked)
			{
				if (processPreviouslyHooked)
				{
					if (settings.DisplayBoxes)
					{
						boxDisplay.Active = false;
					}

					relicDisplay?.Clear();
				}

				return;
			}

			memory.Refresh();
		}

		public void Dispose()
		{
		}
	}
}
