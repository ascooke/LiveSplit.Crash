using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Crash.Memory
{
	public class CrashMemory
	{
		private Process process;
		private ProgramPointer fadePointer;
		private ProgramPointer stagePointer;
		private ProgramPointer pausePointer;
		private ProgramPointer boxPointer;
		private Dictionary<string, Stages> stageMap;

		public CrashMemory()
		{
			stagePointer = new ProgramPointer("Stage", "E06000000000100020", 0x130);
			fadePointer = new ProgramPointer("Fade", "00006F12833A6F12833A", -0x1A, -1);
			pausePointer = new ProgramPointer("Pause", "0300000000800700003804000038", 0x27);
			boxPointer = new ProgramPointer("Box", "FF4992244992240800", 0x1BED47);

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

		public bool AllPointersFound
		{
			get
			{
				ProgramPointer[] pointers =
				{
					fadePointer,
					stagePointer,
					pausePointer,
					boxPointer
				};

				return pointers.All(p => p.Pointer != IntPtr.Zero);
			}
		}

		public bool HookProcess()
		{
			if (process == null || process.HasExited)
			{
				Process[] processes = Process.GetProcessesByName("CrashBandicootNSaneTrilogy");
				process = processes.Length == 0 ? null : processes[0];

				if (processes.Length == 0 || process.HasExited)
				{
					return false;
				}

				MemoryReader.Update64Bit(process);

				return true;
			}

			return true;
		}

		public float GetFade()
		{
			return fadePointer.Get<float>(process, out bool success);
		}

		public int GetBoxes()
		{
			return boxPointer.Get<int>(process, out bool success);
		}

		public bool IsPaused()
		{
			return pausePointer.Get<short>(process, out bool success) == 1;
		}

		public Stages GetStage()
		{
			IntPtr pointer = stagePointer.Get<IntPtr>(process, out bool success);

			if (!success)
			{
				return Stages.Invalid;
			}

			string key = process.ReadAscii(pointer);
			
			if (key.Length == 0)
			{
				return Stages.Title;
			}

			return !stageMap.TryGetValue(key, out Stages stage) ? Stages.None : stage;
		}
		
		private class ProgramPointer
		{
			private DateTime lastTry;

			private string name;
			private string signature;
			private int offset;
			private int resultIndex;

			public ProgramPointer(string name, string signature, int offset, int resultIndex = 0)
			{
				this.name = name;
				this.signature = signature;
				this.offset = offset;
				this.resultIndex = resultIndex;
			}

			public IntPtr Pointer { get; private set; }

			public T Get<T>(Process process, out bool success) where T : struct
			{
				if (process == null)
				{
					Pointer = IntPtr.Zero;
					success = false;

					return default(T);
				}

				if (!AcquirePointer(process))
				{
					success = false;

					return default(T);
				}

				success = true;

				return process.Read<T>(Pointer, offset);
			}

			private bool AcquirePointer(Process process)
			{
				if (Pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1))
				{
					lastTry = DateTime.Now;

					MemorySearcher searcher = new MemorySearcher
					{
						MemoryFilter = info =>
							(info.State & 0x1000) != 0 &&
							(info.Protect & 0x04) != 0 &&
							(info.Protect & 0x100) == 0
					};

					IntPtr previousPointer = Pointer;

					switch (resultIndex)
					{
						case -1:
							Pointer = searcher.FindSignatures(process, signature).Last();
							break;

						case 0:
							Pointer = searcher.FindSignature(process, signature);
							break;

						default:
							Pointer = searcher.FindSignatures(process, signature)[resultIndex];
							break;
					}

					if (previousPointer == IntPtr.Zero && Pointer != IntPtr.Zero)
					{
						Console.WriteLine($"{name} pointer found ({Pointer.ToString("X")}).");
					}
				}

				return Pointer != IntPtr.Zero;
			}
		}
	}
}
