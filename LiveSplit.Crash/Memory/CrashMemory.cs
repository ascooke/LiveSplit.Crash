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
		private IntPtr stageBase;

		// The game stores stage data in a different order than you'd logically expect. This array is used to translate
		// that order to the order stages are listed in the enumeration.
		private Stages[] stageOrdering;

		private string[] stageSignatures;
		private int[] stageOffsets;

		public CrashMemory()
		{
			stagePointer = new ProgramPointer("E06000000000100020?D", 0x130);
			fadePointer = new ProgramPointer("00006F12833A6F12833A", -0x1A, -1);

			// Note that the stage ordering in memory is mostly in order by game, but not always.
			stageOrdering = new []
			{
				// Crash 1
				Stages.RipperRoo1,
				Stages.PapuPapu,
				Stages.NSanityBeach,
				Stages.JungleRollers,
				Stages.TheGreatGate,
				Stages.Boulders,
				Stages.Upstream,
				Stages.RollingStones,
				Stages.HogWild,
				Stages.NativeFortress,
				Stages.UpTheCreek,
				Stages.TheLostCity,
				Stages.TempleRuins,
				Stages.RoadToNowhere,
				Stages.BoulderDash,
				Stages.WholeHog,
				Stages.SunsetVista,
				Stages.HeavyMachinery,
				Stages.CortexPower,
				Stages.GeneratorRoom,
				Stages.ToxicWaste,
				Stages.TheHighRoad,
				Stages.SlipperyClimb,
				Stages.LightsOut,
				Stages.FumblingInTheDark,
				Stages.JawsOfDarkness,
				Stages.CastleMachinery,
				
				// Crash 2
				Stages.RipperRoo2,
				Stages.KomodoBrothers,
				Stages.TinyTiger1,
				Stages.DrNGin1,
				Stages.DrNeoCortex,
				Stages.TurtleWoods,
				Stages.HangEight,
				Stages.ThePits,
				Stages.CrashDash,
				Stages.SnowBiz,
				Stages.AirCrash,
				Stages.CrashCrush,
				Stages.TheEelDeal,
				Stages.PlantFood,
				Stages.SewerOrLater,
				Stages.BearDown,
				Stages.RockIt,
				Stages.RoadToRuin,

				Stages.NBrio,
				Stages.Pinstripe,
				Stages.TheLab,

				Stages.SnowGo,
				Stages.BearIt,

				Stages.GeeWiz,

				Stages.UnBearable,
				Stages.HanginOut,
				Stages.DigginIt,
				Stages.ColdHardCrash,
				Stages.Ruination,
				Stages.BeeHaving,
				Stages.PistonItAway,
				Stages.NightFight,
				Stages.PackAttack,
				Stages.SpacedOut,
				Stages.TotallyBear,
				Stages.TotallyFly,

				// Crash 3
				//Stages.TinyTiger2, // Tenative (might use the existing string from Crash 2)
				Stages.Dingodile,
				Stages.DrNTropy,
				//Stages.DrNGin2, // Tentative (might use the existing string from Crash 2)
				//Stages.UkaUka, // Tentative (might be called something involving Cortex)
				Stages.ToadVillage,
				Stages.UnderPressure,
				Stages.OrientExpress,
				Stages.BoneYard,
				Stages.MakinWaves,
				Stages.HangEmHigh,
				Stages.HogRide,
				Stages.TombTime,
				Stages.MidnightRun,
				Stages.DinoMight,
				Stages.DeepTrouble,
				Stages.HighTime,
				Stages.RoadCrash,
				Stages.DoubleHeader,
				Stages.Sphynxinator,
				Stages.ByeByeBlimps,
				Stages.TellNoTales,
				Stages.FutureFrenzy,
				Stages.TombWader,
				Stages.GoneTomorrow,
				Stages.OrangeAsphalt,
				Stages.FlamingPassion,
				Stages.MadBombers,
				Stages.BugLite,
				Stages.SkiCrazed,
				Stages.Area51,
				Stages.RingsOfPower,
				Stages.HotCoco,
				Stages.EggipusRex,

				// DLC
				Stages.StormyAscent,
				Stages.FutureTense
			};

			// Most (or all) of these strings could almost certainly be shortened and achieve the same results, but I'd rather be safe.
			// Strings can always be shortened later if needed.
			stageSignatures = new []
			{
				// Crash 1
				"52697070657220526f6f", // Ripper Roo
				"506170752050617075", // Papu Papu
				"4e2e2053616e697479204265616368", // N. Sanity Beach
				"4a756e676c6520526f6c6c657273", // Jungle Rollers
				"5468652047726561742047617465", // The Great Gate
				"426f756c64657273", // Boulders
				"557073747265616d", // Upstream
				"526f6c6c696e672053746f6e6573", // Rolling Stones
				"486f672057696c64", // Hog Wild
				"4e617469766520466f727472657373", // Native Fortress
				"55702074686520437265656b", // Up the Creek
				"546865204c6f73742043697479", // The Lost City
				"54656d706c65205275696e73", // Temple Ruins
				"526f616420746f204e6f7768657265", // Road to Nowhere
				"426f756c6465722044617368", // Boulder Dash
				"57686f6c6520486f67", // Whole Hog
				"53756e736574205669737461", // Sunset Vista
				"4865617679204d616368696e657279", // Heavy Machinery
				"436f7274657820506f776572", // Cortex Power
				"47656e657261746f7220526f6f6d", // Generator Room
				"546f786963205761737465", // Toxic Waste
				"546865204869676820526f6164", // The High Road
				"536c69707065727920436c696d62", // Slippery Climb
				"4c6967687473204f7574", // Lights Out
				"46756d626c696e6720696e20746865204461726b", // Fumbling in the Dark
				"4a617773206f66204461726b6e657373", // Jaws of Darkness
				"436173746c65204d616368696e657279", // Castle Machinery

				// Crash 2
				"52495050455220524f4f", // RIPPER ROO
				"4b4f4d4f444f2042524f5448455253", // KOMODO BROTHERS
				"54494e59205449474552", // TINY TIGER
				"44522e204e2e2047494e", // DR. N. GIN
				"44522e204e454f20434f52544558", // DR. NEO CORTEX
				"545552544c4520574f4f4453", // TURTLE WOODS
				"48414e47204549474854", // HANG EIGHT
				"5448452050495453", // THE PITS
				"43524153482044415348", // CRASH DASH
				"534e4f572042495a", // SNOW BIZ
				"414952204352415348", // AIR CRASH
				"4352415348204352555348", // CRASH CRUSH
				"5448452045454c204445414c", // THE EEL DEAL
				"504c414e5420464f4f44", // PLANT FOOD
				"5345574552204f52204c41544552", // SEWER OR LATER
				"4245415220444f574e", // BEAR DOWN
				"524f434b204954", // ROCK IT
				"524f414420544f205255494e", // ROAD TO RUIN
	
				"4e2e204272696f", // N. Brio
				"50696e73747269706520506f746f726f6f", // Pinstripe Potoroo
				"546865204c6162", // The Lab

				"534e4f5720474f", // SNOW GO
				"42454152204954", // BEAR IT

				"4765652057697a", // Gee Wiz

				"554e2d4245415241424c45", // UN-BEARABLE
				"48414e47494e27204f5554", // HANGIN' OUT
				"44494747494e27204954", // DIGGIN' IT
				"434f4c442048415244204352415348", // COLD HARD CRASH
				"5255494e4154494f4e", // RUINATION
				"4245452d484156494e47", // BEE-HAVING
				"504953544f4e2049542041574159", // PISTON IT AWAY
				"4e49474854204649474854", // NIGHT FIGHT
				"5041434b2041545441434b", // PACK ATTACK
				"535041434544204f5554", // SPACED OUT
				"544f54414c4c592042454152", // TOTALLY BEAR
				"544f54414c4c5920464c59", // TOTALLY FLY

				// Crash 3
				//"", //

				// DLC
			};

			stageOffsets = new int[stageOrdering.Length];
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

		public bool GetLoadIndicator()
		{
			return false;
		}

		public float GetFade()
		{
			return fadePointer.Get<float>(process, out bool success);
		}

		public Stages GetStage()
		{
			if (stageBase == IntPtr.Zero && !FindStageOffsets(process))
			{
				return Stages.None;
			}

			IntPtr address = stagePointer.Get<IntPtr>(process, out bool success);

			if (success)
			{
				int offset = (int)((ulong)address - (ulong)stageBase);

				for (int i = 0; i < stageOffsets.Length; i++)
				{
					if (offset == stageOffsets[i])
					{
						return stageOrdering[i];
					}
				}
			}

			return Stages.None;
		}

		private bool FindStageOffsets(Process process)
		{
			MemorySearcher searcher = new MemorySearcher
			{
				MemoryFilter = info =>
					(info.State & 0x1000) != 0 &&
					(info.Protect & 0x04) != 0 &&
					(info.Protect & 0x100) == 0
			};

			IntPtr[] pointers = searcher.FindSignatures(process, stageSignatures);

			if (pointers == null)
			{
				return false;
			}

			stageBase = pointers[0];

			ulong converted = (ulong)stageBase;

			for (int i = 1; i < pointers.Length; i++)
			{
				stageOffsets[i] = (int)((ulong)pointers[i] - converted);
			}

			return true;
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
