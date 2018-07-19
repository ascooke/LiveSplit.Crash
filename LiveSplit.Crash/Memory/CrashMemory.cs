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
		private ProgramPointer boxPointer;
		private Dictionary<string, Stages> stageMap;

		public CrashMemory()
		{
			stagePointer = new ProgramPointer("E06000000000100020?D", 0x130);
			fadePointer = new ProgramPointer("00006F12833A6F12833A", -0x1A, -1);
			boxPointer = new ProgramPointer("", 0);

			stageMap = new Dictionary<string, Stages>
			{
				// Crash 1
				{ "N. Sanity Beach", Stages.NSanityBeach },
				{ "Jungle Rollers", Stages.JungleRollers },
				{ "The Great Gate", Stages.TheGreatGate },
				{ "Boulders", Stages.Boulders },
				{ "Upstream", Stages.Upstream },
				{ "Rolling Stones", Stages.RollingStones },
				{ "Hog Wild", Stages.HogWild },
				{ "Native Fortress", Stages.NativeFortress },
				{ "Up the Creek", Stages.UpTheCreek },
				{ "The Lost City", Stages.TheLostCity },
				{ "Temple Ruins", Stages.TempleRuins },
				{ "Road to Nowhere", Stages.RoadToNowhere },
				{ "Boulder Dash", Stages.BoulderDash },
				{ "Whole Hog", Stages.WholeHog },
				{ "Sunset Vista", Stages.SunsetVista },
				{ "Heavy Machinery", Stages.HeavyMachinery },
				{ "Cortex Power", Stages.CortexPower },
				{ "Generator Room", Stages.GeneratorRoom },
				{ "Toxic Waste", Stages.ToxicWaste },
				{ "The High Road", Stages.TheHighRoad },
				{ "Slippery Climb", Stages.SlipperyClimb },
				{ "Lights Out", Stages.LightsOut },
				{ "Fumbling in the Dark", Stages.FumblingInTheDark },
				{ "Jaws of Darkness", Stages.JawsOfDarkness },
				{ "Castle Machinery", Stages.CastleMachinery },
				{ "The Lab", Stages.TheLab },
				{ "The Great Hall", Stages.TheGreatHall },
				{ "Papu Papu", Stages.PapuPapu },
				{ "Koala Kong", Stages.KoalaKong },
				{ "Ripper Roo", Stages.RipperRoo1 },
				{ "Pinstripe Potoroo", Stages.PinstripePotoroo },
				{ "Dr. Nitrus Brio", Stages.DrNitrusBrio },
				{ "Dr. Neo Cortex", Stages.DrNeoCortex1 },

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
				{ "Toad Village", Stages.ToadVillage },
				{ "Under Pressure", Stages.UnderPressure },
				{ "Orient Express", Stages.OrientExpress },
				{ "Bone Yard", Stages.BoneYard },
				{ "Makin' Waves", Stages.MakinWaves },
				{ "Gee Wiz", Stages.GeeWiz },
				{ "Hang'em High", Stages.HangEmHigh },
				{ "Hog Ride", Stages. HogRide},
				{ "Tomb Time", Stages.TombTime },
				{ "Midnight Run", Stages.MidnightRun },
				{ "Dino Might!", Stages.DinoMight },
				{ "Deep Trouble", Stages.DeepTrouble },
				{ "High Time", Stages.HighTime },
				{ "Road Crash", Stages.RoadCrash },
				{ "Double Header", Stages.DoubleHeader },
				{ "Sphynxinator", Stages.Sphynxinator },
				{ "Bye Bye Blimps", Stages.ByeByeBlimps },
				{ "Tell No Tales", Stages.TellNoTales },
				{ "Future Frenzy", Stages.FutureFrenzy },
				{ "Tomb Wader", Stages.TombWader },
				{ "Gone Tomorrow", Stages.GoneTomorrow },
				{ "Orange Asphalt", Stages.OrangeAsphalt },
				{ "Flaming Passion", Stages.FlamingPassion },
				{ "Mad Bombers", Stages.MadBombers },
				{ "Bug Lite", Stages.BugLite },
				{ "Ski Crazed", Stages.SkiCrazed },
				{ "Area 51?", Stages.Area51 },
				{ "Rings of Power", Stages.RingsOfPower },
				{ "Hot Coco", Stages.HotCoco },
				{ "Eggipus Rex", Stages.EggipusRex },
				{ "Tiny Tiger", Stages.TinyTiger2 },
				{ "Dingodile", Stages.Dingodile },
				{ "Dr. N. Tropy", Stages.DrNTropy },
				{ "Dr. N. Gin", Stages.DrNGin2 },
				{ "Uka Uka", Stages.UkaUka },
				{ "Future Tense", Stages.FutureTense },

				// Hubs
				{ "N. SANITY ISLANDS", Stages.NSanityIsland },
				{ "THE WUMPA ISLANDS", Stages.WumpaIslands },
				{ "CORTEX ISLANDS", Stages.CortexIsland },
				{ "THE WARP ROOM", Stages.TheWarpRoom },
				{ "THE TIME TWISTER", Stages.TheTimeTwister }
			};
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

		public Stages GetStage()
		{
			IntPtr pointer = stagePointer.Get<IntPtr>(process, out bool success);

			if (!success)
			{
				return Stages.None;
			}

			string key = process.ReadAscii(pointer);

			return !stageMap.TryGetValue(key, out Stages stage) ? Stages.None : stage;
		}
		
		private class ProgramPointer
		{
			private DateTime lastTry;
			private IntPtr pointer;

			private string signature;
			private int offset;
			private int resultIndex;

			public ProgramPointer(string signature, int offset, int resultIndex = 0)
			{
				this.signature = signature;
				this.offset = offset;
				this.resultIndex = resultIndex;
			}

			public T Get<T>(Process process, out bool success) where T : struct
			{
				if (process == null)
				{
					pointer = IntPtr.Zero;
					success = false;

					return default(T);
				}

				if (!AcquirePointer(process))
				{
					success = false;

					return default(T);
				}

				success = true;

				return process.Read<T>(pointer, offset);
			}

			private bool AcquirePointer(Process process)
			{
				if (pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1))
				{
					lastTry = DateTime.Now;

					MemorySearcher searcher = new MemorySearcher
					{
						MemoryFilter = info =>
							(info.State & 0x1000) != 0 &&
							(info.Protect & 0x04) != 0 &&
							(info.Protect & 0x100) == 0
					};

					switch (resultIndex)
					{
						case -1:
							pointer = searcher.FindSignatures(process, signature).Last();
							break;

						case 0:
							pointer = searcher.FindSignature(process, signature);
							break;

						default:
							pointer = searcher.FindSignatures(process, signature)[resultIndex];
							break;
					}
				}

				return pointer != IntPtr.Zero;
			}
		}
	}
}
